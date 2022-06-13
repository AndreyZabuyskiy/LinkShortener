using LinkShortener.BusinessLogic.Dtos.Response;

namespace LinkShortener.BusinessLogic.UseCases;

public interface IHistory
{
    List<UrlDto> GetHistory(Guid userId);
}