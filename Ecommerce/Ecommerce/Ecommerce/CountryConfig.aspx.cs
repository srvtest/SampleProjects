using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class CountryConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox.DisabledCssClass = null;
            if (!IsPostBack)
            {
                GetAllConfig();
                //EnableDisableRepeater();
                //resetControl();
                //GetCountry();
                // GetAllConfigForDD();
                //frmCountryConfig.Style.Add("display", "none");
                // tblCountryConfig.Style.Add("display", "none");
            }
        }

        private void resetControl()
        {
            for (int i = 0; i < lstConfig.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)lstConfig.Items[i].FindControl("chkbox");
                chk.Checked = false;
            }
        }

        private void GetAllConfig()
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllCountryforConfig();
            lstConfig.DataSource = ds.Tables[0];
            lstConfig.DataBind();
            // resetControl();
        }

        private void GetCountryConfig(int idConfig)
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllConfigForCountryConfigList(idConfig);
        }

        protected void lstConfig_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataSet ds = new DataSet();
                string Id = (e.Item.FindControl("hdnId") as HiddenField).Value;
                //string IdCC = (e.Item.FindControl("hdnIdCountryConfig") as HiddenField).Value;
                Repeater lstCountryConfig = e.Item.FindControl("lstCountryConfig") as Repeater;
                AdminDL objAdminCls = new AdminDL();
                ds = objAdminCls.GetAllCountryConfiglist(Convert.ToInt16(Id));
                lstCountryConfig.DataSource = ds.Tables[0];
                lstCountryConfig.DataBind();
            }
        }

        protected void lstCountryConfig_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //AdminDL objAdminCls = new AdminDL();
                //string Id = (e.Item.FindControl("hdId") as HiddenField).Value;
                //Repeater lstCountryConfigList = e.Item.FindControl("lstCountryConfigList") as Repeater;
                //DataSet ds = objAdminCls.GetAllCountryConfiglist(Convert.ToInt16(Id));
                //lstCountryConfigList.DataSource = ds.Tables[0];
                //lstCountryConfigList.DataBind();
                Label Country = e.Item.FindControl("lblCountry") as Label;
                TextBox txtValue = e.Item.FindControl("txtValue") as TextBox;
                HiddenField IdCountry = e.Item.FindControl("hdCountry") as HiddenField;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            CountryConfigCls objCountryConfig = new CountryConfigCls();
            List<CountryConfigCls> lstCountry = new List<CountryConfigCls>();
            string Rpt = "";
            for (int i = 0; i < lstConfig.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)lstConfig.Items[i].FindControl("chkbox");
                Repeater lstCountryConfig = (Repeater)lstConfig.Items[i].FindControl("lstCountryConfig");
                HiddenField IdConfig = (HiddenField)lstConfig.Items[i].FindControl("hdnId");
                HiddenField hdIdCountryConfig = (HiddenField)lstConfig.Items[i].FindControl("hdnIdCountryConfig");
                for (int a = 0; a < lstCountryConfig.Items.Count; a++)
                {
                    //HiddenField Id = (HiddenField)lstCountryConfig.Items[a].FindControl("hdId");
                    //Repeater lstCountryConfigList = (Repeater)lstCountryConfig.Items[a].FindControl("lstCountryConfigList");
                    //for (int b = 0; b < lstCountryConfigList.Items.Count; b++)
                    //{
                        Label Country = (Label)lstCountryConfig.Items[a].FindControl("lblCountry");
                        HiddenField IdCountry = (HiddenField)lstCountryConfig.Items[a].FindControl("hdCountry");
                        //DropDownList Country = (DropDownList)lstCountryConfigList.Items[b].FindControl("ddCountry");
                        TextBox txtValue = (TextBox)lstCountryConfig.Items[a].FindControl("txtValue");
                        if (chk.Checked && Country.Text != "" && txtValue.Text != "" && IdCountry.Value != "")
                        {
                            string sCountry = IdCountry.Value;
                            string value = txtValue.Text;
                            Rpt = (IdConfig.Value);
                            //string status =
                            lstCountry.Add(new CountryConfigCls
                            {
                                idConfig = Convert.ToInt16(Rpt),
                                idCountry = Convert.ToInt16(sCountry),
                                sValue = value
                            });
                        }
                    //}

                }
            }
            if (Convert.ToInt32(hdIdCountryConfig.Value) > 0)
            {
                hdMessage.Value = "Country Config Update |";
                //objProductPrice.idProductPrice = Convert.ToInt32(hdIdProductPrice.Value);
                //objProductPrice.bStatus = (Int16)(chkCountryStatus.Checked ? 1 : 0);
                //objProductPrice.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Country Config Insert |";
                objCountryConfig.idCountryConfig = 0;
                //objCountryConfig.Createdby = Convert.ToInt32(Session["UserId"]);
            }
            int Response = objAdminCls.InsertCountryConfig(lstCountry);
            if (Response > 0)
            {
                GetCountryConfig(Convert.ToInt16(Rpt));
                resetControl();
                //EnableDisableRepeater();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                // frmProductPrice.Style.Add("display", "none");
                //tblProductPrice.Style.Add("display", "none");
                //tblProduct.Style.Add("display", "flex");
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

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
          //  EnableDisableRepeater();
        }

        protected void EnableDisableRepeater()
        {
            for (int i = 0; i < lstConfig.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)lstConfig.Items[i].FindControl("chk");
                Repeater lstCountryConfig = (Repeater)lstConfig.Items[i].FindControl("lstCountryConfig");

                if (chk.Checked == true)
                {
                    lstCountryConfig.Visible = true;
                }
                else if (chk.Checked == false)
                {
                    lstCountryConfig.Visible = false;
                }
            }
        }

        //protected void lstCountryConfigList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {      
        //        Label Country = e.Item.FindControl("lblCountry") as Label;
        //        TextBox txtValue = e.Item.FindControl("txtValue") as TextBox;
        //        HiddenField IdCountry = e.Item.FindControl("hdCountry") as HiddenField;
        //    }
        //}

        

        //private void GetCountry()
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    DataSet ds = objAdminCls.GetAllCountry();
        //    ddCountry.DataSource = ds.Tables[0];
        //    ddCountry.DataTextField = "sName";
        //    ddCountry.DataValueField = "idCountry";
        //    ddCountry.DataBind();
        //}

        //private void GetAllConfigForDD()
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    DataSet ds = objAdminCls.GetAllConfigForDD();
        //    ddConfigList.DataSource = ds.Tables[0];
        //    ddConfigList.DataTextField = "sName";
        //    ddConfigList.DataValueField = "idConfig";
        //    ddConfigList.DataBind();
        //}

        //private void DeleteCountryConfig(int idCountryConfig)
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    hdMessage.Value = "Category Delete |";
        //    int Response = objAdminCls.DeleteCountryConfig(idCountryConfig);
        //    if (Response > 0)
        //    {
        //        GetAllConfig();
        //        hdMessage.Value += "Category Delete successfully";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        //        frmCountryConfig.Style.Add("display", "none");
        //        tblConfig.Style.Add("display", "block");
        //        tblCountryConfig.Style.Add("display", "none");
        //    }
        //    else if (Response == 0)
        //    {
        //        hdMessage.Value += "Category not exists.";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //}

        //protected void btnConfig_Click(object sender, EventArgs e)
        //{
        //    hdMessage.Value = "Add Country Config";
        //    lblMess.Text = hdMessage.Value;
        //    GetAllConfig();
        //    resetControl();
        //    txtValue.Text = "";
        //    frmCountryConfig.Style.Add("display", "flex");
        //    tblConfig.Style.Add("display", "none");
        //    tblCountryConfig.Style.Add("display", "none");
        //}

        //protected void lstConfig_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{

        //    Label lblsName = e.Item.FindControl("lblsName") as Label;
        //    Label lblstatus = e.Item.FindControl("lblStatus") as Label;
        //    HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
        //    HiddenField hdnName = e.Item.FindControl("hdnName") as HiddenField;
        //    hdIdConfig.Value = hdn.Value;
        //    lblConfigName.Text = hdnName.Value;
        //    if (!string.IsNullOrEmpty(lblsName.Text))
        //    {
        //        if (e.CommandName == "CatEdit")
        //        {
        //            hdMessage.Value = "Country Config List";
        //            lblMessage.Text = hdMessage.Value;
        //            GetCountryConfig(Convert.ToInt32(hdIdConfig.Value));
        //            //hdMessage.Value = "Product Price List";
        //            lblMessage.Text = hdMessage.Value;
        //            frmCountryConfig.Style.Add("display", "none");
        //            tblConfig.Style.Add("display", "none");
        //            tblCountryConfig.Style.Add("display", "flex");
        //        }
        //        else if (e.CommandName == "CatDelete")
        //        {
        //            //DeleteCountryConfig(Convert.ToInt32(hdIdConfig.Value));
        //        }

        //    }
        //}

        //protected void lstCountryConfig_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    Label lblCountry = e.Item.FindControl("lblCountry") as Label;
        //    Label lblValue = e.Item.FindControl("lblValue") as Label;
        //    HiddenField hdn = e.Item.FindControl("hdnIdCountryConfig") as HiddenField;
        //    HiddenField hdnName = e.Item.FindControl("hdnName") as HiddenField;
        //    hdIdCountryConfig.Value = hdn.Value;
        //    if (!string.IsNullOrEmpty(lblCountry.Text))
        //    {
        //        if (e.CommandName == "CatEdit")
        //        {
        //            hdMessage.Value = "Edit Country Config";
        //            lblMess.Text = hdMessage.Value;
        //            AdminDL objAdminCls = new AdminDL();
        //            DataSet ds = objAdminCls.GetCountryConfig(Convert.ToInt32(hdIdConfig.Value));
        //            //ProductPriceCls Productprice = new ProductPriceCls();
        //            //Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
        //            txtValue.Text = lblValue.Text;
        //            frmCountryConfig.Style.Add("display", "flex");
        //            tblConfig.Style.Add("display", "none");
        //            tblCountryConfig.Style.Add("display", "none");
        //        }
        //        else if (e.CommandName == "CatDelete")
        //        {
        //            DeleteCountryConfig(Convert.ToInt32(hdIdConfig.Value));
        //        }
        //    }
        //}

        //protected void btnAddCountryConfig_Click(object sender, EventArgs e)
        //{
        //   // GetAllProductForPrice();
        //    resetControl();
        //    hdMessage.Value = "Add Country Config";
        //    lblMess.Text = hdMessage.Value;
        //    txtValue.Text = "";
        //    frmCountryConfig.Style.Add("display", "flex");
        //    tblConfig.Style.Add("display", "none");
        //    tblCountryConfig.Style.Add("display", "none");
        //}

        //protected void btnCancelCountryConfig_Click(object sender, EventArgs e)
        //{
        //    frmCountryConfig.Style.Add("display", "none");
        //    tblConfig.Style.Add("display", "flex");
        //    tblCountryConfig.Style.Add("display", "none");
        //}

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    CountryConfigCls objCountryConfig = new CountryConfigCls();
        //    if (Convert.ToInt32(hdIdCountryConfig.Value) > 0)
        //    {
        //        hdMessage.Value = "Product Price Update |";
        //        objCountryConfig.idCountryConfig = Convert.ToInt32(hdIdCountryConfig.Value);
        //        //objCountryConfig.bStatus = (Int16)(chkCountryStatus.Checked ? 1 : 0);
        //       // objCountryConfig.ModifyBy = Convert.ToInt32(Session["UserId"]);
        //    }
        //    else
        //    {
        //        hdMessage.Value = "Product Price Insert |";
        //        objCountryConfig.idCountryConfig = 0;
        //        //objProductPrice.Createdby = Convert.ToInt32(Session["UserId"]);
        //    }

        //    objCountryConfig.idConfig = Convert.ToInt32(hdIdConfig.Value); 
        //    objCountryConfig.idCountry = Convert.ToInt32(ddCountry.SelectedItem.Value);            
        //    objCountryConfig.sValue = Convert.ToString(txtValue.Text);


        //    int Response = objAdminCls.InsertUpdateCountryConfig(objCountryConfig);
        //    if (Response > 0)
        //    {
        //        //GetAllProductForPrice();
        //        //ClearControl();
        //        GetCountryConfig(objCountryConfig.idConfig);
        //        // chkCountryStatus.Checked = objProductPrice.bStatus == 1 ? true : false;
        //        hdMessage.Value += "Data saved successfully";
        //        //DataSet ds = objAdminCls.GetAllProductForPriceList(objProductPrice.idProduct);
        //        //ProductPriceCls Productprice = new ProductPriceCls();
        //        //Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
        //        //DataSet ds = objAdminCls.GetProductId(objProductPrice.idProduct);
        //        //ProductPriceCls Productprice = new ProductPriceCls();
        //        //Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        //        frmCountryConfig.Style.Add("display", "none");
        //        tblConfig.Style.Add("display", "none");
        //        tblCountryConfig.Style.Add("display", "flex");
        //    }
        //    else if (Response == 0)
        //    {
        //        hdMessage.Value += "Data not saved. Because product price already exists.";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //    else
        //    {

        //        hdMessage.Value += "Data not saved successfully please try again...";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //}

        //protected void btnFrmCancel_Click(object sender, EventArgs e)
        //{
        //    frmCountryConfig.Style.Add("display", "none");
        //    tblConfig.Style.Add("display", "none");
        //    tblCountryConfig.Style.Add("display", "flex");
        //}

        //protected void ddConfigList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    hdIdConfig.Value = ddConfigList.SelectedItem.Value;
        //    lblConfigName.Text = ddConfigList.SelectedItem.Text;
        //}

        //protected void btnSave_Click1(object sender, EventArgs e)
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    CountryConfigCls objCountryConfig = new CountryConfigCls();
        //    List<CountryConfigCls> lstCountry = new List<CountryConfigCls>();
        //    string Rpt = "";
        //    for (int i = 0; i < lstCountryConfig.Items.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)lstCountryConfig.Items[i].FindControl("chk");
        //        HiddenField Country = (HiddenField)lstCountryConfig.Items[i].FindControl("hdCountry");
        //        TextBox Value = (TextBox)lstCountryConfig.Items[i].FindControl("txtValue");
        //        if (chk.Checked && Country.Value != "" && Value.Text != "" )
        //        {

        //            string sCountry = Country.Value;
        //            string value = Value.Text;
        //            Rpt = (chk.Text);
        //            //string status =
        //            lstCountry.Add(new CountryConfigCls
        //            {
        //                idConfig = Convert.ToInt16(Rpt),  
        //                idCountry = Convert.ToInt16(sCountry),
        //                sValue = value
        //            });
        //        }
        //    }
        //    if (Convert.ToInt32(hdIdCountryConfig.Value) > 0)
        //    {
        //        hdMessage.Value = "Product Price Update |";
        //        objCountryConfig.idCountryConfig = Convert.ToInt32(hdIdCountryConfig.Value);
        //        //objCountryConfig.bStatus = (Int16)(chkCountryStatus.Checked ? 1 : 0);
        //        // objCountryConfig.ModifyBy = Convert.ToInt32(Session["UserId"]);
        //    }
        //    else
        //    {
        //        hdMessage.Value = "Product Price Insert |";
        //        objCountryConfig.idCountryConfig = 0;
        //        //objProductPrice.Createdby = Convert.ToInt32(Session["UserId"]);
        //    }
        //    int Response = objAdminCls.InsertCountryConfig(lstCountry);
        //    if (Response > 0)
        //    {
        //        GetCountryConfig(Convert.ToInt16(Rpt));
        //        hdMessage.Value += "Data saved successfully";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        //        frmCountryConfig.Style.Add("display", "none");
        //        tblConfig.Style.Add("display", "none");
        //        tblCountryConfig.Style.Add("display", "flex");
        //    }
        //    else if (Response == 0)
        //    {
        //        hdMessage.Value += "Data not saved. Because product price already exists.";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //    else
        //    {

        //        hdMessage.Value += "Data not saved successfully please try again...";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //}
    }
}