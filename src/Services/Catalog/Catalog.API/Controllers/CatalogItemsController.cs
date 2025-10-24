namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogItemsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryArgs args, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemsQuery(args), cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemByIdQuery(id), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> GetByTitle(string title, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemByTitleQuery(title), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet("{brand}")]
    public async Task<IActionResult> GetByBrand(string brand, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCatalogItemsByBrandQuery(brand), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateCatalogItemCommand>();
        var result = await mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateCatalogItemCommand>();
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteCatalogItemByIdCommand(id), cancellationToken);

        return Ok(result);
    }
}