using illumiyaFramework.Requests;
using illumiyaModels.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaConnectorEntities.Subjects.Requests
{
    public class CheckSubjectExistsRequest 
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
