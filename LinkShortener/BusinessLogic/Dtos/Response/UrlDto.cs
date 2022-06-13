namespace LinkShortener.BusinessLogic.Dtos.Response;

public class UrlDto
{
    public Guid Id { get; set; }
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
}