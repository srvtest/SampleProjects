using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaModels
{
    public class BaseModel
    {
        public int? Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
