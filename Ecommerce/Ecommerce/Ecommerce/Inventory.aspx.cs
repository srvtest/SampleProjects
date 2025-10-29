using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetInventory();
                EnableDisableRepeater();
                //frmInventory.Style.Add("display", "none");
            }
        }

        private void GetInventory()
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllProductsForInventory();
            lstInventory.DataSource = ds.Tables[0];
            lstInventory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {           
            InventoryCls objInventory = new InventoryCls();
            List<InventoryCls> InvList = new List<InventoryCls>();
            string Rpt = "";
            for (int i = 0; i < lstInventory.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)lstInventory.Items[i].FindControl("chk");
                TextBox  txt = (TextBox)lstInventory.Items[i].FindControl("txtQuantity");
                HiddenField IdProduct = (HiddenField)lstInventory.Items[i].FindControl("hdnIdProduct");
                HiddenField IdInventory = (HiddenField)lstInventory.Items[i].FindControl("hdnIdInventory");
                if (chk.Checked && txt.Text !="")
                {
                    string Qty = txt.Text;
                    Rpt = (IdProduct.Value);
                    //hdInventoryId.Value = IdInventory.Value;
                    InvList.Add(new InventoryCls { idProduct = Convert.ToInt16(Rpt),quantity = Convert.ToInt16(Qty)}  );
                }
            }
            AdminDL objAdminCls = new AdminDL();
            int Response = 0;
            if (Convert.ToInt32(hdInventoryId.Value) > 0)
            {
                hdMessage.Value = "Inventory Update |";
                objInventory.idInventory = Convert.ToInt32(hdInventoryId.Value);
                // Response = objAdminCls.UpdateInventory(InvList);
            }
            else
            {
                hdMessage.Value = "Inventory Insert |";
                objInventory.idInventory = 0;
            }
            Response = objAdminCls.InsertInventory(InvList);
            if (Response > 0)
            {
                GetInventory();
                EnableDisableRepeater();
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
               // frmInventory.Style.Add("display", "none");
                //tblAdditionalLink.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        

        protected void lstInventory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRepeater();
        }

        protected void EnableDisableRepeater()
        {
            for (int i = 0; i < lstInventory.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)lstInventory.Items[i].FindControl("chk");
                Repeater lstPrice = (Repeater)lstInventory.Items[i].FindControl("lstInventory");
                TextBox txtQuantity = (TextBox)lstInventory.Items[i].FindControl("txtQuantity");

                if (chk.Checked == true)
                {
                    txtQuantity.Visible = true;
                }
                else if (chk.Checked == false)
                {
                    txtQuantity.Visible = false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            InventoryCls objInventory = new InventoryCls();
            List<InventoryCls> InvList = new List<InventoryCls>();
            string Rpt = "";
            for (int i = 0; i < lstInventory.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)lstInventory.Items[i].FindControl("chk");
                TextBox txt = (TextBox)lstInventory.Items[i].FindControl("txtQuantity");
                HiddenField IdProduct = (HiddenField)lstInventory.Items[i].FindControl("hdnIdProduct");
                HiddenField IdInventory = (HiddenField)lstInventory.Items[i].FindControl("hdnIdInventory");
                if (chk.Checked && txt.Text != "" && IdInventory.Value != "" && IdProduct.Value != "")
                {
                    string Qty = txt.Text;
                    Rpt = (IdProduct.Value);
                    hdInventoryId.Value = IdInventory.Value;
                    InvList.Add(new InventoryCls { idInventory = Convert.ToInt16(IdInventory.Value), idProduct = Convert.ToInt16(Rpt), quantity = Convert.ToInt16(Qty) });
                }
            }
            AdminDL objAdminCls = new AdminDL();
            int Response = 0;
            if (Convert.ToInt32(hdInventoryId.Value) > 0)
            {
                hdMessage.Value = "Inventory Update |";
                objInventory.idInventory = Convert.ToInt32(hdInventoryId.Value);
               
            }
            //else
            //{
            //    hdMessage.Value = "Inventory Insert |";
            //    objInventory.idInventory = 0;
            //    //Response = objAdminCls.InsertInventory(InvList);
            //}
            Response = objAdminCls.UpdateInventory(InvList);
            if (Response > 0)
            {
                GetInventory();
                EnableDisableRepeater();
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                // frmInventory.Style.Add("display", "none");
                //tblAdditionalLink.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }
    }
}