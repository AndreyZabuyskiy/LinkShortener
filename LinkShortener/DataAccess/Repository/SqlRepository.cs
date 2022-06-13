using Domain;
using LinkShortener.DataAccess.Entities.Request;
using LinkShortener.DataAccess.Entities.Response;

namespace DataAccess.Repository;

public class SqlRepository : IRepository
{
    private readonly ApplicationContext _context;

    public SqlRepository(ApplicationContext context)
    {
        _context = context;
    }

    public UserReadModel CreateUser(UserCreateModel userModel)
    {
        var user = new User()
        {
            Login = userModel.Login,
            Password = userModel.Password,
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return new UserReadModel
        {
            Id = user.Id,
            Login = userModel.Login
        };
    }

    public UserReadModel GetById(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null) return null;

        return new UserReadModel()
        {
            Id = user.Id,
            Login = user.Login
        };
    }

    public UserLoginModel? GetByLogin(string login)
    {
        var user = _context.Users.FirstOrDefault(u => u.Login == login);

        if(user == null) return null;

        return new UserLoginModel()
        {
            Id = user.Id,
            Login = user.Login,
            Passport = user.Password
        };
    }

    public List<UrlModel> GetHistory(Guid userId)
    {
        var listUrl = _context.Links.Where(l => l.User.Id == userId).ToList();
        var result = new List<UrlModel>();
        
        foreach(var url in listUrl)
        {
            result.Add(new UrlModel()
            {
                Id = url.Id,
                FullUrl = url.FullUrl,
                ShortUrl = url.ShortUrl
            });
        }

        return result;
    }

    public bool SaveUrl(UrlSaveModel model)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == model.UserId);

        if (user == null) return false;

        var link = new Link()
        {
            FullUrl = model.FullUrl,
            ShortUrl = model.ShortUrl,
            User = user
        };

        _context.Links.Add(link);
        _context.SaveChanges();
        return true;
    }
}