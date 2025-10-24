using Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemsV2;

namespace Catalog.API.Controllers.v2;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItem")]
public class CatalogItemControllerV2 : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResponseV2), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] {"CatalogItemControllerV2"})]
    public async Task<ActionResult<GetCatalogItemsResponseV2>> GetAll([FromQuery] QueryArgs args, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCatalogItemsQueryV2(args), cancellationToken);

        return Ok(response);
    }
}