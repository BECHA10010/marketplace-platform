namespace Catalog.API.Controllers.v1;

public class CategoriesController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCategoriesResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCategoriesResponse>> GetCategories(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCategoriesQuery(), cancellationToken);

        return Ok(response);
    }
}