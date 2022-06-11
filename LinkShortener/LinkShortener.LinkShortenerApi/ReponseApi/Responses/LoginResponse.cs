namespace LinkShortener.LinkShortenerApi.ReponseApi.Responses;

public class LoginResponse : IResponseApi
{
    public StatusResponse Status { get; set; }
    public List<string> Messages { get; set; }
}