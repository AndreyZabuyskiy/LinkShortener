using BusinessLogic.UseCases;
using LinkShortener.BusinessLogic.Dtos;
using LinkShortener.LinkShortenerApi.ReponseApi;
using LinkShortener.LinkShortenerApi.ReponseApi.Responses;
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

        var response = new RegisterResponse()
        {
            Status = StatusResponse.Success,
            Data = user,
            Messages = new List<string>() { "Success" }
        };

        return Created("Success", response);
    }
}