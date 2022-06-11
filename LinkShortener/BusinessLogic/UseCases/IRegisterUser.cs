using LinkShortener.BusinessLogic.Dtos;
using LinkShortener.BusinessLogic.Dtos.Response;

namespace LinkShortener.BusinessLogic.UseCases;

public interface IRegisterUser
{
    UserReadDto Register(RegisterDto registerData);
}