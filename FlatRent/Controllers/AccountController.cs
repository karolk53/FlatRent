using FlatRent.DTOs;
using FlatRent.Entities;
using FlatRent.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatRent.Controllers;

public class AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ITokenService tokenService)
    : BaseApiController
{
    private readonly ITokenService _tokenService = tokenService;
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
    public async Task<ActionResult<string>> LoginUser(LoginDto loginDto)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName.Equals(loginDto.Username.ToLower()));

        if(user == null) return Unauthorized("Invalid username or password!");

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if(!result) return Unauthorized("Invalid email or password!");

        return await _tokenService.CreateToken(user);
    }

    private async Task<bool> UserExists(string email)
    {
        return await _userManager.Users.AnyAsync(x => x.Email.Equals(email));
    }
    
}