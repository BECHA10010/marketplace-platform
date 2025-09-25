namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrands()
    {
        var result = await mediator.Send(new GetBrandsQuery());
        return Ok(result);
    }
}