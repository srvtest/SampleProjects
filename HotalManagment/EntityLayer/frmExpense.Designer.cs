namespace WinGST
{
    partial class frmExpense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpense));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgExpense = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtGSTNo = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtGSTPercent = new System.Windows.Forms.TextBox();
            this.lblExpId = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ExpenseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSTNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExpense)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgExpense);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(887, 187);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Expense Detail";
            // 
            // dgExpense
            // 
            this.dgExpense.AllowUserToAddRows = false;
            this.dgExpense.AllowUserToDeleteRows = false;
            this.dgExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExpenseId,
            this.Date,
            this.MaterialName,
            this.State,
            this.GSTNo,
            this.quantity,
            this.GST,
            this.Prices,
            this.SGST,
            this.IGST,
            this.Total,
            this.Remark});
            this.dgExpense.Location = new System.Drawing.Point(6, 22);
            this.dgExpense.Name = "dgExpense";
            this.dgExpense.ReadOnly = true;
            this.dgExpense.Size = new System.Drawing.Size(875, 150);
            this.dgExpense.TabIndex = 18;
            this.dgExpense.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgExpense_RowHeaderMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Expense";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbState);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dtpExpenseDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.txtGSTNo);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.txtGSTPercent);
            this.groupBox1.Controls.Add(this.lblExpId);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 173);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expense";
            // 
            // cbState
            // 
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(653, 92);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(204, 24);
            this.cbState.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.AutoEllipsis = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(661, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 46;
            this.button1.Tag = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpExpenseDate
            // 
            this.dtpExpenseDate.Location = new System.Drawing.Point(653, 60);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(204, 23);
            this.dtpExpenseDate.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(594, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 44;
            this.label10.Text = "Date";
            // 
            // btnPrint
            // 
            this.btnPrint.AutoEllipsis = true;
            this.btnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(707, 126);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(40, 40);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Tag = "Save";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtGSTNo
            // 
            this.txtGSTNo.Location = new System.Drawing.Point(93, 90);
            this.txtGSTNo.Name = "txtGSTNo";
            this.txtGSTNo.Size = new System.Drawing.Size(181, 23);
            this.txtGSTNo.TabIndex = 40;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(92, 122);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(496, 40);
            this.txtRemark.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "Remark";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "State";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "GST No";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(799, 126);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 34;
            this.btnExit.Tag = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtGSTPercent
            // 
            this.txtGSTPercent.Location = new System.Drawing.Point(539, 92);
            this.txtGSTPercent.Name = "txtGSTPercent";
            this.txtGSTPercent.Size = new System.Drawing.Size(49, 23);
            this.txtGSTPercent.TabIndex = 12;
            this.txtGSTPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblExpId
            // 
            this.lblExpId.AutoSize = true;
            this.lblExpId.Location = new System.Drawing.Point(99, 19);
            this.lblExpId.Name = "lblExpId";
            this.lblExpId.Size = new System.Drawing.Size(16, 17);
            this.lblExpId.TabIndex = 11;
            this.lblExpId.Text = "1";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(342, 90);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(135, 23);
            this.txtAmount.TabIndex = 8;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(92, 57);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(496, 23);
            this.txtCompanyName.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(314, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(481, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "GST %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Amount *";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Company  *";
            // 
            // btnSave
            // 
            this.btnSave.AutoEllipsis = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(753, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Tag = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ExpenseId
            // 
            this.ExpenseId.DataPropertyName = "ExpenseId";
            this.ExpenseId.HeaderText = "ExpenseId";
            this.ExpenseId.Name = "ExpenseId";
            this.ExpenseId.ReadOnly = true;
            this.ExpenseId.Visible = false;
            this.ExpenseId.Width = 98;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "ExpenseDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 63;
            // 
            // MaterialName
            // 
            this.MaterialName.DataPropertyName = "CompanyName";
            this.MaterialName.HeaderText = "Company Name";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.ReadOnly = true;
            this.MaterialName.Width = 122;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 66;
            // 
            // GSTNo
            // 
            this.GSTNo.HeaderText = "GST No";
            this.GSTNo.Name = "GSTNo";
            this.GSTNo.ReadOnly = true;
            this.GSTNo.Width = 78;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "Amount";
            this.quantity.HeaderText = "Amount";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 81;
            // 
            // GST
            // 
            this.GST.DataPropertyName = "GSTPercent";
            this.GST.HeaderText = "GST %";
            this.GST.Name = "GST";
            this.GST.ReadOnly = true;
            this.GST.Width = 72;
            // 
            // Prices
            // 
            this.Prices.DataPropertyName = "CGST";
            this.Prices.HeaderText = "CGST";
            this.Prices.Name = "Prices";
            this.Prices.ReadOnly = true;
            this.Prices.Width = 71;
            // 
            // SGST
            // 
            this.SGST.DataPropertyName = "SGST";
            this.SGST.HeaderText = "SGST";
            this.SGST.Name = "SGST";
            this.SGST.ReadOnly = true;
            this.SGST.Width = 71;
            // 
            // IGST
            // 
            this.IGST.DataPropertyName = "IGST";
            this.IGST.HeaderText = "IGST";
            this.IGST.Name = "IGST";
            this.IGST.ReadOnly = true;
            this.IGST.Width = 65;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 65;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 82;
            // 
            // frmExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(911, 415);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmExpense";
            this.Text = "frmExpense";
            this.Load += new System.EventHandler(this.frmExpense_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgExpense)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtGSTPercent;
        private System.Windows.Forms.Label lblExpId;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgExpense;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGSTNo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpExpenseDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSTNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn GST;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prices;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}