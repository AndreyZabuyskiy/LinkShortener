using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.LinkShortenerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Hello()
    {
        return Ok("Success");
    }
}