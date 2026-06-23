namespace PharmacySystem.Forms
{
    partial class AdminDashboardForm
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnMedicines = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelAlerts = new System.Windows.Forms.Panel();
            this.lstExpired = new System.Windows.Forms.ListBox();
            this.lblExpiredHeader = new System.Windows.Forms.Label();
            this.lstExpiringSoon = new System.Windows.Forms.ListBox();
            this.lblExpiringSoonHeader = new System.Windows.Forms.Label();
            this.lblExpiryAlertSummary = new System.Windows.Forms.Label();
            this.lblAlertsTitle = new System.Windows.Forms.Label();
            this.btnRefreshDashboard = new System.Windows.Forms.Button();
            this.panelCards = new System.Windows.Forms.Panel();
            this.cardActiveOrders = new System.Windows.Forms.Panel();
            this.lblActiveOrdersValue = new System.Windows.Forms.Label();
            this.lblActiveOrdersTitle = new System.Windows.Forms.Label();
            this.cardLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.cardTotalMedicines = new System.Windows.Forms.Panel();
            this.lblTotalMedicinesValue = new System.Windows.Forms.Label();
            this.lblTotalMedicinesTitle = new System.Windows.Forms.Label();
            this.cardTotalSales = new System.Windows.Forms.Panel();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.lblTotalSalesTitle = new System.Windows.Forms.Label();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelAlerts.SuspendLayout();
            this.panelCards.SuspendLayout();
            this.cardActiveOrders.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            this.cardTotalMedicines.SuspendLayout();
            this.cardTotalSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.btnExit);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnOrders);
            this.panelSidebar.Controls.Add(this.btnSales);
            this.panelSidebar.Controls.Add(this.btnCustomers);
            this.panelSidebar.Controls.Add(this.btnMedicines);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 681);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(0, 621);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(220, 60);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(0, 320);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 60);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOrders.ForeColor = System.Drawing.Color.White;
            this.btnOrders.Location = new System.Drawing.Point(0, 260);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(220, 60);
            this.btnOrders.TabIndex = 4;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnSales
            // 
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSales.ForeColor = System.Drawing.Color.White;
            this.btnSales.Location = new System.Drawing.Point(0, 200);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(220, 60);
            this.btnSales.TabIndex = 3;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Location = new System.Drawing.Point(0, 140);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(220, 60);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnMedicines
            // 
            this.btnMedicines.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicines.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedicines.FlatAppearance.BorderSize = 0;
            this.btnMedicines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnMedicines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicines.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMedicines.ForeColor = System.Drawing.Color.White;
            this.btnMedicines.Location = new System.Drawing.Point(0, 80);
            this.btnMedicines.Name = "btnMedicines";
            this.btnMedicines.Size = new System.Drawing.Size(220, 60);
            this.btnMedicines.TabIndex = 1;
            this.btnMedicines.Text = "Medicines";
            this.btnMedicines.UseVisualStyleBackColor = true;
            this.btnMedicines.Click += new System.EventHandler(this.btnMedicines_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(24, 27);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(170, 25);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "SmartMed";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1044, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(25, 25);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(125, 30);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Dashboard";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.panelContent.Controls.Add(this.panelAlerts);
            this.panelContent.Controls.Add(this.panelCards);
            this.panelContent.Controls.Add(this.lblDashboardTitle);
            this.panelContent.Controls.Add(this.btnRefreshDashboard);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1044, 601);
            this.panelContent.TabIndex = 2;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDashboardTitle.Location = new System.Drawing.Point(23, 20);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(185, 25);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "Overview Summary";
            // 
            // btnRefreshDashboard
            // 
            this.btnRefreshDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshDashboard.FlatAppearance.BorderSize = 0;
            this.btnRefreshDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDashboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshDashboard.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDashboard.Location = new System.Drawing.Point(900, 18);
            this.btnRefreshDashboard.Name = "btnRefreshDashboard";
            this.btnRefreshDashboard.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshDashboard.TabIndex = 1;
            this.btnRefreshDashboard.Text = "Refresh";
            this.btnRefreshDashboard.UseVisualStyleBackColor = false;
            this.btnRefreshDashboard.Click += new System.EventHandler(this.btnRefreshDashboard_Click);
            // 
            // panelCards
            // 
            this.panelCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCards.Controls.Add(this.cardActiveOrders);
            this.panelCards.Controls.Add(this.cardLowStock);
            this.panelCards.Controls.Add(this.cardTotalMedicines);
            this.panelCards.Controls.Add(this.cardTotalSales);
            this.panelCards.Location = new System.Drawing.Point(20, 55);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(1000, 110);
            this.panelCards.TabIndex = 2;
            // 
            // cardTotalSales
            // 
            this.cardTotalSales.BackColor = System.Drawing.Color.White;
            this.cardTotalSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotalSales.Controls.Add(this.lblTotalSalesValue);
            this.cardTotalSales.Controls.Add(this.lblTotalSalesTitle);
            this.cardTotalSales.Location = new System.Drawing.Point(0, 0);
            this.cardTotalSales.Name = "cardTotalSales";
            this.cardTotalSales.Size = new System.Drawing.Size(240, 100);
            this.cardTotalSales.TabIndex = 0;
            // 
            // lblTotalSalesTitle
            // 
            this.lblTotalSalesTitle.AutoSize = true;
            this.lblTotalSalesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTotalSalesTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTotalSalesTitle.Name = "lblTotalSalesTitle";
            this.lblTotalSalesTitle.Size = new System.Drawing.Size(73, 19);
            this.lblTotalSalesTitle.TabIndex = 0;
            this.lblTotalSalesTitle.Text = "Total Sales";
            // 
            // lblTotalSalesValue
            // 
            this.lblTotalSalesValue.AutoSize = true;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalSalesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalSalesValue.Location = new System.Drawing.Point(12, 45);
            this.lblTotalSalesValue.Name = "lblTotalSalesValue";
            this.lblTotalSalesValue.Size = new System.Drawing.Size(88, 37);
            this.lblTotalSalesValue.TabIndex = 1;
            this.lblTotalSalesValue.Text = "$0.00";
            // 
            // cardTotalMedicines
            // 
            this.cardTotalMedicines.BackColor = System.Drawing.Color.White;
            this.cardTotalMedicines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotalMedicines.Controls.Add(this.lblTotalMedicinesValue);
            this.cardTotalMedicines.Controls.Add(this.lblTotalMedicinesTitle);
            this.cardTotalMedicines.Location = new System.Drawing.Point(252, 0);
            this.cardTotalMedicines.Name = "cardTotalMedicines";
            this.cardTotalMedicines.Size = new System.Drawing.Size(240, 100);
            this.cardTotalMedicines.TabIndex = 1;
            // 
            // lblTotalMedicinesTitle
            // 
            this.lblTotalMedicinesTitle.AutoSize = true;
            this.lblTotalMedicinesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalMedicinesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTotalMedicinesTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTotalMedicinesTitle.Name = "lblTotalMedicinesTitle";
            this.lblTotalMedicinesTitle.Size = new System.Drawing.Size(115, 19);
            this.lblTotalMedicinesTitle.TabIndex = 0;
            this.lblTotalMedicinesTitle.Text = "Total Medicines";
            // 
            // lblTotalMedicinesValue
            // 
            this.lblTotalMedicinesValue.AutoSize = true;
            this.lblTotalMedicinesValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalMedicinesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotalMedicinesValue.Location = new System.Drawing.Point(12, 45);
            this.lblTotalMedicinesValue.Name = "lblTotalMedicinesValue";
            this.lblTotalMedicinesValue.Size = new System.Drawing.Size(33, 37);
            this.lblTotalMedicinesValue.TabIndex = 1;
            this.lblTotalMedicinesValue.Text = "0";
            // 
            // cardLowStock
            // 
            this.cardLowStock.BackColor = System.Drawing.Color.White;
            this.cardLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardLowStock.Controls.Add(this.lblLowStockValue);
            this.cardLowStock.Controls.Add(this.lblLowStockTitle);
            this.cardLowStock.Location = new System.Drawing.Point(504, 0);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.Size = new System.Drawing.Size(240, 100);
            this.cardLowStock.TabIndex = 2;
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblLowStockTitle.Location = new System.Drawing.Point(15, 15);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(141, 19);
            this.lblLowStockTitle.TabIndex = 0;
            this.lblLowStockTitle.Text = "Low Stock Medicines";
            // 
            // lblLowStockValue
            // 
            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLowStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblLowStockValue.Location = new System.Drawing.Point(12, 45);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Size = new System.Drawing.Size(33, 37);
            this.lblLowStockValue.TabIndex = 1;
            this.lblLowStockValue.Text = "0";
            // 
            // cardActiveOrders
            // 
            this.cardActiveOrders.BackColor = System.Drawing.Color.White;
            this.cardActiveOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardActiveOrders.Controls.Add(this.lblActiveOrdersValue);
            this.cardActiveOrders.Controls.Add(this.lblActiveOrdersTitle);
            this.cardActiveOrders.Location = new System.Drawing.Point(756, 0);
            this.cardActiveOrders.Name = "cardActiveOrders";
            this.cardActiveOrders.Size = new System.Drawing.Size(240, 100);
            this.cardActiveOrders.TabIndex = 3;
            // 
            // lblActiveOrdersTitle
            // 
            this.lblActiveOrdersTitle.AutoSize = true;
            this.lblActiveOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActiveOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblActiveOrdersTitle.Location = new System.Drawing.Point(15, 15);
            this.lblActiveOrdersTitle.Name = "lblActiveOrdersTitle";
            this.lblActiveOrdersTitle.Size = new System.Drawing.Size(99, 19);
            this.lblActiveOrdersTitle.TabIndex = 0;
            this.lblActiveOrdersTitle.Text = "Active Orders";
            // 
            // lblActiveOrdersValue
            // 
            this.lblActiveOrdersValue.AutoSize = true;
            this.lblActiveOrdersValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblActiveOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblActiveOrdersValue.Location = new System.Drawing.Point(12, 45);
            this.lblActiveOrdersValue.Name = "lblActiveOrdersValue";
            this.lblActiveOrdersValue.Size = new System.Drawing.Size(33, 37);
            this.lblActiveOrdersValue.TabIndex = 1;
            this.lblActiveOrdersValue.Text = "0";
            // 
            // panelAlerts
            // 
            this.panelAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAlerts.BackColor = System.Drawing.Color.White;
            this.panelAlerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlerts.Controls.Add(this.lstExpired);
            this.panelAlerts.Controls.Add(this.lblExpiredHeader);
            this.panelAlerts.Controls.Add(this.lstExpiringSoon);
            this.panelAlerts.Controls.Add(this.lblExpiringSoonHeader);
            this.panelAlerts.Controls.Add(this.lblExpiryAlertSummary);
            this.panelAlerts.Controls.Add(this.lblAlertsTitle);
            this.panelAlerts.Location = new System.Drawing.Point(20, 180);
            this.panelAlerts.Name = "panelAlerts";
            this.panelAlerts.Size = new System.Drawing.Size(1000, 400);
            this.panelAlerts.TabIndex = 3;
            // 
            // lblAlertsTitle
            // 
            this.lblAlertsTitle.AutoSize = true;
            this.lblAlertsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlertsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblAlertsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAlertsTitle.Name = "lblAlertsTitle";
            this.lblAlertsTitle.Size = new System.Drawing.Size(130, 21);
            this.lblAlertsTitle.TabIndex = 0;
            this.lblAlertsTitle.Text = "Expiry Alerts";
            // 
            // lblExpiryAlertSummary
            // 
            this.lblExpiryAlertSummary.AutoSize = true;
            this.lblExpiryAlertSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpiryAlertSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblExpiryAlertSummary.Location = new System.Drawing.Point(16, 42);
            this.lblExpiryAlertSummary.Name = "lblExpiryAlertSummary";
            this.lblExpiryAlertSummary.Size = new System.Drawing.Size(220, 17);
            this.lblExpiryAlertSummary.TabIndex = 1;
            this.lblExpiryAlertSummary.Text = "Checking expiry notifications...";
            // 
            // lblExpiringSoonHeader
            // 
            this.lblExpiringSoonHeader.AutoSize = true;
            this.lblExpiringSoonHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblExpiringSoonHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblExpiringSoonHeader.Location = new System.Drawing.Point(16, 70);
            this.lblExpiringSoonHeader.Name = "lblExpiringSoonHeader";
            this.lblExpiringSoonHeader.Size = new System.Drawing.Size(220, 19);
            this.lblExpiringSoonHeader.TabIndex = 2;
            this.lblExpiringSoonHeader.Text = "Expiring Within 30 Days";
            // 
            // lstExpiringSoon
            // 
            this.lstExpiringSoon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstExpiringSoon.FormattingEnabled = true;
            this.lstExpiringSoon.ItemHeight = 17;
            this.lstExpiringSoon.Location = new System.Drawing.Point(20, 95);
            this.lstExpiringSoon.Name = "lstExpiringSoon";
            this.lstExpiringSoon.Size = new System.Drawing.Size(460, 276);
            this.lstExpiringSoon.TabIndex = 3;
            // 
            // lblExpiredHeader
            // 
            this.lblExpiredHeader.AutoSize = true;
            this.lblExpiredHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblExpiredHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblExpiredHeader.Location = new System.Drawing.Point(500, 70);
            this.lblExpiredHeader.Name = "lblExpiredHeader";
            this.lblExpiredHeader.Size = new System.Drawing.Size(140, 19);
            this.lblExpiredHeader.TabIndex = 4;
            this.lblExpiredHeader.Text = "Expired Medicines";
            // 
            // lstExpired
            // 
            this.lstExpired.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstExpired.FormattingEnabled = true;
            this.lstExpired.ItemHeight = 17;
            this.lstExpired.Location = new System.Drawing.Point(504, 95);
            this.lstExpired.Name = "lstExpired";
            this.lstExpired.Size = new System.Drawing.Size(480, 276);
            this.lstExpired.TabIndex = 5;
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartMed Pharmacy - Admin";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelAlerts.ResumeLayout(false);
            this.panelAlerts.PerformLayout();
            this.panelCards.ResumeLayout(false);
            this.cardActiveOrders.ResumeLayout(false);
            this.cardActiveOrders.PerformLayout();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            this.cardTotalMedicines.ResumeLayout(false);
            this.cardTotalMedicines.PerformLayout();
            this.cardTotalSales.ResumeLayout(false);
            this.cardTotalSales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnMedicines;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Button btnRefreshDashboard;
        private System.Windows.Forms.Panel panelCards;
        private System.Windows.Forms.Panel cardTotalSales;
        private System.Windows.Forms.Label lblTotalSalesTitle;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Panel cardTotalMedicines;
        private System.Windows.Forms.Label lblTotalMedicinesTitle;
        private System.Windows.Forms.Label lblTotalMedicinesValue;
        private System.Windows.Forms.Panel cardLowStock;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.Label lblLowStockValue;
        private System.Windows.Forms.Panel cardActiveOrders;
        private System.Windows.Forms.Label lblActiveOrdersTitle;
        private System.Windows.Forms.Label lblActiveOrdersValue;
        private System.Windows.Forms.Panel panelAlerts;
        private System.Windows.Forms.Label lblAlertsTitle;
        private System.Windows.Forms.Label lblExpiryAlertSummary;
        private System.Windows.Forms.Label lblExpiringSoonHeader;
        private System.Windows.Forms.ListBox lstExpiringSoon;
        private System.Windows.Forms.Label lblExpiredHeader;
        private System.Windows.Forms.ListBox lstExpired;
    }
}
