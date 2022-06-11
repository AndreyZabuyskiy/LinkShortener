using DataAccess.Entities.Request;
using DataAccess.Entities.Response;
using Domain;

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
}