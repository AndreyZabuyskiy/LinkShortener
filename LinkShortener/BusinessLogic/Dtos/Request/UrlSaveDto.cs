namespace LinkShortener.BusinessLogic.Dtos.Request;

public class UrlSaveDto
{
    public Guid UserId { get; set; }
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
}