using LinkShortener.BusinessLogic.Dtos;
using LinkShortener.BusinessLogic.Dtos.Response;

namespace BusinessLogic.UseCases;

public interface IRegisterUser
{
    UserReadDto Register(RegisterDto registerData);
}