using System.Net;

namespace GPI.Presentation.Models.ApiResponses;

public class SuccessApiServiceResponse<T> : BaseApiResponse<T>
{
    public SuccessApiServiceResponse(T data)
        : base(data)
    {
        Data = data;
        Success = true;
        StatusCode = (int)HttpStatusCode.OK;
    }
}