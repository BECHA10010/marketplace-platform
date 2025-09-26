namespace Catalog.Application.Domains.CatalogItems.Commands.DeleteCatalogItemById;

public sealed partial record DeleteCatalogItemByIdCommand(Guid Id) 
    : IRequest<OneOf<DeleteCatalogItemByIdCommand.Results.SuccessResult, DeleteCatalogItemByIdCommand.Results.FailResult>>;