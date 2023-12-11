namespace Sample1.Library.Result;

/// <summary>
/// 
/// </summary>
public interface IResult
{
    /// <summary>
    /// 
    /// </summary>
    bool Success { get; }

    /// <summary>
    /// 
    /// </summary>
    List<ErrorDetail> Errors { get; }
}