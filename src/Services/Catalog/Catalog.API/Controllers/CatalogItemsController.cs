using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Specifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogItemsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetCatalogItemsResult>> GetAll([FromQuery] QueryArgs args)
    {
        var result = await mediator.Send(new GetCatalogItemsQuery(args));
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetById(Guid id)
    {
        var result = await mediator.Send(new GetCatalogItemByIdQuery(id));
        
        return Ok(result);
    }
    
    [HttpGet("title/{itemTitle}")]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetByTitle(string itemTitle)
    {
        var result = await mediator.Send(new GetCatalogItemByTitleQuery(itemTitle));
        
        return Ok(result);
    }
    
    [HttpGet("brand/{brandTitle}")]
    public async Task<ActionResult<GetCatalogItemsByBrandResult>> GetByBrand(string brandTitle)
    {
        var result = await mediator.Send(new GetCatalogItemsByBrandQuery(brandTitle));
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateCatalogItemResult>> CreateItem([FromBody] CreateCatalogItemCommand command)
    {
        var result = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
    
    [HttpPut]
    public async Task<ActionResult<UpdateCatalogItemResult>> UpdateItem([FromBody] UpdateCatalogItemCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<DeleteCatalogItemByIdResult>> UpdateItem(Guid id)
    {
        var result = await mediator.Send(new DeleteCatalogItemByIdCommand(id));

        return Ok(result);
    }
}