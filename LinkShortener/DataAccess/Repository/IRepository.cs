using LinkShortener.DataAccess.Entities.Request;
using LinkShortener.DataAccess.Entities.Response;

namespace DataAccess.Repository;

public interface IRepository
{
    UserReadModel CreateUser(UserCreateModel userModel);
    UserLoginModel GetByLogin(string login);
    UserReadModel GetById(Guid id);
    bool SaveUrl(UrlSaveModel model);
    List<UrlModel> GetHistory(Guid userId);
    bool DeleteUrl(Guid id);
}