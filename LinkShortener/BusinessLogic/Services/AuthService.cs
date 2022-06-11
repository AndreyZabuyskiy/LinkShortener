using BusinessLogic.UseCases;
using DataAccess.Entities.Request;
using DataAccess.Repository;
using LinkShortener.BusinessLogic.Dtos;
using LinkShortener.BusinessLogic.Dtos.Response;

namespace BusinessLogic.Services;

public class AuthService : IRegisterUser
{
    private readonly IRepository _repository;

    public AuthService(IRepository repository)
    {
        _repository = repository;
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