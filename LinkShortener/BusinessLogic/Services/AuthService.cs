using BusinessLogic.UseCases;
using DataAccess.Repository;

namespace BusinessLogic.Services;

public class AuthService : IRegisterUser
{
    private readonly IRepository _repository;

    public AuthService(IRepository repository)
    {
        _repository = repository;
    }

    public void Register()
    {
        throw new NotImplementedException();
    }
}
