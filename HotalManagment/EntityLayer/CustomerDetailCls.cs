using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class CustomerDetailCls
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int16 Age { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }

        public CustomerDetailCls()
        {
        }
        public CustomerDetailCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("BookingId") && !Convert.IsDBNull(dr["BookingId"]))
                this.BookingId = Convert.ToInt32(dr["BookingId"]);

            if (dr.Table.Columns.Contains("FirstName") && !Convert.IsDBNull(dr["FirstName"]))
                this.FirstName = Convert.ToString(dr["FirstName"]);

            if (dr.Table.Columns.Contains("LastName") && !Convert.IsDBNull(dr["LastName"]))
                this.LastName = Convert.ToString(dr["LastName"]);

            if (dr.Table.Columns.Contains("PriAgece") && !Convert.IsDBNull(dr["Age"]))
                this.Age = Convert.ToInt16(dr["Age"]);

            if (dr.Table.Columns.Contains("Gender") && !Convert.IsDBNull(dr["Gender"]))
                this.Gender = Convert.ToString(dr["Gender"]);

            if (dr.Table.Columns.Contains("Photo") && !Convert.IsDBNull(dr["Photo"]))
                this.Photo = Convert.ToString(dr["Photo"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                this.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("Creationdate") && !Convert.IsDBNull(dr["Creationdate"]))
                this.CreationDate = Convert.ToDateTime(dr["Creationdate"]);

            if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
                this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);

            if (dr.Table.Columns.Contains("ModificationDate") && !Convert.IsDBNull(dr["ModificationDate"]))
                this.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
        }
    }
}
