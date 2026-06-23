namespace PharmacySystem.Forms
{
    partial class ReportsForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.dgvSalesByDate = new System.Windows.Forms.DataGridView();
            this.panelSalesSummary = new System.Windows.Forms.Panel();
            this.lblSalesRevenue = new System.Windows.Forms.Label();
            this.lblSalesRevenueTitle = new System.Windows.Forms.Label();
            this.lblSalesOrderCount = new System.Windows.Forms.Label();
            this.lblSalesOrderCountTitle = new System.Windows.Forms.Label();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.dgvCurrentStock = new System.Windows.Forms.DataGridView();
            this.lblCurrentStockTitle = new System.Windows.Forms.Label();
            this.tabCustomerHistory = new System.Windows.Forms.TabPage();
            this.dgvCustomerHistory = new System.Windows.Forms.DataGridView();
            this.panelHistoryExport = new System.Windows.Forms.Panel();
            this.btnExportHistoryExcel = new System.Windows.Forms.Button();
            this.btnExportHistoryPdf = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesByDate)).BeginInit();
            this.panelSalesSummary.SuspendLayout();
            this.tabStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentStock)).BeginInit();
            this.tabCustomerHistory.SuspendLayout();
            this.panelHistoryExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(74, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reports";
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
            this.btnRefresh.Location = new System.Drawing.Point(854, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh All";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabSales);
            this.tabReports.Controls.Add(this.tabStock);
            this.tabReports.Controls.Add(this.tabCustomerHistory);
            this.tabReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReports.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabReports.Location = new System.Drawing.Point(0, 60);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(984, 501);
            this.tabReports.TabIndex = 1;
            this.tabReports.SelectedIndexChanged += new System.EventHandler(this.tabReports_SelectedIndexChanged);
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.dgvSalesByDate);
            this.tabSales.Controls.Add(this.panelSalesSummary);
            this.tabSales.Location = new System.Drawing.Point(4, 26);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(10);
            this.tabSales.Size = new System.Drawing.Size(976, 471);
            this.tabSales.TabIndex = 0;
            this.tabSales.Text = "Sales Report";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // panelSalesSummary
            // 
            this.panelSalesSummary.Controls.Add(this.lblSalesRevenue);
            this.panelSalesSummary.Controls.Add(this.lblSalesRevenueTitle);
            this.panelSalesSummary.Controls.Add(this.lblSalesOrderCount);
            this.panelSalesSummary.Controls.Add(this.lblSalesOrderCountTitle);
            this.panelSalesSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSalesSummary.Location = new System.Drawing.Point(10, 10);
            this.panelSalesSummary.Name = "panelSalesSummary";
            this.panelSalesSummary.Size = new System.Drawing.Size(956, 60);
            this.panelSalesSummary.TabIndex = 0;
            // 
            // lblSalesOrderCountTitle
            // 
            this.lblSalesOrderCountTitle.AutoSize = true;
            this.lblSalesOrderCountTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSalesOrderCountTitle.Location = new System.Drawing.Point(3, 8);
            this.lblSalesOrderCountTitle.Name = "lblSalesOrderCountTitle";
            this.lblSalesOrderCountTitle.Size = new System.Drawing.Size(54, 19);
            this.lblSalesOrderCountTitle.TabIndex = 0;
            this.lblSalesOrderCountTitle.Text = "Orders:";
            // 
            // lblSalesOrderCount
            // 
            this.lblSalesOrderCount.AutoSize = true;
            this.lblSalesOrderCount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSalesOrderCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSalesOrderCount.Location = new System.Drawing.Point(63, 4);
            this.lblSalesOrderCount.Name = "lblSalesOrderCount";
            this.lblSalesOrderCount.Size = new System.Drawing.Size(23, 25);
            this.lblSalesOrderCount.TabIndex = 1;
            this.lblSalesOrderCount.Text = "0";
            // 
            // lblSalesRevenueTitle
            // 
            this.lblSalesRevenueTitle.AutoSize = true;
            this.lblSalesRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSalesRevenueTitle.Location = new System.Drawing.Point(200, 8);
            this.lblSalesRevenueTitle.Name = "lblSalesRevenueTitle";
            this.lblSalesRevenueTitle.Size = new System.Drawing.Size(66, 19);
            this.lblSalesRevenueTitle.TabIndex = 2;
            this.lblSalesRevenueTitle.Text = "Revenue:";
            // 
            // lblSalesRevenue
            // 
            this.lblSalesRevenue.AutoSize = true;
            this.lblSalesRevenue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSalesRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblSalesRevenue.Location = new System.Drawing.Point(272, 4);
            this.lblSalesRevenue.Name = "lblSalesRevenue";
            this.lblSalesRevenue.Size = new System.Drawing.Size(61, 25);
            this.lblSalesRevenue.TabIndex = 3;
            this.lblSalesRevenue.Text = "$0.00";
            // 
            // dgvSalesByDate
            // 
            this.dgvSalesByDate.AllowUserToAddRows = false;
            this.dgvSalesByDate.AllowUserToDeleteRows = false;
            this.dgvSalesByDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesByDate.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesByDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesByDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesByDate.Location = new System.Drawing.Point(10, 70);
            this.dgvSalesByDate.Name = "dgvSalesByDate";
            this.dgvSalesByDate.ReadOnly = true;
            this.dgvSalesByDate.Size = new System.Drawing.Size(956, 391);
            this.dgvSalesByDate.TabIndex = 1;
            // 
            // tabStock
            // 
            this.tabStock.Controls.Add(this.dgvLowStock);
            this.tabStock.Controls.Add(this.lblLowStockTitle);
            this.tabStock.Controls.Add(this.dgvCurrentStock);
            this.tabStock.Controls.Add(this.lblCurrentStockTitle);
            this.tabStock.Location = new System.Drawing.Point(4, 26);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(10);
            this.tabStock.Size = new System.Drawing.Size(976, 471);
            this.tabStock.TabIndex = 1;
            this.tabStock.Text = "Stock Report";
            this.tabStock.UseVisualStyleBackColor = true;
            // 
            // lblCurrentStockTitle
            // 
            this.lblCurrentStockTitle.AutoSize = true;
            this.lblCurrentStockTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentStockTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStockTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCurrentStockTitle.Name = "lblCurrentStockTitle";
            this.lblCurrentStockTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblCurrentStockTitle.Size = new System.Drawing.Size(98, 24);
            this.lblCurrentStockTitle.TabIndex = 0;
            this.lblCurrentStockTitle.Text = "Current Stock";
            // 
            // dgvCurrentStock
            // 
            this.dgvCurrentStock.AllowUserToAddRows = false;
            this.dgvCurrentStock.AllowUserToDeleteRows = false;
            this.dgvCurrentStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvCurrentStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCurrentStock.Location = new System.Drawing.Point(10, 34);
            this.dgvCurrentStock.Name = "dgvCurrentStock";
            this.dgvCurrentStock.ReadOnly = true;
            this.dgvCurrentStock.Size = new System.Drawing.Size(956, 200);
            this.dgvCurrentStock.TabIndex = 1;
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblLowStockTitle.Location = new System.Drawing.Point(10, 234);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Padding = new System.Windows.Forms.Padding(0, 8, 0, 5);
            this.lblLowStockTitle.Size = new System.Drawing.Size(78, 32);
            this.lblLowStockTitle.TabIndex = 2;
            this.lblLowStockTitle.Text = "Low Stock";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLowStock.Location = new System.Drawing.Point(10, 266);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.Size = new System.Drawing.Size(956, 195);
            this.dgvLowStock.TabIndex = 3;
            // 
            // tabCustomerHistory
            // 
            this.tabCustomerHistory.Controls.Add(this.dgvCustomerHistory);
            this.tabCustomerHistory.Controls.Add(this.panelHistoryExport);
            this.tabCustomerHistory.Location = new System.Drawing.Point(4, 26);
            this.tabCustomerHistory.Name = "tabCustomerHistory";
            this.tabCustomerHistory.Padding = new System.Windows.Forms.Padding(10);
            this.tabCustomerHistory.Size = new System.Drawing.Size(976, 471);
            this.tabCustomerHistory.TabIndex = 2;
            this.tabCustomerHistory.Text = "Customer Order History";
            this.tabCustomerHistory.UseVisualStyleBackColor = true;
            // 
            // dgvCustomerHistory
            // 
            this.dgvCustomerHistory.AllowUserToAddRows = false;
            this.dgvCustomerHistory.AllowUserToDeleteRows = false;
            this.dgvCustomerHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomerHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerHistory.Location = new System.Drawing.Point(10, 50);
            this.dgvCustomerHistory.Name = "dgvCustomerHistory";
            this.dgvCustomerHistory.ReadOnly = true;
            this.dgvCustomerHistory.Size = new System.Drawing.Size(956, 411);
            this.dgvCustomerHistory.TabIndex = 0;
            // 
            // panelHistoryExport
            // 
            this.panelHistoryExport.Controls.Add(this.btnExportHistoryExcel);
            this.panelHistoryExport.Controls.Add(this.btnExportHistoryPdf);
            this.panelHistoryExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHistoryExport.Location = new System.Drawing.Point(10, 10);
            this.panelHistoryExport.Name = "panelHistoryExport";
            this.panelHistoryExport.Size = new System.Drawing.Size(956, 40);
            this.panelHistoryExport.TabIndex = 1;
            // 
            // btnExportHistoryPdf
            // 
            this.btnExportHistoryPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExportHistoryPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportHistoryPdf.FlatAppearance.BorderSize = 0;
            this.btnExportHistoryPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportHistoryPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportHistoryPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportHistoryPdf.Location = new System.Drawing.Point(3, 6);
            this.btnExportHistoryPdf.Name = "btnExportHistoryPdf";
            this.btnExportHistoryPdf.Size = new System.Drawing.Size(120, 28);
            this.btnExportHistoryPdf.TabIndex = 0;
            this.btnExportHistoryPdf.Text = "Export PDF";
            this.btnExportHistoryPdf.UseVisualStyleBackColor = false;
            this.btnExportHistoryPdf.Click += new System.EventHandler(this.btnExportHistoryPdf_Click);
            // 
            // btnExportHistoryExcel
            // 
            this.btnExportHistoryExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportHistoryExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportHistoryExcel.FlatAppearance.BorderSize = 0;
            this.btnExportHistoryExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportHistoryExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportHistoryExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportHistoryExcel.Location = new System.Drawing.Point(133, 6);
            this.btnExportHistoryExcel.Name = "btnExportHistoryExcel";
            this.btnExportHistoryExcel.Size = new System.Drawing.Size(120, 28);
            this.btnExportHistoryExcel.TabIndex = 1;
            this.btnExportHistoryExcel.Text = "Export Excel";
            this.btnExportHistoryExcel.UseVisualStyleBackColor = false;
            this.btnExportHistoryExcel.Click += new System.EventHandler(this.btnExportHistoryExcel_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabReports);
            this.Controls.Add(this.panelTop);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartMed Pharmacy - Reports";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.tabSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesByDate)).EndInit();
            this.panelSalesSummary.ResumeLayout(false);
            this.panelSalesSummary.PerformLayout();
            this.tabStock.ResumeLayout(false);
            this.tabStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentStock)).EndInit();
            this.tabCustomerHistory.ResumeLayout(false);
            this.panelHistoryExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.Panel panelSalesSummary;
        private System.Windows.Forms.Label lblSalesOrderCountTitle;
        private System.Windows.Forms.Label lblSalesOrderCount;
        private System.Windows.Forms.Label lblSalesRevenueTitle;
        private System.Windows.Forms.Label lblSalesRevenue;
        private System.Windows.Forms.DataGridView dgvSalesByDate;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.Label lblCurrentStockTitle;
        private System.Windows.Forms.DataGridView dgvCurrentStock;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.TabPage tabCustomerHistory;
        private System.Windows.Forms.Panel panelHistoryExport;
        private System.Windows.Forms.Button btnExportHistoryPdf;
        private System.Windows.Forms.Button btnExportHistoryExcel;
        private System.Windows.Forms.DataGridView dgvCustomerHistory;
    }
}
