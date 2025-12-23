namespace Catalog.API.CatalogItems;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItem")]
public class CatalogItemV2Controller : ControllerBase
{
    /*[HttpGet]
    [ProducesResponseType(typeof(GetPaginationCatalogItemsResponse), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] {"CatalogItemControllerV2"})]
    public async Task<ActionResult<GetPaginationCatalogItemsResponse>> GetAll([FromQuery] QueryArgs args, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetPaginationCatalogItemsQuery(args), cancellationToken);

        return Ok(response);
    }*/
}