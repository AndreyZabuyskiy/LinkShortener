using LinkShortener.BusinessLogic.Dtos.Response;

namespace LinkShortener.LinkShortenerApi.ReponseApi.Responses;

public class HistoreResponse : IResponseApi<List<UrlDto>>
{
    public StatusResponse Status { get; set; }
    public List<UrlDto> Data { get; set; }
    public List<string> Messages { get; set; }
}