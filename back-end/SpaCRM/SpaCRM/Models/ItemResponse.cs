using SpaCRM.Interfaces;

namespace SpaCRM.Models;

public class ItemResponse<T> : IResponse
{
    public string Message { get; init; }
    
    public int StatusCode { get; init; }
    
    public T Item { get; init; }
}