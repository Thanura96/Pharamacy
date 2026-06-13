namespace PharmacySystem.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabAvailable = new System.Windows.Forms.TabPage();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            this.tabLowStock = new System.Windows.Forms.TabPage();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.tabExpired = new System.Windows.Forms.TabPage();
            this.dgvExpired = new System.Windows.Forms.DataGridView();
            this.tabSalesHistory = new System.Windows.Forms.TabPage();
            this.dgvSalesHistory = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabReports.SuspendLayout();
            this.tabAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            this.tabLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.tabExpired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpired)).BeginInit();
            this.tabSalesHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabAvailable);
            this.tabReports.Controls.Add(this.tabLowStock);
            this.tabReports.Controls.Add(this.tabExpired);
            this.tabReports.Controls.Add(this.tabSalesHistory);
            this.tabReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReports.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabReports.Location = new System.Drawing.Point(0, 60);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(884, 501);
            this.tabReports.TabIndex = 0;
            this.tabReports.SelectedIndexChanged += new System.EventHandler(this.tabReports_SelectedIndexChanged);
            // 
            // tabAvailable
            // 
            this.tabAvailable.Controls.Add(this.dgvAvailable);
            this.tabAvailable.Location = new System.Drawing.Point(4, 26);
            this.tabAvailable.Name = "tabAvailable";
            this.tabAvailable.Padding = new System.Windows.Forms.Padding(10);
            this.tabAvailable.Size = new System.Drawing.Size(876, 471);
            this.tabAvailable.TabIndex = 0;
            this.tabAvailable.Text = "Available Medicines";
            this.tabAvailable.UseVisualStyleBackColor = true;
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.AllowUserToAddRows = false;
            this.dgvAvailable.AllowUserToDeleteRows = false;
            this.dgvAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailable.BackgroundColor = System.Drawing.Color.White;
            this.dgvAvailable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailable.Location = new System.Drawing.Point(10, 10);
            this.dgvAvailable.MultiSelect = false;
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.ReadOnly = true;
            this.dgvAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailable.Size = new System.Drawing.Size(856, 451);
            this.dgvAvailable.TabIndex = 0;
            // 
            // tabLowStock
            // 
            this.tabLowStock.Controls.Add(this.dgvLowStock);
            this.tabLowStock.Location = new System.Drawing.Point(4, 26);
            this.tabLowStock.Name = "tabLowStock";
            this.tabLowStock.Padding = new System.Windows.Forms.Padding(10);
            this.tabLowStock.Size = new System.Drawing.Size(876, 471);
            this.tabLowStock.TabIndex = 1;
            this.tabLowStock.Text = "Low Stock Medicines";
            this.tabLowStock.UseVisualStyleBackColor = true;
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvLowStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLowStock.Location = new System.Drawing.Point(10, 10);
            this.dgvLowStock.MultiSelect = false;
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.Size = new System.Drawing.Size(856, 451);
            this.dgvLowStock.TabIndex = 0;
            // 
            // tabExpired
            // 
            this.tabExpired.Controls.Add(this.dgvExpired);
            this.tabExpired.Location = new System.Drawing.Point(4, 26);
            this.tabExpired.Name = "tabExpired";
            this.tabExpired.Padding = new System.Windows.Forms.Padding(10);
            this.tabExpired.Size = new System.Drawing.Size(876, 471);
            this.tabExpired.TabIndex = 2;
            this.tabExpired.Text = "Expired Medicines";
            this.tabExpired.UseVisualStyleBackColor = true;
            // 
            // dgvExpired
            // 
            this.dgvExpired.AllowUserToAddRows = false;
            this.dgvExpired.AllowUserToDeleteRows = false;
            this.dgvExpired.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpired.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpired.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpired.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpired.Location = new System.Drawing.Point(10, 10);
            this.dgvExpired.MultiSelect = false;
            this.dgvExpired.Name = "dgvExpired";
            this.dgvExpired.ReadOnly = true;
            this.dgvExpired.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpired.Size = new System.Drawing.Size(856, 451);
            this.dgvExpired.TabIndex = 0;
            // 
            // tabSalesHistory
            // 
            this.tabSalesHistory.Controls.Add(this.dgvSalesHistory);
            this.tabSalesHistory.Location = new System.Drawing.Point(4, 26);
            this.tabSalesHistory.Name = "tabSalesHistory";
            this.tabSalesHistory.Padding = new System.Windows.Forms.Padding(10);
            this.tabSalesHistory.Size = new System.Drawing.Size(876, 471);
            this.tabSalesHistory.TabIndex = 3;
            this.tabSalesHistory.Text = "Sales History";
            this.tabSalesHistory.UseVisualStyleBackColor = true;
            // 
            // dgvSalesHistory
            // 
            this.dgvSalesHistory.AllowUserToAddRows = false;
            this.dgvSalesHistory.AllowUserToDeleteRows = false;
            this.dgvSalesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesHistory.Location = new System.Drawing.Point(10, 10);
            this.dgvSalesHistory.MultiSelect = false;
            this.dgvSalesHistory.Name = "dgvSalesHistory";
            this.dgvSalesHistory.ReadOnly = true;
            this.dgvSalesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesHistory.Size = new System.Drawing.Size(856, 451);
            this.dgvSalesHistory.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(884, 60);
            this.panelTop.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(764, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(198, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pharmacy Reports";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabReports);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.tabReports.ResumeLayout(false);
            this.tabAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            this.tabLowStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.tabExpired.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpired)).EndInit();
            this.tabSalesHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabAvailable;
        private System.Windows.Forms.DataGridView dgvAvailable;
        private System.Windows.Forms.TabPage tabLowStock;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.TabPage tabExpired;
        private System.Windows.Forms.DataGridView dgvExpired;
        private System.Windows.Forms.TabPage tabSalesHistory;
        private System.Windows.Forms.DataGridView dgvSalesHistory;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
    }
}
