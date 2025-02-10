namespace GPI.Presentation.Models.ApiResponses;

public abstract class BaseApiResponse<T>(T data, string? message = null)
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T Data { get; set; } = data;
}