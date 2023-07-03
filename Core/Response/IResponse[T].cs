using System.Collections.Generic;

namespace Core.Response
{
    public interface IResponse<T> : IResponse
    {
        public T Data { get; set; }
        public List<CustomeValidationError> ValidationErrors { get; set; }
    }
}
