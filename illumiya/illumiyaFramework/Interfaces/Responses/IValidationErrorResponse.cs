using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Interfaces.Responses
{
    public interface IValidationErrorResponse
    {
        List<ValidationErrorData> ValidationErrors { get; set; }
    }
}
