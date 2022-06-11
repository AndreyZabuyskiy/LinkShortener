namespace LinkShortener.LinkShortenerApi.ReponseApi;

public interface IResponseApi<T>
{
    public StatusResponse Status { get; set; }
    public T Data { get; set; }
    public List<string> Messages { get; set; }
}