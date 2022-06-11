namespace LinkShortener.LinkShortenerApi.ReponseApi;

public interface IResponseApi
{
    StatusResponse Status { get; set; }
    List<string> Messages { get; set; }
}

public interface IResponseApi<T>
{
    StatusResponse Status { get; set; }
    T Data { get; set; }
    List<string> Messages { get; set; }
}