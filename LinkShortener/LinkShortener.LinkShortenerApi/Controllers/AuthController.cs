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
        return Created("Success", new RegisterResponse()
        {
            Status = StatusResponse.Success,
            Data = _registerUser.Register(registerData),
            Messages = new List<string>() { "Success" }
        });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto loginData)
    {
        var token = _loginUser.Login(loginData);

        if(token == null)
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
            Data = token,
            Messages = new List<string>() { "Success" }
        });
    }
}