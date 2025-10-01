namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogItemsController(IMediator mediator) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryArgs args, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemsQuery(args), cancellationToken);
        
        return result.Match(
            success => Ok(success.Pagination),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemByIdQuery(id), cancellationToken);
        
        return result.Match(
            success => Ok(success.Item),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }
    
    [HttpGet("title/{itemTitle}")]
    public async Task<IActionResult> GetByTitle(string itemTitle, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemByTitleQuery(itemTitle), cancellationToken);
        
        return result.Match(
            success => Ok(success.Item),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }
    
    [HttpGet("brand/{brandTitle}")]
    public async Task<IActionResult> GetByBrand(string brandTitle, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemsByBrandQuery(brandTitle), cancellationToken);
        
        return result.Match(
            success => Ok(success.Items),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match(
            success => CreatedAtAction(nameof(GetById), new { id = success.Id }, success.Id),
            fail => fail.Code switch
            {
                ApplicationErrors.AlreadyExist => Conflict(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match(
            success => Ok(success.UpdatedItem),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteCatalogItemByIdCommand(id), cancellationToken);

        return result.Match(
            success => NoContent(),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }
}