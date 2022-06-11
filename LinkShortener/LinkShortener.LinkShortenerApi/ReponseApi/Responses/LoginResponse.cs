using LinkShortener.BusinessLogic.Dtos.Response;

namespace LinkShortener.LinkShortenerApi.ReponseApi.Responses;

public class LoginResponse : IResponseApi<UserReadDto>
{
    public StatusResponse Status { get; set; }
    public UserReadDto Data { get; set; }
    public List<string> Messages { get; set; }
}