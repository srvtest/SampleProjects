using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class CustomerOrder : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        string AdminUrl = ConfigurationManager.AppSettings["AdminUrl"].ToString();
        string producthtml = string.Empty;
        string status = string.Empty;       
        protected void Page_Load(object sender, EventArgs e)
        {
            // System.Web.UI.WebControls.CheckBox.DisabledCssClass = null;
            if (!IsPostBack)
            {
                GetAllCustomerOrder();
                resetcontrol();
                frmCustomerOrder.Style.Add("display", "none");
                pnlShipping.Style.Add("display", "none");
            }
        }
        private void resetcontrol()
        {
            txtComment.Text = "";
            txtShipping.Text = "";
            txtTrackingNumbers.Text = "";
            chkShipped.Checked = false;
            btnSave.Visible = true;

        }

        private void GetAllCustomerOrder()
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Customer Order |";
            DataSet ds = objAdminCls.GetAllCustomerOrder();
            if (ds != null && ds.Tables.Count > 0)
            {
                lstCustomerOrder.DataSource = ds.Tables[0];
                lstCustomerOrder.DataBind();
            }
            resetcontrol();
        }

        protected void lstCustomerOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            HiddenField hdidCustomer = e.Item.FindControl("hdnidCustomer") as HiddenField;
            HiddenField hdsOrderNo = e.Item.FindControl("hdnsOrderNo") as HiddenField;
            HiddenField hddtOrder = e.Item.FindControl("hdndtOrder") as HiddenField;
            HiddenField hddtApproval = e.Item.FindControl("hdndtApproval") as HiddenField;
            HiddenField hdsName = e.Item.FindControl("hdnsName") as HiddenField;
            HiddenField hdnEmail = e.Item.FindControl("hdnEmail") as HiddenField;
            HiddenField hdMobile = e.Item.FindControl("hdnMobile") as HiddenField;
            HiddenField hdPinCode = e.Item.FindControl("hdnPinCode") as HiddenField;
            HiddenField hdsAddress1 = e.Item.FindControl("hdnsAddress1") as HiddenField;
            HiddenField hdsAddress2 = e.Item.FindControl("hdnsAddress2") as HiddenField;
            HiddenField hdsCity = e.Item.FindControl("hdnsCity") as HiddenField;
            HiddenField hdsState = e.Item.FindControl("hdnsState") as HiddenField;
            HiddenField hdsLandMark = e.Item.FindControl("hdnsLandMark") as HiddenField;
            HiddenField hdAddressType = e.Item.FindControl("hdnAddressType") as HiddenField;
            HiddenField hdAlternateNo = e.Item.FindControl("hdnAlternateNo") as HiddenField;
            HiddenField hdCouponCode = e.Item.FindControl("hdnCouponCode") as HiddenField;
            HiddenField hdbStatus = e.Item.FindControl("hdnbStatus") as HiddenField;
            HiddenField hdApproveReject = e.Item.FindControl("hdnApproveReject") as HiddenField;
            HiddenField hdtotalAmount = e.Item.FindControl("hdntotalAmount") as HiddenField;
            HiddenField hdTotalProduct = e.Item.FindControl("hdnTotalProduct") as HiddenField;
            HiddenField hdTotalQuantity = e.Item.FindControl("hdnTotalQuantity") as HiddenField;
            HiddenField hdnComment = e.Item.FindControl("hdnComment") as HiddenField;
            HiddenField hdnSpComment = e.Item.FindControl("hdnSpComment") as HiddenField;
            HiddenField hdnTrackingNumber = e.Item.FindControl("hdnTrackingNumber") as HiddenField;
            LinkButton lnkDelivered = e.Item.FindControl("lnkDelivered") as LinkButton;

            hdEmail.Value = hdnEmail.Value;

            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Customer Order Approve / Reject";
            lblMessage.Text = hdMessage.Value;
            DataSet ds = objAdminCls.GetCustomerOrder(Convert.ToInt32(hdn.Value));
            hdIdCustomerOrder.Value = hdn.Value;
            Label lblName = e.Item.FindControl("lblName") as Label;
            Label lblOrderno = e.Item.FindControl("lblOrderNo") as Label;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    string htr = "<tr><td style='padding-right: 0px;padding-left: 0px;' align='center'><img align='center' border='0' src='" + AdminUrl + "/ProductImage/" + ds.Tables[1].Rows[i]["ImageURL"] + "' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;width: 100%;max-width: 130px;' width='130' class='v-src-width v-src-max-width' /></td><td style = 'overflow-wrap:break-word;word-break:break-word;padding:37px 30px 36px;font-family:arial,helvetica,sans-serif;' align = 'left'><div class='v-text-align' style='color: #000000; line-height: 140%; text-align: left; word-wrap: break-word;'><p style = 'font-size: 14px; line-height: 140%;' ><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> " + ds.Tables[1].Rows[i]["sName"] + "</span ></strong ></span ></p ><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Size:&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;7</span></strong></span></p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Quantity: &nbsp; &nbsp;" + ds.Tables[1].Rows[i]["Quantity"] + "</span></strong></span></p></div></td></tr>";
                    producthtml += htr;
                }
            }
            if (!string.IsNullOrEmpty(lblName.Text))
            {
                if (e.CommandName == "CatEdit")
                {
                    lblOrder.Text = lblOrderno.Text;
                    lblNames.Text = lblName.Text;
                    lblEmail.Text = hdnEmail.Value;
                    lblidCustomer.Text = hdidCustomer.Value;
                    lblMobile.Text = hdMobile.Value;
                    lblPinCode.Text = hdMobile.Value;
                    lblsAddress1.Text = hdsAddress1.Value;
                    lblsAddress2.Text = hdsAddress2.Value;
                    lblsCity.Text = hdsCity.Value;
                    lblsState.Text = hdsState.Value;
                    lblsLandMark.Text = hdsLandMark.Value;
                    lblAddressType.Text = hdAddressType.Value;
                    lblAlternateNo.Text = hdAlternateNo.Value;
                    lblCouponCode.Text = hdCouponCode.Value;

                    switch (hdbStatus.Value)
                    {
                        case "0":
                            lblbStatus.Text = Convert.ToString(OrderStatus.Pending);
                            break;
                        case "1":
                            lblbStatus.Text = Convert.ToString(OrderStatus.Approved);
                            ddApproveReject.SelectedValue = "Approve";
                            break;
                        case "2":
                            lblbStatus.Text = Convert.ToString(OrderStatus.Reject);
                            ddApproveReject.SelectedValue = "Reject";
                            break;
                        case "3":
                            lblbStatus.Text = Convert.ToString(OrderStatus.Shipped);
                            ddApproveReject.SelectedValue = "Approve";
                            break;
                        case "4":
                            lblbStatus.Text = Convert.ToString(OrderStatus.Delivered);
                            ddApproveReject.Enabled = false;
                            btnSave.Visible = false;
                            ddApproveReject.SelectedValue = "Approve";
                            break;
                        default:
                            break;
                    }

                    ddApproveReject.SelectedValue = hdbStatus.Value == "0" ? "" : (hdbStatus.Value == "2" ? "Reject" : "Approve");
                    int bstatus = Convert.ToString(lblbStatus.Text) == "Pending" ?  0:
                                        Convert.ToString(lblbStatus.Text) == "Approved" ? 1 :
                                      Convert.ToString(lblbStatus.Text) == "Reject" ? 2 :
                                      Convert.ToString(lblbStatus.Text) == "Shipped" ? 3 :
                                      Convert.ToString(lblbStatus.Text) == "Delivered" ? 4 : 5;
                    txtComment.Text = hdnComment.Value;
                    txtShipping.Text = hdnSpComment.Value;
                    lbltotalAmount.Text = hdtotalAmount.Value;
                    //lblTotalProduct.Text = hdTotalProduct.Value;
                    //lblTotalQuantity.Text = hdTotalQuantity.Value;
                    
                    frmCustomerOrder.Style.Add("display", "flex");
                    tblCustomerOrder.Style.Add("display", "none");
                    pnlShipping.Style.Add("display", "none");
                    //GetBlog(Convert.ToInt32(hdBlogId.Value));  
                    if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        rptrProductDetails.DataSource = ds.Tables[1];
                        rptrProductDetails.DataBind();
                    }
                }
                else if (e.CommandName == "CatDelete")
                {
                    DeleteCustomerOrder(Convert.ToInt32(hdIdCustomerOrder.Value));
                }
                else if (e.CommandName == "CatShipped")
                {
                    lblSOrderNo.Text = lblOrderno.Text;
                    lblSname.Text = lblName.Text;
                    lblSEmail.Text = hdnEmail.Value;
                    lblSMobile.Text = hdMobile.Value;
                    chkShipped.Checked = hdbStatus.Value == "3" ? true : false;
                    txtShipping.Text = hdnSpComment.Value;
                    txtTrackingNumbers.Text = hdnTrackingNumber.Value;
                    frmCustomerOrder.Style.Add("display", "none");
                    tblCustomerOrder.Style.Add("display", "none");
                    pnlShipping.Style.Add("display", "flex");
                    if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        rptProductDetail.DataSource = ds.Tables[1];
                        rptProductDetail.DataBind();
                    }
                }
                else if (e.CommandName == "CatDelivered")
                {
                    int idCountry = GetCountryId();
                    UserDL objUserDL = new UserDL();
                    ds = objUserDL.GetAllClientMaster(idCountry);
                    string host = "", fromMail = "", password = "";
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        host = Convert.ToString(ds.Tables[0].Rows[0]["host"]);
                        fromMail = Convert.ToString(ds.Tables[0].Rows[0]["fromEmail"]);
                        password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                    }

                    string Name = hdsName.Value;
                    string Address = hdsAddress1.Value;
                    string Address1 = hdsAddress2.Value;
                    string Address2 = hdsCity.Value;
                    string Address3 = hdsState.Value;
                    string OrderNo = hdsOrderNo.Value;
                    string OrderDate = hddtOrder.Value;
                    string TotalAmount = hdtotalAmount.Value;
                    string emailTo = hdEmail.Value;
                    string subject = "Delivered";
                    UpdateCustomerOrderStatus(Convert.ToInt32(OrderStatus.Delivered));

                    // Code to send mail
                    string link = string.Empty;
                    //   link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>");
                    keywordsToReplace.Add("##Delivered##", status);
                    keywordsToReplace.Add("##Name##", Name);
                    keywordsToReplace.Add("##ABCDE##", Name);
                    keywordsToReplace.Add("##12345##", Address);
                    keywordsToReplace.Add("##ABC##", Address2);
                    keywordsToReplace.Add("##ACD##", Address3);
                    keywordsToReplace.Add("##38337398##", OrderNo);
                    keywordsToReplace.Add("##December##", OrderDate);
                    keywordsToReplace.Add("##$14.83##", TotalAmount);
                    keywordsToReplace.Add("##Sleek##", producthtml);

                    string body = GenrateMail("Delivered");

                    CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);


                    GetAllCustomerOrder();
                }
            }
        }

        private void DeleteCustomerOrder(int idCustomerOrder)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Customer Order Delete |";
            int Response = objAdminCls.DeleteCustomerOrder(idCustomerOrder);
            if (Response > 0)
            {
                GetAllCustomerOrder();
                hdMessage.Value += "Customer Order Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmCustomerOrder.Style.Add("display", "none");
                tblCustomerOrder.Style.Add("display", "block");
                pnlShipping.Style.Add("display", "none");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Blog not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //lblmess.Text = ddl.Text;
            //Code to approve
            AdminDL objAdminCls = new AdminDL();
            CustomerOrderCls objCustomerOrder = new CustomerOrderCls();
            if (Convert.ToInt32(hdIdCustomerOrder.Value) > 0)
            {
                hdMessage.Value = "Product Price Update |";
                objCustomerOrder.idCustomerOrder = Convert.ToInt32(hdIdCustomerOrder.Value);
            }
            else
            {
                hdMessage.Value = "Product Price Insert |";
                objCustomerOrder.idCustomerOrder = 0;
            }
            if (lblbStatus.Text == Convert.ToString(OrderStatus.Shipped) && (ddApproveReject.SelectedValue == "Approve"))
                objCustomerOrder.bStatus = Convert.ToInt32(OrderStatus.Shipped);
            else
                objCustomerOrder.bStatus = (ddApproveReject.SelectedValue == "Approve") ? Convert.ToInt32(OrderStatus.Approved) : Convert.ToInt32(OrderStatus.Reject);
            objCustomerOrder.Comment = Convert.ToString(txtComment.Text);
            objCustomerOrder.TrackingNumber = txtTrackingNumbers.Text;
            DataSet ds = objAdminCls.GetCustomerOrder(Convert.ToInt32(hdIdCustomerOrder.Value));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    string htr = "<tr><td style='padding-right: 0px;padding-left: 0px;' align='center'><img align='center' border='0' src='" + AdminUrl + "/ProductImage/" + ds.Tables[1].Rows[i]["ImageURL"] + "' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;width: 100%;max-width: 130px;' width='130' class='v-src-width v-src-max-width' /></td><td style = 'overflow-wrap:break-word;word-break:break-word;padding:37px 30px 36px;font-family:arial,helvetica,sans-serif;' align = 'left'><div class='v-text-align' style='color: #000000; line-height: 140%; text-align: left; word-wrap: break-word;'><p style = 'font-size: 14px; line-height: 140%;' ><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> " + ds.Tables[1].Rows[i]["sName"] + "</span ></strong ></span ></p ><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Size:&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;7</span></strong></span></p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Quantity: &nbsp; &nbsp;" + ds.Tables[1].Rows[i]["Quantity"] + "</span></strong></span></p></div></td></tr>";
                    producthtml += htr;
                }
            }
                string Name = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
            string Address = Convert.ToString(ds.Tables[0].Rows[0]["sAddress1"]);
            string Address1 = Convert.ToString(ds.Tables[0].Rows[0]["sAddress2"]);
            string Address2 = Convert.ToString(ds.Tables[0].Rows[0]["sCity"]);
            string Address3 = Convert.ToString(ds.Tables[0].Rows[0]["sState"]);
            string OrderNo = Convert.ToString(ds.Tables[0].Rows[0]["sOrderNo"]);
            string OrderDate = Convert.ToString(ds.Tables[0].Rows[0]["dtOrder"]);
            string TotalAmount = Convert.ToString(ds.Tables[0].Rows[0]["totalAmount"]);
            int bStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["bStatus"]);
            UpdateCustomerOrderStatus((ddApproveReject.SelectedValue == "Approve") ? Convert.ToInt32(OrderStatus.Approved) : Convert.ToInt32(OrderStatus.Reject));

            // Code to send mail
            string link = string.Empty;
            //   link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>");
            keywordsToReplace.Add("##Approve##", status);
            keywordsToReplace.Add("##Name##", Name);
            keywordsToReplace.Add("##ABCDE##", Name);
            keywordsToReplace.Add("##12345##", Address);
            keywordsToReplace.Add("##ABC##", Address2);
            keywordsToReplace.Add("##ACD##", Address3);
            keywordsToReplace.Add("##38337398##", OrderNo);
            keywordsToReplace.Add("##December##", OrderDate);
            keywordsToReplace.Add("##$14.83##", TotalAmount);
            keywordsToReplace.Add("##Sleek##", producthtml);
            objCustomerOrder.idCustomerOrder = Convert.ToInt32(hdIdCustomerOrder.Value);
            objCustomerOrder.ApproveReject = Convert.ToString(ddApproveReject.Text);

         
            int Response = objAdminCls.InsertUpdateCustomerOrder(objCustomerOrder);
            if (Response > 0)
            {
                sendEmail();
                GetAllCustomerOrder();
                resetcontrol();
                hdMessage.Value += "Customer Order saved and send successfully";
                
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmCustomerOrder.Style.Add("display", "none");
                tblCustomerOrder.Style.Add("display", "flex");
                pnlShipping.Style.Add("display", "none");
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

        private void sendEmail()
        {
            int idCountry = GetCountryId();
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetAllClientMaster(idCountry);
            string host = "", fromMail = "", password = "";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                host = Convert.ToString(ds.Tables[0].Rows[0]["host"]);
                fromMail = Convert.ToString(ds.Tables[0].Rows[0]["fromEmail"]);
                password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
            }
            if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(fromMail) && !string.IsNullOrEmpty(password))
            {
                if (ddApproveReject.SelectedValue == "Approve")
                {
                    string emailTo = hdEmail.Value;
                    string subject = "Approve";



                    string body = GenrateMail("Approve");
                    CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                }
                else if (ddApproveReject.SelectedValue == "Reject")
                {
                    string emailTo = hdEmail.Value;
                    string subject = "Reject";


                    string body = GenrateMail("Reject");
                    CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                }
            }
            else
            {
                lblMessage.Text = "Mail is not sent because Host, From mail and Password not found.";
            }
            //else if (ddApproveReject.SelectedValue == "Pending")
            //{
            //    string emailTo = hdEmail.Value;
            //    string subject = "Pending";
            //    string body = GenrateMail("Pending");
            //    CommonControl.SendEmail(emailTo, subject, body);
            //}
            //else if (ddApproveReject.SelectedValue == "Delivered")
            //{
            //    string emailTo = hdEmail.Value;
            //    string subject = "Delivered";
            //    string body = GenrateMail("Delivered");
            //    CommonControl.SendEmail(emailTo, subject, body);
            //}
        }

        private int GetCountryId()
        {
            int value = 0;
            HttpCookie reqCookies = Request.Cookies["WebInfo"];
            if (reqCookies != null)
            {
                string rdata = reqCookies["idCountry"].ToString();
                value = Convert.ToInt32(CommonControl.Decrypt(rdata));
            }
            return value;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmCustomerOrder.Style.Add("display", "none");
            tblCustomerOrder.Style.Add("display", "flex");
            pnlShipping.Style.Add("display", "none");
        }

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            var path = "";
            switch (mailType)
            {
                case "Approve":
                    contentFilePath = Server.MapPath("HTMLMail/OrderStatus.html");
                    //StreamReader reader = File.OpenText(path);
                    //contentFilePath = "~/";
                    break;
                case "Reject":
                    contentFilePath = Server.MapPath("HTMLMail/OrderStatus.html");
                    break;
                case "Shipped":
                    contentFilePath = Server.MapPath("HTMLMail/Shipped.html");
                    break;
                //case "Pending":
                //    contentFilePath = "~/HTMLMail/Reject.html";
                //    break;
                case "Delivered":
                    contentFilePath = Server.MapPath("HTMLMail/Delivered.html");
                    break;
                default:
                    break;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(System.IO.File.ReadAllText(contentFilePath));
            foreach (string keyword in keywordsToReplace)
            {
                sb.Replace(keyword, keywordsToReplace.Get(keyword));
            }
            return sb.ToString();
        }

        protected void btnShipped_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            UpdateCustomerOrderStatus(chkShipped.Checked ? Convert.ToInt32(OrderStatus.Shipped) : Convert.ToInt32(OrderStatus.Approved));
            DataSet ds = objAdminCls.GetCustomerOrder(Convert.ToInt32(hdIdCustomerOrder.Value));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    string htr = "<tr><td style='padding-right: 0px;padding-left: 0px;' align='center'><img align='center' border='0' src='" + AdminUrl + "/ProductImage/" + ds.Tables[1].Rows[i]["ImageURL"] + "' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;width: 100%;max-width: 130px;' width='130' class='v-src-width v-src-max-width' /></td><td style = 'overflow-wrap:break-word;word-break:break-word;padding:37px 30px 36px;font-family:arial,helvetica,sans-serif;' align = 'left'><div class='v-text-align' style='color: #000000; line-height: 140%; text-align: left; word-wrap: break-word;'><p style = 'font-size: 14px; line-height: 140%;' ><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> " + ds.Tables[1].Rows[i]["sName"] + "</span ></strong ></span ></p ><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Size:&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;7</span></strong></span></p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Quantity: &nbsp; &nbsp;" + ds.Tables[1].Rows[i]["Quantity"] + "</span></strong></span></p></div></td></tr>";
                    producthtml += htr;
                }
            }
            string Name = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
            string Address = Convert.ToString(ds.Tables[0].Rows[0]["sAddress1"]);
            string Address1 = Convert.ToString(ds.Tables[0].Rows[0]["sAddress2"]);
            string Address2 = Convert.ToString(ds.Tables[0].Rows[0]["sCity"]);
            string Address3 = Convert.ToString(ds.Tables[0].Rows[0]["sState"]);
            string OrderNo = Convert.ToString(ds.Tables[0].Rows[0]["sOrderNo"]);
            string OrderDate = Convert.ToString(ds.Tables[0].Rows[0]["dtOrder"]);
            string TotalAmount = Convert.ToString(ds.Tables[0].Rows[0]["totalAmount"]);
            int bStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["bStatus"]);



            int idCountry = GetCountryId();
            UserDL objUserDL = new UserDL();
            DataSet ds1 = objUserDL.GetAllClientMaster(idCountry);
            string host = "", fromMail = "", password = "";
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                host = Convert.ToString(ds1.Tables[0].Rows[0]["host"]);
                fromMail = Convert.ToString(ds1.Tables[0].Rows[0]["fromEmail"]);
                password = Convert.ToString(ds1.Tables[0].Rows[0]["password"]);
            }
            if (chkShipped.Checked == true)
            {
                // Code to send mail
                string link = string.Empty;
                //   link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>");
                keywordsToReplace.Add("##Shipped##", status);
                keywordsToReplace.Add("##Name##", Name);
                keywordsToReplace.Add("##ABCDE##", Name);
                keywordsToReplace.Add("##12345##", Address);
                keywordsToReplace.Add("##ABC##", Address2);
                keywordsToReplace.Add("##ACD##", Address3);
                keywordsToReplace.Add("##38337398##", OrderNo);
                keywordsToReplace.Add("##December##", OrderDate);
                keywordsToReplace.Add("##$14.83##", TotalAmount);

                keywordsToReplace.Add("##Sleek##", producthtml);
                string emailTo = hdEmail.Value;
                string subject = "Shipped";


                string body = GenrateMail("Shipped");
                CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
            }

            
            frmCustomerOrder.Style.Add("display", "none");
            tblCustomerOrder.Style.Add("display", "flex");
            pnlShipping.Style.Add("display", "none");
            GetAllCustomerOrder();
            resetcontrol();
            //sendEmail();
        }

        private void UpdateCustomerOrderStatus(int bStatus)
        {
            AdminDL objAdminCls = new AdminDL();
            CustomerOrderCls objCustomerOrder = new CustomerOrderCls();
            status = Convert.ToString(bStatus) == "0" ? "Pending" :
                                         Convert.ToString(bStatus) == "1" ? "Approved" :
                                       Convert.ToString(bStatus) == "2" ? "Reject" :
                                       Convert.ToString(bStatus) == "3" ? "Shipped" :
                                       Convert.ToString(bStatus) == "4" ? "Delivered" : "User Cancel";
            if (Convert.ToInt32(hdIdCustomerOrder.Value) > 0)
            {
                hdMessage.Value = "Product Price Update |";
                objCustomerOrder.idCustomerOrder = Convert.ToInt32(hdIdCustomerOrder.Value);
            }
            else
            {
                hdMessage.Value = "Product Price Insert |";
                objCustomerOrder.idCustomerOrder = 0;
            }
            objCustomerOrder.idCustomerOrder = Convert.ToInt32(hdIdCustomerOrder.Value);
            objCustomerOrder.bStatus = bStatus;
            objCustomerOrder.ShippingComment = (bStatus == Convert.ToInt32(OrderStatus.Approved)) ? null : Convert.ToString(txtShipping.Text);
            objCustomerOrder.TrackingNumber = txtTrackingNumbers.Text;

            string Response = objAdminCls.UpdateCustomerOrderStatus(objCustomerOrder);

            if (string.IsNullOrEmpty(Response) && Response == "Success")
            {
                hdMessage.Value += Response;
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else
            {
                hdMessage.Value += Response;
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnUploadExcel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string tempPath = Path.GetTempPath();
                FileUpload1.SaveAs(tempPath + filename);
                string filepath = tempPath + filename;
                if (File.Exists(filepath))
                {
                    Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();

                    if (xlsApp == null)
                    {
                        Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");
                        //return null;
                    }

                    //Displays Excel so you can see what is happening
                    //xlsApp.Visible = true;

                    Microsoft.Office.Interop.Excel.Workbook wb = xlsApp.Workbooks.Open(filepath,
                        0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                    Microsoft.Office.Interop.Excel.Sheets sheets = wb.Worksheets;
                    Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);

                    Microsoft.Office.Interop.Excel.Range firstColumn = ws.UsedRange.Columns[1];
                    System.Array myvalues = (System.Array)firstColumn.Cells.Value;

                    sb.Append("<TrackingNumbers>");
                    foreach (var item in myvalues)
                    {
                        long trackingNo;
                        if (item != null && Int64.TryParse(Convert.ToString(item), out trackingNo))
                        {
                            sb.Append("<TrackingNumber>" + trackingNo + "</TrackingNumber>");
                        }
                    }
                    sb.Append("</TrackingNumbers>");
                    File.Delete(filepath);
                }
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                AdminDL objAdminCls = new AdminDL();
                DataSet ds = objAdminCls.UpdateStatusOfTrackingNumber(sb.ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblMsgTracking.Visible = false;
                    rptTrackingStatus.DataSource = ds;
                    rptTrackingStatus.DataBind();
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTrackingNumberStatus()", true);
                }
                else
                {
                    lblMsgTracking.Visible = true;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTrackingNumberStatus()", true);
                }
            }
            GetAllCustomerOrder();
        }
    }
}