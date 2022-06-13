using DataAccess.Repository;
using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.Dtos.Response;
using LinkShortener.BusinessLogic.UseCases;
using LinkShortener.DataAccess.Entities.Request;

namespace LinkShortener.BusinessLogic.Services;

public class ShortenerUrlService : ISaveUrl, IHistory
{
    private readonly IRepository _repository;

    public ShortenerUrlService(IRepository repository)
    {
        _repository = repository;
    }

    public List<UrlDto> GetHistory(Guid userId)
    {
        var listUrl = _repository.GetHistory(userId);
        var result = new List<UrlDto>();

        foreach (var url in listUrl)
        {
            result.Add(new UrlDto()
            {
                Id = url.Id,
                FullUrl = url.FullUrl,
                ShortUrl = url.ShortUrl
            });
        }

        return result;
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