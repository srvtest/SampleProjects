using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entity
{
    [Serializable]
    public class GuestDetailDto
    {
        public int idGuestDetail { get; set; }
        public int idGuest { get; set; }
        public string sName { get; set; }
        public string IdentificationNo { get; set; }
        public string IdentificationNoTemp { get; set; }
        public string IdentificationType { get; set; }
        public string Image { get; set; }
        public string gender { get; set; }
        public string filePass { get; set; }
        public string LastName { get; set; }
        public string Image2 { get; set; }
        public string ContactNo { get; set; }
        public string ContactNoTemp { get; set; }
        public int isDelete { get; set; }
       
        public GuestDetailDto()
        { }
        public GuestDetailDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idGuestDetail") && !Convert.IsDBNull(dr["idGuestDetail"]))
                this.idGuestDetail = Convert.ToInt32(dr["idGuestDetail"]);

            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.sName = Convert.ToString(dr["sName"]);

            if (dr.Table.Columns.Contains("idGuest") && !Convert.IsDBNull(dr["idGuest"]))
                this.idGuest = Convert.ToInt32(dr["idGuest"]);

            if (dr.Table.Columns.Contains("IdentificationNo") && !Convert.IsDBNull(dr["IdentificationNo"]))
                this.IdentificationNo = Convert.ToString(dr["IdentificationNo"]);

            if (dr.Table.Columns.Contains("IdentificationType") && !Convert.IsDBNull(dr["IdentificationType"]))
                this.IdentificationType = Convert.ToString(dr["IdentificationType"]);

            if (dr.Table.Columns.Contains("Image") && !Convert.IsDBNull(dr["Image"]))
                this.Image = Convert.ToString(dr["Image"]);

            if (dr.Table.Columns.Contains("gender") && !Convert.IsDBNull(dr["gender"]))
                this.gender = Convert.ToString(dr["gender"]);

            if (dr.Table.Columns.Contains("filePass") && !Convert.IsDBNull(dr["FilePfilePassass"]))
                this.filePass = Convert.ToString(dr["filePass"]);

            if (dr.Table.Columns.Contains("LastName") && !Convert.IsDBNull(dr["LastName"]))
                this.LastName = Convert.ToString(dr["LastName"]);

            if (dr.Table.Columns.Contains("Image2") && !Convert.IsDBNull(dr["Image2"]))
                this.Image2 = Convert.ToString(dr["Image2"]);
            
            if (dr.Table.Columns.Contains("ContactNo") && !Convert.IsDBNull(dr["ContactNo"]))
                this.ContactNo = Convert.ToString(dr["ContactNo"]);
        }
    }
}
