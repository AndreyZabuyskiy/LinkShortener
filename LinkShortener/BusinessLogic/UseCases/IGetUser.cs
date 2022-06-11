using LinkShortener.BusinessLogic.Dtos.Response;

namespace LinkShortener.BusinessLogic.UseCases;
public interface IGetUser
{
    UserReadDto GetUser(string jwt);
}
