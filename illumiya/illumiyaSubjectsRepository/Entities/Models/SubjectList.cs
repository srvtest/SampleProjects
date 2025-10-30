using illumiyaModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaSubjectsRepository.Entities.Models
{
    public class SubjectList : BaseModel
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
