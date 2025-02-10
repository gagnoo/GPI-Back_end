using System.Net;

namespace GPI.Presentation.Models.ApiResponses;

public class SuccessApiServiceResponse<T> : BaseApiResponse<T>
{
    public SuccessApiServiceResponse(T data, string? message = null)
        : base(data, message)
    {
        Data = data;
        Success = true;
        StatusCode = (int)HttpStatusCode.OK;
    }
}