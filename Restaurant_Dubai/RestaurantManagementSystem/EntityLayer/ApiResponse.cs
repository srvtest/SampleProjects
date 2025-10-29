using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntityLayer
{

    [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        public ApiResponse() { }
        public ApiResponse(int statusCode, object result = null, string errorMessage = null)
        {
            StatusCode = statusCode;
            Result = result;
            Message = errorMessage;
        }
    }

}
