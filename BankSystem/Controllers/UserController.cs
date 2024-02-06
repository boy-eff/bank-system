using BankSystem.Entities;
using BankSystem.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BankSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(BankDbContext dbContext) : ControllerBase
{
    private readonly BankDbContext _dbContext = dbContext;
    
    [HttpPost]
    public async Task<ActionResult<ServeResult<UserModel>>> AddUser([FromBody]CreateUpdateUserModel userModel)
    {
        var user = userModel.Adapt<UserEntity>();
        var createdUser = await _dbContext.Users.AddAsync(user);
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch(DbUpdateException ex) when (ex.InnerException is PostgresException sqlEx)
        {
            if (sqlEx.SqlState == "23505")
            {
                return BadRequest(new ServeResult<UserModel>(int.Parse(sqlEx.SqlState), sqlEx.ConstraintName ?? "Something wend wrong"));
            }
            
            return BadRequest(new ServeResult<UserModel>(2, "Something wend wrong"));
        }
        
        return Ok(new ServeResult<UserModel>(createdUser.Entity.Adapt<UserModel>()));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ServeResult<UserModel>>> UpdateUser([FromRoute] int id, [FromBody] CreateUpdateUserModel userModel)
    {
        var updatedUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (updatedUser is null)
        {
            return NotFound(new ServeResult<UserModel>(1, "User not found"));
        }

        userModel.Adapt(updatedUser);
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch(DbUpdateException)
        {
            return BadRequest(new ServeResult<UserModel>(2, "Something went wrong"));
        }
        return Ok(new ServeResult<UserModel>(updatedUser.Adapt<UserModel>()));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ServeResult<int>>> DeleteUser([FromRoute] int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (user is null)
        {
            return NotFound(new ServeResult<int>(1, "User not found"));
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return new ServeResult<int>(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServeResult<UserModel>>> GetUser([FromRoute]int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (user is null)
        {
            return NotFound(new ServeResult<UserModel>(1, "User not found"));
        }

        return Ok(new ServeResult<UserModel>(user.Adapt<UserModel>()));
    }
    
    [HttpGet]
    public async Task<ActionResult<ServeResult<List<UserModel>>>> GetUsers()
    {
        var users = await  _dbContext.Users.ToListAsync();
        return new ServeResult<List<UserModel>>(users.Adapt<List<UserModel>>());
    }
}