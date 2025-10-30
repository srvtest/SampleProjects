using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaConnectorEntities.Subjects.Responses
{
    public class DeleteSubjectResponse : BaseResponse
    {
        public bool IsDeleted { get; set; }
    }
}
