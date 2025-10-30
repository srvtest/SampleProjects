using illumiyaFramework.Requests;
using illumiyaModels.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaEntities.Subjects.Requests
{
    public class SaveSubjectDetailsRequest : BaseRequest
    {
        public Subject SubjectDetails { get; set; }
    }
}
