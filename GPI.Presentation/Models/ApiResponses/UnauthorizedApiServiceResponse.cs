using System.Net;

namespace GPI.Presentation.Models.ApiResponses;

public class UnauthorizedApiServiceResponse<T> : BaseApiResponse<T>
{
    public UnauthorizedApiServiceResponse(T data, string message)
        : base(data, message)
    {
        Success = false;
        StatusCode = (int)HttpStatusCode.Unauthorized;
    }
}