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
    private readonly ISaveUrl _saveUrl;

    public ShortenerUrlController(IGetUser getUser, ISaveUrl saveUrl)
    {
        _saveUrl = saveUrl;
    }

    [HttpPost("save-url")]
    public IActionResult SaveUrl(UrlSaveDto data)
    {
        var result = _saveUrl.Save(data);

        var response = new SaveUrlResponse()
        {
            Status = StatusResponse.Success,
            Messages = new List<string> { "Success" }
        };

        return Ok(response);
    }
}