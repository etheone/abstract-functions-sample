namespace Sample1;

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