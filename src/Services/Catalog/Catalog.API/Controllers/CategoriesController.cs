namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCategoriesQuery(), cancellationToken);

        return result.Match(
            success => Ok(success.Categories),
            fail => fail.Code switch
            {
                ApplicationErrors.NotFound => NotFound(fail.Code, fail.Message),
                _ => InternalServerError(fail.Message)
            });
    }
}