using DataAccess.Repository;
using LinkShortener.BusinessLogic.Dtos;
using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.Dtos.Response;
using LinkShortener.BusinessLogic.UseCases;
using LinkShortener.DataAccess.Entities.Request;

namespace BusinessLogic.Services;

public class AuthService : IRegisterUser, ILoginUser
{
    private readonly IRepository _repository;

    public AuthService(IRepository repository)
    {
        _repository = repository;
    }

    public UserReadDto Login(LoginDto loginData)
    {
        var user = _repository.GetByLogin(loginData.Login);

        if (user == null)
        {
            return null;
        }

        if(!BCrypt.Net.BCrypt.Verify(loginData.Password, user.Passport))
        {
            return null;
        }

        return new UserReadDto()
        {
            Id = user.Id,
            Login = user.Login,
        };
    }

    public UserReadDto Register(RegisterDto registerData)
    {
        var userModel = new UserCreateModel
        {
            Login = registerData.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(registerData.Password)
        };

        var user = _repository.CreateUser(userModel);

        return new UserReadDto()
        {
            Id = user.Id,
            Login = user.Login
        };
    }
}