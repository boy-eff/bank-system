using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class DisabilityController(BankDbContext dbContext) : ControllerBase
{
    // GET: api/Disability
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DisabilityEntity>>> Get()
    {
        var Disability = await dbContext.Disabilities.ToListAsync();
        return Ok(Disability);
    }

    // GET: api/Disability/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DisabilityEntity>> Get(int id)
    {
        var DisabilityEntity = await dbContext.Disabilities.FirstOrDefaultAsync(e => e.Id == id);

        if (DisabilityEntity == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(DisabilityEntity);
    }
}