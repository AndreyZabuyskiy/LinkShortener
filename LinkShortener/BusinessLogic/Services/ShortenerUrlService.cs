using DataAccess.Repository;
using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.UseCases;
using LinkShortener.DataAccess.Entities.Request;

namespace LinkShortener.BusinessLogic.Services;

public class ShortenerUrlService : ISaveUrl
{
    private readonly IRepository _repository;

    public ShortenerUrlService(IRepository repository)
    {
        _repository = repository;
    }

    public bool Save(Guid userId, UrlSaveDto data)
    {
        var model = new UrlSaveModel()
        {
            UserId = userId,
            FullUrl = data.FullUrl,
            ShortUrl = data.ShortUrl
        };

        return _repository.SaveUrl(model);
    }
}