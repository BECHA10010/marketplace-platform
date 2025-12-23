namespace Catalog.API.Categories;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CategoriesResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCategoriesQuery(), cancellationToken);
        var response = result.Categories.ToResponseList();
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryResponse>> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.Category.ToResponse();
        
        return Ok(response);
    }
    
    [HttpGet("name/{name}")]
    public async Task<ActionResult<CategoryResponse>> GetByNameAsync([FromRoute] string name, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByNameQuery(name);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.Category.ToResponse();
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(request.ToCreateDto());
        var result = await mediator.Send(command, cancellationToken);
        
        return CreatedAtRoute(nameof(GetByIdAsync), new { id = result.Id  }, null);
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateCategoryCommand(id, request.ToUpdateDto());
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult> RemoveAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveCategoryCommand(id);
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
}