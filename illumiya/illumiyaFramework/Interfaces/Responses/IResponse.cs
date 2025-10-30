using illumiyaFramework.Enums;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Interfaces.Responses
{
    public interface IResponse : IErrorResponse, IValidationErrorResponse
    {
        public HeaderResponse Header { get; set; }
        public EGlobal.ResponseStatus Status { get; set; }
    }
}
