namespace Catalog.API.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    [NonAction]
    protected IActionResult BadRequest(string message)
    {
        return new BadRequestObjectResult(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 400, detail: message,
            instance: (string)Request.Path));
    }

    [NonAction]
    protected IActionResult Forbid(string code, string message)
    {
        var problemDetails =
            ProblemDetailsFactory.CreateProblemDetails(HttpContext, 403, detail: message,
                instance: (string)Request.Path);
        problemDetails.Extensions.Add("error", code);

        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    [NonAction]
    protected IActionResult NotFound(string message)
    {
        return new NotFoundObjectResult(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 404, detail: message,
            instance: (string)Request.Path));
    }

    [NonAction]
    protected IActionResult NotFound(string code, string message)
    {
        var problemDetails =
            ProblemDetailsFactory.CreateProblemDetails(HttpContext, 404, detail: message,
                instance: (string)Request.Path);
        problemDetails.Extensions.Add("error", code);

        return new NotFoundObjectResult(problemDetails);
    }

    [NonAction]
    protected IActionResult Conflict(string message)
    {
        return new ConflictObjectResult(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 409, detail: message,
            instance: (string)Request.Path));
    }

    [NonAction]
    protected IActionResult Conflict(string code, string message)
    {
        var problemDetails =
            ProblemDetailsFactory.CreateProblemDetails(HttpContext, 409, detail: message,
                instance: (string)Request.Path);
        problemDetails.Extensions.Add("error", code);

        return new ConflictObjectResult(problemDetails);
    }

    [NonAction]
    protected IActionResult PreconditionFailed(string message)
    {
        return Problem(message, (string)Request.Path, 412, "Precondition Failed");
    }

    [NonAction]
    protected IActionResult PreconditionFailed(string code, string message)
    {
        var problemDetails = ProblemDetailsFactory.CreateProblemDetails(HttpContext, 412, "Precondition Failed",
            detail: message, instance: (string)Request.Path);
        problemDetails.Extensions.Add("error", code);

        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    [NonAction]
    protected IActionResult UnprocessableEntity(string message)
    {
        return new UnprocessableEntityObjectResult(
            ProblemDetailsFactory.CreateProblemDetails(HttpContext, 422, detail: message,
                instance: (string)Request.Path));
    }

    [NonAction]
    protected IActionResult UnprocessableEntity(string code, string message)
    {
        var problemDetails =
            ProblemDetailsFactory.CreateProblemDetails(HttpContext, 422, detail: message,
                instance: (string)Request.Path);
        problemDetails.Extensions.Add("error", code);

        return new UnprocessableEntityObjectResult(problemDetails);
    }

    [NonAction]
    protected IActionResult InternalServerError(string error)
    {
        return Problem(error, (string)Request.Path, 500, "Internal Server Error");
    }

    [NonAction]
    protected IActionResult InternalServerError()
    {
        return Problem(instance: (string)Request.Path, statusCode: 500, title: "Internal Server Error");
    }
}