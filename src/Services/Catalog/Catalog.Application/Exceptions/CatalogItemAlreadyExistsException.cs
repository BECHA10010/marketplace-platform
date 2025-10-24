namespace Catalog.Application.Exceptions;

public class CatalogItemAlreadyExistsException : AlreadyExistException
{
    public CatalogItemAlreadyExistsException(string title) : base("CatalogItem", title)
    { }
}