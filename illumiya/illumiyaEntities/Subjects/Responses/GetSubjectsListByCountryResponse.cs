using illumiyaFramework.Responses;
using illumiyaModels.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaEntities.Subjects.Responses
{
    public class GetSubjectsListByCountryResponse : BaseResponse
    {
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
