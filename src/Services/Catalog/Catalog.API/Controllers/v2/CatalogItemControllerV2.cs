using Catalog.Application.Features.CatalogItems.Queries.GetPaginationCatalogItems;

namespace Catalog.API.Controllers.v2;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItem")]
public class CatalogItemControllerV2 : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetPaginationCatalogItemsResponse), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] {"CatalogItemControllerV2"})]
    public async Task<ActionResult<GetPaginationCatalogItemsResponse>> GetAll([FromQuery] QueryArgs args, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetPaginationCatalogItemsQuery(args), cancellationToken);

        return Ok(response);
    }
}