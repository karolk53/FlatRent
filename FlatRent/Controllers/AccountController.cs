using FlatRent.DTOs;
using FlatRent.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatRent.Controllers;

public class AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    : BaseApiController
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly RoleManager<AppRole> _roleManager = roleManager;

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> RegisterNewAccount(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Email)) return BadRequest("Email is alreadt taken");

        var user = new AppUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded) return Ok(user);
        return BadRequest("Failed to create new user");
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginUser(LoginDto loginDto)
    {
        return null;
    }

    private async Task<bool> UserExists(string email)
    {
        return await _userManager.Users.AnyAsync(x => x.Email.Equals(email));
    }
    
}