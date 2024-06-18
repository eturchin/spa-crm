namespace SpaCRM.Interfaces;

public interface IResponse
{
    public string Message { get; init; }
    
    public int StatusCode { get; init; }
}