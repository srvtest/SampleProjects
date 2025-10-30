using illumiyaFramework.Responses;
using illumiyaModels.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaEntities.Subjects.Responses
{
    public class GetSubjectDetailsResponse : BaseResponse
    {
        public Subject SubjectDetails { get; set; }
    }
}
