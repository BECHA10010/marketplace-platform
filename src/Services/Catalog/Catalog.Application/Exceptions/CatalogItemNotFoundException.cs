namespace Catalog.Application.Exceptions;

public class CatalogItemNotFoundException : NotFoundException
{
    public CatalogItemNotFoundException(Guid id) : base("CatalogItem", id)
    { }
    
    public CatalogItemNotFoundException(string title) : base("CatalogItem", title)
    { }
}