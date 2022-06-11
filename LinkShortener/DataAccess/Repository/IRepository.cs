using DataAccess.Entities.Request;
using DataAccess.Entities.Response;

namespace DataAccess.Repository;

public interface IRepository
{
    UserReadModel CreateUser(UserCreateModel userModel);
}