using System.Collections.Generic;

namespace Core.Response
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public List<CustomeValidationError> ValidationErrors { get; set; }
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }
        public Response(ResponseType responseType, T data, List<CustomeValidationError> validationErrors) : base(responseType)
        {
            Data = data;
            ValidationErrors = validationErrors;
        }
        public Response(ResponseType responseType, string message):base(responseType,message)
        {

        }

    }
}
