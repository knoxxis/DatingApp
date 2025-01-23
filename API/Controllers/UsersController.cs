using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("API/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet] // /API/Users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
    {
        return Ok(await context.Users.ToListAsync());
    }

    [HttpGet("{id:int}")] // /API/Users/2
    public async Task<ActionResult<AppUser>> GetUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
}
