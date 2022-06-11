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
}