using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.UseCases;
using LinkShortener.LinkShortenerApi.ReponseApi;
using LinkShortener.LinkShortenerApi.ReponseApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.LinkShortenerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShortenerUrlController : Controller
{
    private readonly IGetUser _getUser;
    private readonly ISaveUrl _saveUrl;

    public ShortenerUrlController(IGetUser getUser, ISaveUrl saveUrl)
    {
        _getUser = getUser;
        _saveUrl = saveUrl;
    }

    [HttpPost("save-url")]
    public IActionResult SaveUrl(UrlSaveDto data)
    {
        var jwt = Request.Cookies["jwt"];
        var user = _getUser.GetUser(jwt);

        var result = _saveUrl.Save(user.Id, data);

        var response = new SaveUrlResponse()
        {
            Status = StatusResponse.Success,
            Messages = new List<string> { "Success" }
        };

        return Ok(response);
    }
}