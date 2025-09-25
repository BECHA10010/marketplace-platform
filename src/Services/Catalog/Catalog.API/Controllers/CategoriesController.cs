namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetCategoriesResult>> GetCategories()
    {
        var result = await mediator.Send(new GetCategoriesQuery());
        
        return Ok(result);
    }
}