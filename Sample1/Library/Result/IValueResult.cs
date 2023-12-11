namespace Sample1.Library.Result;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface IValueResult<out TResult> : IResult
{
    /// <summary>
    /// 
    /// </summary>
    TResult Value { get; }
}