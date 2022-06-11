using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.Dtos.Response;

namespace LinkShortener.BusinessLogic.UseCases;

public interface ILoginUser
{
    UserReadDto Login(LoginDto loginData);
}
