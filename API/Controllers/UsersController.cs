using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class UsersController(DataContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet] // /API/Users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
    {
        return Ok(await context.Users.ToListAsync());
    }

    [Authorize]
    [HttpGet("{id:int}")] // /API/Users/2
    public async Task<ActionResult<AppUser>> GetUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
}
