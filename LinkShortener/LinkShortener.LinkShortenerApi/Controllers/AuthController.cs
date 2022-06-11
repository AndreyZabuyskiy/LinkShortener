using BusinessLogic.UseCases;
using LinkShortener.BusinessLogic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.LinkShortenerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IRegisterUser _registerUser;

    public AuthController(IRegisterUser registerUser)
    {
        _registerUser = registerUser;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerData)
    {
        var user = _registerUser.Register(registerData);
        return Created("Success", user);
    }
}