namespace Catalog.API.Categories;

[ApiController]
[Route("api/v1/categories")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CategoriesResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCategoriesQuery(), cancellationToken);
        var response = result.Categories.ToResponseList();
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}", Name = "GetCategoryById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponse>> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.Category.ToResponse();
        
        return Ok(response);
    }
    
    [HttpGet("name/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponse>> GetByNameAsync([FromRoute] string name, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByNameQuery(name);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.Category.ToResponse();
        
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateAsync([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(request.ToCreateDto());
        var result = await mediator.Send(command, cancellationToken);
        
        return CreatedAtRoute("GetCategoryById", new { id = result.Id  }, null);
    }
    
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateCategoryCommand(id, request.ToUpdateDto());
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemoveAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveCategoryCommand(id);
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
}