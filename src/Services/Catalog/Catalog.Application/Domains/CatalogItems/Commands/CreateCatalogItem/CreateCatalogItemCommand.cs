namespace Catalog.Application.Domains.CatalogItems.Commands.CreateCatalogItem;

public sealed partial record CreateCatalogItemCommand(
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price) : IRequest<OneOf<CreateCatalogItemCommand.Results.SuccessResult, CreateCatalogItemCommand.Results.FailResult>>;