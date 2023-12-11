using Microsoft.AspNetCore.Mvc;

namespace Sample1.Library.Result;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="result"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static Result<TResult> AddError<TResult>(this Result<TResult> result, ErrorDetail error)
    {
        result.Errors.Add(error);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Result<TResult> ToResult<TResult>(this TResult value)
    {
        return new Result<TResult>(value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Result<TResult?> ToNullableResult<TResult>(this TResult? value)
    {
        return new Result<TResult?>(value);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="exception"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Result<TResult> ToResult<TResult>(this Exception exception)
    {
        var error = new ErrorDetail(exception);
        return new Result<TResult>(error);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static Result ToResult(this Exception exception)
    {
        var error = new ErrorDetail(exception);
        return new Result(error);
    }
}