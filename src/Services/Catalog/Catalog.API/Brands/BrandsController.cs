namespace Catalog.API.Brands;

[ApiController]
[Route("api/v1/brands")]
public class BrandsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BrandsResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBrandsQuery(), cancellationToken);
        var response = result.Brands.ToResponseList();
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}", Name = "GetBrandById")]
    public async Task<ActionResult<BrandResponse>> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetBrandByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.BrandDto.ToResponse();
        
        return Ok(response);
    }
    
    [HttpGet("name/{name}")]
    public async Task<ActionResult<BrandResponse>> GetByNameAsync([FromRoute] string name, CancellationToken cancellationToken)
    {
        var query = new GetBrandByNameQuery(name);
        var result = await mediator.Send(query, cancellationToken);
        var response = result.BrandDto.ToResponse();
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CreateBrandRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateBrandCommand(request.ToCreateDto());
        var result = await mediator.Send(command, cancellationToken);
        
        return CreatedAtRoute("GetBrandById", new { id = result.Id  }, null);
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateBrandRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateBrandCommand(id, request.ToUpdateDto());
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> RemoveAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveBrandCommand(id);
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
}