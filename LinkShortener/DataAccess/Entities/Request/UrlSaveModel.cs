namespace LinkShortener.DataAccess.Entities.Request;

public class UrlSaveModel
{
    public Guid UserId { get; set; }
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
}