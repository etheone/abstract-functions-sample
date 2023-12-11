namespace Sample1.Library.Result;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TResult"></typeparam>
public class Result<TResult> : IValueResult<TResult>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Result(TResult value)
    {
        Value = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error"></param>
    public Result(ErrorDetail error)
    {
        Errors.Add(error);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="errors"></param>
    public Result(List<ErrorDetail> errors)
    {
        Errors.AddRange(errors);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error"></param>
    public void AddError(ErrorDetail error)
    {
        Errors.Add(error);
    }

    /// <summary>
    /// 
    /// </summary>
    public TResult Value { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool Success => Errors.Count == 0;

    /// <summary>
    /// 
    /// </summary>
    public List<ErrorDetail> Errors { get; } = new();
}

/// <summary>
/// 
/// </summary>
public class Result : IResult
{
    /// <summary>
    /// 
    /// </summary>
    public Result()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error"></param>
    public Result(ErrorDetail error)
    {
        Errors.Add(error);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error"></param>
    public void AddError(ErrorDetail error)
    {
        Errors.Add(error);
    }

    /// <summary>
    /// 
    /// </summary>
    public bool Success => Errors.Count == 0;

    /// <summary>
    /// 
    /// </summary>
    public List<ErrorDetail> Errors { get; } = new();
}