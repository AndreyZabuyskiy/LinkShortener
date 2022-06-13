namespace LinkShortener.LinkShortenerApi.ReponseApi.Responses;

public class SaveUrlResponse : IResponseApi
{
    public StatusResponse Status { get; set; }
    public List<string> Messages { get; set; }
}