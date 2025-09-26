namespace Catalog.Application.Domains.CatalogItems.Commands.UpdateCatalogItem;

public sealed partial record UpdateCatalogItemCommand(
    Guid Id,
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price) : IRequest<OneOf<UpdateCatalogItemCommand.Results.SuccessResult, UpdateCatalogItemCommand.Results.FailResult>>;