
using illumiyaModels.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace illumiyaModels.Subjects
{
    public class Subject : BaseModel
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Country Country { get; set; }
    }
}
