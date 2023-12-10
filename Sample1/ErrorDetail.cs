using System.Net;

namespace Sample1;

/// <summary>
/// 
/// </summary>
public class ErrorDetail
{
    public ErrorDetail(Exception exception)
    {

    }

    public ErrorDetail(HttpStatusCode statusCode, string? reasonPhrase, string? content)
    {

    }
    //TODO: Add more properties here, like error code, etc.
}