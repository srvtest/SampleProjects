using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using DataLayer;
namespace WinGST
{
    public partial class frmExpense : Form
    {
        private string _mode = "Add";
        int ID = 0;
        public frmExpense()
        {
            InitializeComponent();
        }
        private void frmExpense_Load(object sender, EventArgs e)
        {
            dgExpense.AutoGenerateColumns = false;
            CommonClass.LoadStateCombo(cbState);
            FilterData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Expense exp = new Expense();
            DL_WinGST dlObj = new DL_WinGST();
            if (!string.IsNullOrEmpty(txtCompanyName.Text.Trim()) && !string.IsNullOrEmpty(txtAmount.Text.Trim()) && !string.IsNullOrEmpty(txtGSTPercent.Text.Trim()))
            {
                exp.CompanyName = txtCompanyName.Text.Trim();
                exp.Amount = Convert.ToDouble(txtAmount.Text.Trim());
                exp.GSTPercent = Convert.ToDouble(txtGSTPercent.Text.Trim());

                if (cbState.SelectedValue.ToString().ToLower() == WinGST.CommonClass.EnumState.StateMP.ToString().ToLower())
                {
                    exp.CGST = Convert.ToDouble((exp.Amount * (exp.GSTPercent / 2)) / 100);
                    exp.SGST = Convert.ToDouble((exp.Amount * (exp.GSTPercent / 2)) / 100);
                    exp.IGST = 0;
                }
                else if (cbState.SelectedValue.ToString().ToLower() == WinGST.CommonClass.EnumState.StateOtherthenMP.ToString().ToLower())
                {
                    exp.CGST = 0;
                    exp.SGST = 0;
                    exp.IGST = Convert.ToDouble((exp.Amount * exp.GSTPercent) / 100);
                }
                exp.Remark = txtRemark.Text;
                exp.Status = true;
                exp.ExpenseDate = Convert.ToDateTime(dtpExpenseDate.Text);
                exp.GSTNo = Convert.ToString(txtGSTNo.Text);
                exp.State = Convert.ToString(cbState.GetItemText(cbState.SelectedItem));
                exp.CreatedBy = 1;
                if (_mode == "Add")
                {
                    string msg = dlObj.InsertExpense(exp);
                    //lblmessage.Text = "Expense Added Successfully.";
                }
                else
                {
                    exp.ExpenseId = Convert.ToInt32(lblExpId.Text);
                    string msg = dlObj.UpdateExpense(exp);
                    //lblmessage.Text = "Material Update Successfully.";
                }
                ClearAll();
            }
            else
            {
                MessageBox.Show("Please Enter Required Fields.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearAll()
        {
            txtCompanyName.Text = string.Empty;
            txtGSTNo.Text = string.Empty;
            txtGSTPercent.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtRemark.Text = string.Empty;
            //cbState
            //dtpExpenseDate           
            lblExpId.Text = "";
            _mode = "Add";
            FilterData();
        }

        private void dgExpense_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dgExpense.Rows[e.RowIndex].Cells[0].Value.ToString());
            DL_WinGST dlObj = new DL_WinGST();
            DataSet ds = dlObj.getExpenseById(ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                txtGSTPercent.Text = ds.Tables[0].Rows[0]["GSTPercent"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                dtpExpenseDate.Text = ds.Tables[0].Rows[0]["ExpenseDate"].ToString();
                txtGSTNo.Text = ds.Tables[0].Rows[0]["GSTNo"].ToString();
                cbState.SelectedIndex = cbState.FindString(ds.Tables[0].Rows[0]["State"].ToString());
                lblExpId.Text = ds.Tables[0].Rows[0]["ExpenseId"].ToString();
                _mode = "Edit";
            }           
        }

        public void FilterData()
        {
            DL_WinGST dlObj = new DL_WinGST();
            DataSet ds = dlObj.getExpense("");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgExpense.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
