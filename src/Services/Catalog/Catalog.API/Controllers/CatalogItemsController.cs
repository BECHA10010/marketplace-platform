namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogItemsController(IMediator mediator) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryArgs args)
    {
        var result = await mediator.Send(new GetCatalogItemsQuery(args));
        
        return result.Match(
            success => Ok(success.Pagination),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Message),
                _ => InternalServerError(fail.Message)
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetCatalogItemByIdQuery(id));
        
        return result.Match(
            success => Ok(success.Item),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Message),
                _ => InternalServerError(fail.Message)
        });
    }
    
    [HttpGet("title/{itemTitle}")]
    public async Task<IActionResult> GetByTitle(string itemTitle)
    {
        var result = await mediator.Send(new GetCatalogItemByTitleQuery(itemTitle));
        
        return result.Match(
            success => Ok(success.Item),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Message),
                _ => InternalServerError(fail.Message)
        });
    }
    
    [HttpGet("brand/{brandTitle}")]
    public async Task<IActionResult> GetByBrand(string brandTitle)
    {
        var result = await mediator.Send(new GetCatalogItemsByBrandQuery(brandTitle));
        
        return result.Match(
            success => Ok(success.Items),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Message),
                _ => InternalServerError(fail.Message)
        });
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCatalogItemCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(
            success => Ok(success.Id),
            fail => fail.Code switch
            {
                ApplicationErrors.AlreadyExist => Conflict(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
        });
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogItemCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(
            success => Ok(success.IsSuccess),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Message),
                _ => InternalServerError(fail.Message)
        });
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteCatalogItemByIdCommand(id));

        return result.Match(
            success => Ok(success.IsSuccess),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Message),
                _ => InternalServerError(fail.Message)
        });
    }
}
/*
 * {
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Not Found",
  "status": 404,
  "detail": "Items not found",
  "instance": "/api/CatalogItems",
  "traceId": "00-2a240fcf44ffb7b4e63def0e3d35a925-152c91aa7731ee3b-00",
  "error": "not_found"
}

{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Not Found",
  "status": 404,
  "detail": "Item with id b0000001-0000-0000-0000-000000000001 not found",
  "instance": "/api/CatalogItems/b0000001-0000-0000-0000-000000000001",
  "traceId": "00-ddcf4fb104aeca24c08282dd6cf6f281-e9fa8155f7ad99b0-00"
}
 */