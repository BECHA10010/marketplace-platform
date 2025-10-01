namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController(IMediator mediator) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
        var result = await mediator.Send(new GetBrandsQuery());

        return result.Match(
            success => Ok(success.Brands),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            }
        );
    }
}