using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;

namespace Ecommerce
{
    public partial class Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllConfig();
                frmConfig.Style.Add("display", "none");
                tblConfig.Style.Add("display", "flex");
            }

        }
        private void GetAllConfig()
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Config |";
            DataSet ds = objAdminCls.GetAllConfig();
            lstConfig.DataSource = ds.Tables[0];
            lstConfig.DataBind();
           // resetControl();
        }

        protected void btnConfig_Click(object sender, EventArgs e)
        {
            //GetAllProductForPrice();
            resetControl();
            frmConfig.Style.Add("display", "flex");
            tblConfig.Style.Add("display", "none");
        }

        protected void lstConfig_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //Label lblsName = e.Item.FindControl("lblsName") as Label;         
            hdMessage.Value = "Edit Product Price";
           // lblMess.Text = hdMessage.Value;
            Label lblName = e.Item.FindControl("lblName") as Label;
            Label lblValue = e.Item.FindControl("lblValue") as Label;
            Label lblstatus = e.Item.FindControl("LblStatus") as Label;
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            HiddenField hdnName = e.Item.FindControl("hdnName") as HiddenField;
            hdConfigId.Value = hdn.Value;
            if (!string.IsNullOrEmpty(lblName.Text))
            {
                if (e.CommandName == "CatEdit")
                {
                    AdminDL objAdminCls = new AdminDL();
                    DataSet ds = objAdminCls.GetConfig(Convert.ToInt32(hdConfigId.Value));
                    ConfigCls objConfig = new ConfigCls();
                    objConfig.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
                    txtName.Text = lblName.Text;
                    txtValue.Text = lblValue.Text;
                    chkStatus.Checked = objConfig.bStatus == 1 ? true : false;
                    //chkStatus.Checked = (lblstatus.Text.ToUpper() == "ACTIVE");
                    frmConfig.Style.Add("display", "flex");
                    tblConfig.Style.Add("display", "none");
                   // tblProduct.Style.Add("display", "none");
                }
                else if (e.CommandName == "CatDelete")
                {
                    DeleteConfig(Convert.ToInt32(hdConfigId.Value));
                }
            }
        }

        private void DeleteConfig(int idConfig)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Category Delete |";
            int Response = objAdminCls.DeleteConfig(idConfig);
            if (Response > 0)
            {
                GetAllConfig();
                hdMessage.Value += "Category Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmConfig.Style.Add("display", "none");
                tblConfig.Style.Add("display", "block");
               // tblProduct.Style.Add("display", "none");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Category not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            ConfigCls objConfig = new ConfigCls();
            if (Convert.ToInt32(hdConfigId.Value) > 0)
            {
                hdMessage.Value = "Product Price Update |";
                objConfig.idConfig = Convert.ToInt32(hdConfigId.Value);
                objConfig.bStatus = (Int16)(chkStatus.Checked ? 1 : 0);
                //  objConfig.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Product Price Insert |";
                 objConfig.idConfig = 0;
                //  objConfig.Createdby = Convert.ToInt32(Session["UserId"]);
            }

            objConfig.idConfig = Convert.ToInt32(hdConfigId.Value);
            objConfig.bStatus = (Int16)(chkStatus.Checked ? 1 : 0);
            objConfig.sName = Convert.ToString(txtName.Text);
            objConfig.sValue = Convert.ToString(txtValue.Text);
            int Response = objAdminCls.InsertUpdateConfig(objConfig);
            if (Response > 0)
            {
                //GetAllProductForPrice();
                //ClearControl();
                GetAllConfig();
                // chkCountryStatus.Checked = objProductPrice.bStatus == 1 ? true : false;
                hdMessage.Value += "Data saved successfully";
                //DataSet ds = objAdminCls.GetAllProductForPriceList(objProductPrice.idProduct);
                //ProductPriceCls Productprice = new ProductPriceCls();
                //Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
                //DataSet ds = objAdminCls.GetProductId(objProductPrice.idProduct);
                //ProductPriceCls Productprice = new ProductPriceCls();
                //Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmConfig.Style.Add("display", "none");
                tblConfig.Style.Add("display", "flex");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because product price already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmConfig.Style.Add("display", "none");
            tblConfig.Style.Add("display", "flex");
        }

        private void resetControl()
        {
            txtName.Text = "";
            txtValue.Text = "";
            //chkStatus.Checked = false;
            hdConfigId.Value = "0";
            frmConfig.Style.Add("display", "none");
            tblConfig.Style.Add("display", "flex");
        }

        private void GetConfig(int Id)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Blog Edit |";
            DataSet ds = objAdminCls.GetConfig(Id);
            lstConfig.DataSource = ds.Tables[0];
            lstConfig.DataBind();
            resetControl();
        }
    }
}