using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class CCTransactions
    {
        public string cardNumber { get; set; }
        public decimal amount { get; set; }
        public string tranType { get; set; }
        public string merchantDetail { get; set; }
        public DateTime dateOfTransection { get; set; }
        public string uniqueId { get; set; }
    }

    public class FileData
    {
        public List<CCTransactions> lstTransaction { get; set; }
        public int totalNumberofDrRecord { get; set; }
        public int totalNumberofCrRecord { get; set; }
        public int totalNumberofRecord { get; set; }
    }
}
