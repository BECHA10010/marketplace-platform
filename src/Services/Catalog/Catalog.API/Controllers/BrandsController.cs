namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetBrands(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBrandsQuery(), cancellationToken);

        return Ok(result);
    }
}