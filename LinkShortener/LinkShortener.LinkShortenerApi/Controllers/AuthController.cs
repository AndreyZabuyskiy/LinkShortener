using LinkShortener.BusinessLogic.Dtos;
using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.UseCases;
using LinkShortener.LinkShortenerApi.ReponseApi;
using LinkShortener.LinkShortenerApi.ReponseApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.LinkShortenerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IRegisterUser _registerUser;
    private readonly ILoginUser _loginUser;

    public AuthController(IRegisterUser registerUser, ILoginUser loginUser)
    {
        _registerUser = registerUser;
        _loginUser = loginUser;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerData)
    {
        var user = _registerUser.Register(registerData);

        var response = new RegisterResponse()
        {
            Status = StatusResponse.Success,
            Data = user,
            Messages = new List<string>() { "Success" }
        };

        return Created("Success", response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto loginData)
    {
        var user = _loginUser.Login(loginData);

        if(user == null)
        {
            return BadRequest(new LoginResponse()
            {
                Status = StatusResponse.NotLogin,
                Data = null,
                Messages = new List<string>() { "Invalid Credentials" }
            });
        }

        return Ok(new LoginResponse()
        {
            Status = StatusResponse.Success,
            Data = user,
            Messages = new List<string>() { "Success" }
        });
    }
}