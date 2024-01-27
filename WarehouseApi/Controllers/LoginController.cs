using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WarehouseApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginController(IConfiguration config, SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
        _config = config;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserModel loginModel)
    {
        IActionResult response = Unauthorized();
        var success = AuthenticateUser(loginModel);

        if (success)
        {
            var tokenString = GenerateJsonWebToken(loginModel);
            response = Ok(new { token = tokenString });
            return response;
        }

        return response;
    }

    private string GenerateJsonWebToken(UserModel loginModel)
    {
        // generate key
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(5), signingCredentials:
            credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private bool AuthenticateUser(UserModel loginModel)
    {
        var result = _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, true, false).Result;
        return result.Succeeded;
    }
}