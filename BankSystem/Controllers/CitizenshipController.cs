using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class CitizenshipController(BankDbContext dbContext) : ControllerBase
{
    // GET: api/Citizenship
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CitizenshipEntity>>> Get()
    {
        var citizenship = await dbContext.Citizenship.ToListAsync();
        return Ok(citizenship);
    }

    // GET: api/Citizenship/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CitizenshipEntity>> Get(int id)
    {
        var citizenshipEntity = await dbContext.Citizenship.FirstOrDefaultAsync(e => e.Id == id);

        if (citizenshipEntity == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(citizenshipEntity);
    }
}