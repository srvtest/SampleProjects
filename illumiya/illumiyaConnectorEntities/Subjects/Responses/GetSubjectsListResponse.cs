using illumiyaFramework.Responses;
using illumiyaModels.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaConnectorEntities.Subjects.Responses
{
    public class GetSubjectsListResponse : BaseResponse
    {
        public IEnumerable<Subject> SubjectList { get; set; }
    }
}
