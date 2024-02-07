using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class SexController(BankDbContext dbContext) : ControllerBase
{
    // GET: api/Sex
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SexEntity>>> Get()
    {
        var Sex = await dbContext.Sexes.ToListAsync();
        return Ok(Sex);
    }

    // GET: api/Sex/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SexEntity>> Get(int id)
    {
        var SexEntity = await dbContext.Sexes.FirstOrDefaultAsync(e => e.Id == id);

        if (SexEntity == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(SexEntity);
    }
}