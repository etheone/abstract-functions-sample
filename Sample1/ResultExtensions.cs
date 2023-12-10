using Microsoft.AspNetCore.Mvc;

namespace Sample1;

public static class ResultExtensions
{
    public static ActionResult<TModel> ToResponse<TModel>(this IValueResult<TModel> result)
    {
        if (result.Success)
            return new OkObjectResult(result.Value);

        //TODO: Handle different error results

        return new BadRequestObjectResult(result.Errors);
    }

    public static IActionResult ToResponse(this IResult result)
    {
        if (result.Success)
            return new NoContentResult();

        //TODO: Handle different error results
        return new BadRequestObjectResult(result.Errors);
    }
}