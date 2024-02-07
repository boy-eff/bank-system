using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class MaritalStatusController(BankDbContext dbContext) : ControllerBase
{
    // GET: api/MaritalStatus
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaritalStatusEntity>>> Get()
    {
        var MaritalStatus = await dbContext.MaritalStatuses.ToListAsync();
        return Ok(MaritalStatus);
    }

    // GET: api/MaritalStatus/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MaritalStatusEntity>> Get(int id)
    {
        var MaritalStatusEntity = await dbContext.MaritalStatuses.FirstOrDefaultAsync(e => e.Id == id);

        if (MaritalStatusEntity == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(MaritalStatusEntity);
    }
}