namespace LinkShortener.DataAccess.Entities.Response;

public class UserLoginModel
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Passport { get; set; }
}
