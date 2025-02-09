using System.Net;

namespace GPI.Presentation.Models.ApiResponses;

public class BadRequestApiServiceResponse<T> : BaseApiResponse<T>
{
    public BadRequestApiServiceResponse(T data, string message)
        : base(data, message)
    {
        Success = false;
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
}