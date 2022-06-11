using LinkShortener.BusinessLogic.Dtos.Response;

namespace LinkShortener.LinkShortenerApi.ReponseApi.Responses;

public class LoginResponse : IResponseApi<string>
{
    public StatusResponse Status { get; set; }
    public string Data { get; set; }
    public List<string> Messages { get; set; }
}