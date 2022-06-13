namespace LinkShortener.BusinessLogic.UseCases;

public interface IDeleteUrl
{
    bool DeleteUrl(Guid id);
}