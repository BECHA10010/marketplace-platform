namespace Catalog.API.Controllers.v1;

public class CatalogItemController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResponse>> GetAll(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCatalogItemsQuery(), cancellationToken);
        
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCatalogItemByIdQuery(id), cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet("title/{itemTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemByTitleResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByTitleResponse>> GetByTitle(string itemTitle, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCatalogItemByTitleQuery(itemTitle), cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet("brand/{brandTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsByBrandResponse>> GetByBrand(string brandTitle, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCatalogItemsByBrandQuery(brandTitle), cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateCatalogItemResponse), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<CreateCatalogItemResponse>> Create([FromBody] CreateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateCatalogItemCommand>();
        var response = await Mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(UpdateCatalogItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateCatalogItemResponse>> Update([FromBody] UpdateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateCatalogItemCommand>();
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(DeleteCatalogItemByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteCatalogItemByIdResponse>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new DeleteCatalogItemByIdCommand(id), cancellationToken);

        return Ok(response);
    }
}