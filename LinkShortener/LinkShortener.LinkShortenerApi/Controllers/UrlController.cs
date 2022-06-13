using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.UseCases;
using LinkShortener.LinkShortenerApi.ReponseApi;
using LinkShortener.LinkShortenerApi.ReponseApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.LinkShortenerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UrlController : Controller
{
    private readonly IGetUser _getUser;
    private readonly ISaveUrl _saveUrl;
    private readonly IHistory _history;
    private readonly IDeleteUrl _deleteUrl;

    public UrlController(IGetUser getUser, ISaveUrl saveUrl, IHistory history, IDeleteUrl deleteUrl)
    {
        _getUser = getUser;
        _saveUrl = saveUrl;
        _history = history;
        _deleteUrl = deleteUrl;
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

    [HttpGet("history")]
    public IActionResult GetHistoryUrl()
    {
        var jwt = Request.Cookies["jwt"];
        var user = _getUser.GetUser(jwt);

        return Ok(new HistoreResponse()
        {
            Status = StatusResponse.Success,
            Data = _history.GetHistory(user.Id),
            Messages = new List<string> { "Success" }
        });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUrl(Guid id)
    {
        _deleteUrl.DeleteUrl(id);

        return Ok(new DeleteUrlResponse()
        {
            Status = StatusResponse.Success,
            Messages = new List<string>() { "Success" }
        });
    }
}