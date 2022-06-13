using LinkShortener.BusinessLogic.Dtos.Request;

namespace LinkShortener.BusinessLogic.UseCases;
public interface ISaveUrl
{
    bool Save(UrlSaveDto data);
}