namespace Catalog.API.CatalogItems;

[ApiController]
[Route("api/v1/catalog-items")]
public class CatalogItemsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CatalogItemsResponse>> GetAllAsync(
        [FromQuery] string? brand, 
        [FromQuery] string? category, 
        CancellationToken cancellationToken)
    {
        var query = new GetCatalogItemsQuery(brand, category);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.Items.ToResponseList();
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}", Name = "GetCatalogItemById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CatalogItemResponse>> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCatalogItemByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.Item.ToResponse();
        
        return Ok(response);
    }
    
    [HttpGet("title/{title}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CatalogItemResponse>> GetByTitleAsync([FromRoute] string title, CancellationToken cancellationToken)
    {
        var query = new GetCatalogItemByTitleQuery(title);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.Item.ToResponse();
        
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateAsync([FromBody] CreateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateCatalogItemCommand(request.ToCreateDto());
        var result = await mediator.Send(command, cancellationToken);
        
        return CreatedAtRoute("GetCatalogItemById", new { id = result.Id }, null);
    }
    
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateCatalogItemCommand(id, request.ToUpdateDto());
        await mediator.Send(command, cancellationToken);

        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemoveAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveCatalogItemCommand(id);
        await mediator.Send(command, cancellationToken);

        return NoContent();
    }
}