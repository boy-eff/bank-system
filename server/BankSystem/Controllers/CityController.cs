using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class CityController(BankDbContext dbContext) : ControllerBase
{
    // GET: api/City
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CitizenshipEntity>>> Get()
    {
        var citizenship = await dbContext.Cities.ToListAsync();
        return Ok(citizenship);
    }

    // GET: api/City/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CitizenshipEntity>> Get(int id)
    {
        var citizenshipEntity = await dbContext.Cities.FirstOrDefaultAsync(e => e.Id == id);

        if (citizenshipEntity == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(citizenshipEntity);
    }
}