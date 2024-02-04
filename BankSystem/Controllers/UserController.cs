using BankSystem.Entities;
using BankSystem.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(BankDbContext dbContext) : ControllerBase
{
    private readonly BankDbContext _dbContext = dbContext;
    
    [HttpPost]
    public async Task<ActionResult<UserModel>> AddUser([FromBody]CreateUpdateUserModel userModel)
    {
        var user = userModel.Adapt<UserEntity>();
        var createdUser = await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return Ok(createdUser.Entity);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserModel>> UpdateUser([FromRoute] int id, [FromBody] CreateUpdateUserModel userModel)
    {
        var updatedUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (updatedUser is null)
        {
            return NotFound("User not found");
        }

        userModel.Adapt(updatedUser);
        await _dbContext.SaveChangesAsync();
        return Ok(updatedUser);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserModel>> GetUser([FromRoute]int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (user is null)
        {
            return NotFound("User not found");
        }

        return Ok(user.Adapt<UserModel>());
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> GetUsers()
    {
        var users = await  _dbContext.Users.ToListAsync();
        return users.Adapt<List<UserModel>>();
    }
}