using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class AppSetting
    {
        public int Id { get; set; }
        public string AppKey { get; set; }
        public string AppValue { get; set; }

        public AppSetting()
        {

        }

        public AppSetting(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("AppKey") && !Convert.IsDBNull(dr["AppKey"]))
                this.AppKey = Convert.ToString(dr["AppKey"]);

            if (dr.Table.Columns.Contains("AppValue") && !Convert.IsDBNull(dr["AppValue"]))
                this.AppValue = Convert.ToString(dr["AppValue"]);
        }
    }
}
