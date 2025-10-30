using illumiyaModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaSubjectsRepository.Entities.Models
{
    public class Subject : BaseModel
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        
    }
}
