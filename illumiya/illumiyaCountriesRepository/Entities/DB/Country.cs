using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaCountriesRepository.Entities.DB
{
    public class Country
    {
        public int Id { get; set; }
        public string ISO { get; set; }
        public string ISO3 { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string NumCode { get; set; }
        public int PhoneCode { get; set; }
    }
}
