namespace Catalog.API.Controllers.v1;

public class BrandsController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetBrandsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetBrands(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetBrandsQuery(), cancellationToken);

        return Ok(result);
    }
}