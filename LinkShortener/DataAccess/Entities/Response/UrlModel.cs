namespace LinkShortener.DataAccess.Entities.Response;

public class UrlModel
{
    public Guid Id { get; set; }
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
}
