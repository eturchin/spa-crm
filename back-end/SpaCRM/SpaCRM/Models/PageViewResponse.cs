using SpaCRM.Interfaces;

namespace SpaCRM.Models;

public class PageViewResponse<T> : IResponse
{
    public string Message { get; init; }
    
    public int StatusCode { get; init; }
    
    public List<T> Elements { get; init; }
    
    public int Count { get; init; }
}