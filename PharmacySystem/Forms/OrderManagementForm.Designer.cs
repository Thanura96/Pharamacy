namespace PharmacySystem.Forms
{
    partial class OrderManagementForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.cmbUpdateStatus = new System.Windows.Forms.ComboBox();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.btnViewPrescription = new System.Windows.Forms.Button();
            this.txtPrescriptionPath = new System.Windows.Forms.TextBox();
            this.lblPrescriptionPath = new System.Windows.Forms.Label();
            this.txtOrderItems = new System.Windows.Forms.TextBox();
            this.lblOrderItems = new System.Windows.Forms.Label();
            this.lblSelectedOrder = new System.Windows.Forms.Label();
            this.lblSelectedOrderHeader = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Order Management";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblSubtitle.Location = new System.Drawing.Point(22, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(235, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "View customer orders and track fulfillment";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(15, 95);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(550, 420);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.btnRefresh);
            this.panelDetails.Controls.Add(this.btnUpdateStatus);
            this.panelDetails.Controls.Add(this.cmbUpdateStatus);
            this.panelDetails.Controls.Add(this.lblUpdateStatus);
            this.panelDetails.Controls.Add(this.btnViewPrescription);
            this.panelDetails.Controls.Add(this.txtPrescriptionPath);
            this.panelDetails.Controls.Add(this.lblPrescriptionPath);
            this.panelDetails.Controls.Add(this.txtOrderItems);
            this.panelDetails.Controls.Add(this.lblOrderItems);
            this.panelDetails.Controls.Add(this.lblSelectedOrder);
            this.panelDetails.Controls.Add(this.lblSelectedOrderHeader);
            this.panelDetails.Location = new System.Drawing.Point(585, 95);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(350, 420);
            this.panelDetails.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(10, 365);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(328, 35);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh Orders List";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(220, 298);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(118, 30);
            this.btnUpdateStatus.TabIndex = 9;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // cmbUpdateStatus
            // 
            this.cmbUpdateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUpdateStatus.FormattingEnabled = true;
            this.cmbUpdateStatus.Location = new System.Drawing.Point(10, 300);
            this.cmbUpdateStatus.Name = "cmbUpdateStatus";
            this.cmbUpdateStatus.Size = new System.Drawing.Size(200, 25);
            this.cmbUpdateStatus.TabIndex = 8;
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUpdateStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblUpdateStatus.Location = new System.Drawing.Point(10, 280);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(95, 17);
            this.lblUpdateStatus.TabIndex = 7;
            this.lblUpdateStatus.Text = "Fulfill Status:";
            // 
            // btnViewPrescription
            // 
            this.btnViewPrescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnViewPrescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewPrescription.FlatAppearance.BorderSize = 0;
            this.btnViewPrescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPrescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewPrescription.ForeColor = System.Drawing.Color.White;
            this.btnViewPrescription.Location = new System.Drawing.Point(240, 228);
            this.btnViewPrescription.Name = "btnViewPrescription";
            this.btnViewPrescription.Size = new System.Drawing.Size(98, 27);
            this.btnViewPrescription.TabIndex = 6;
            this.btnViewPrescription.Text = "View File";
            this.btnViewPrescription.UseVisualStyleBackColor = false;
            this.btnViewPrescription.Click += new System.EventHandler(this.btnViewPrescription_Click);
            // 
            // txtPrescriptionPath
            // 
            this.txtPrescriptionPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrescriptionPath.Location = new System.Drawing.Point(10, 230);
            this.txtPrescriptionPath.Name = "txtPrescriptionPath";
            this.txtPrescriptionPath.ReadOnly = true;
            this.txtPrescriptionPath.Size = new System.Drawing.Size(220, 25);
            this.txtPrescriptionPath.TabIndex = 5;
            // 
            // lblPrescriptionPath
            // 
            this.lblPrescriptionPath.AutoSize = true;
            this.lblPrescriptionPath.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPrescriptionPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPrescriptionPath.Location = new System.Drawing.Point(10, 210);
            this.lblPrescriptionPath.Name = "lblPrescriptionPath";
            this.lblPrescriptionPath.Size = new System.Drawing.Size(117, 17);
            this.lblPrescriptionPath.TabIndex = 4;
            this.lblPrescriptionPath.Text = "Prescription File:";
            // 
            // txtOrderItems
            // 
            this.txtOrderItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtOrderItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOrderItems.Location = new System.Drawing.Point(10, 90);
            this.txtOrderItems.Multiline = true;
            this.txtOrderItems.Name = "txtOrderItems";
            this.txtOrderItems.ReadOnly = true;
            this.txtOrderItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOrderItems.Size = new System.Drawing.Size(328, 110);
            this.txtOrderItems.TabIndex = 3;
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOrderItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOrderItems.Location = new System.Drawing.Point(10, 70);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(86, 17);
            this.lblOrderItems.TabIndex = 2;
            this.lblOrderItems.Text = "Order Items:";
            // 
            // lblSelectedOrder
            // 
            this.lblSelectedOrder.AutoSize = true;
            this.lblSelectedOrder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelectedOrder.ForeColor = System.Drawing.Color.Black;
            this.lblSelectedOrder.Location = new System.Drawing.Point(10, 35);
            this.lblSelectedOrder.Name = "lblSelectedOrder";
            this.lblSelectedOrder.Size = new System.Drawing.Size(42, 19);
            this.lblSelectedOrder.TabIndex = 1;
            this.lblSelectedOrder.Text = "None";
            // 
            // lblSelectedOrderHeader
            // 
            this.lblSelectedOrderHeader.AutoSize = true;
            this.lblSelectedOrderHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelectedOrderHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSelectedOrderHeader.Location = new System.Drawing.Point(10, 10);
            this.lblSelectedOrderHeader.Name = "lblSelectedOrderHeader";
            this.lblSelectedOrderHeader.Size = new System.Drawing.Size(147, 20);
            this.lblSelectedOrderHeader.TabIndex = 0;
            this.lblSelectedOrderHeader.Text = "Selected Order Info";
            // 
            // OrderManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(950, 530);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OrderManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartMed Pharmacy - Order Management";
            this.Load += new System.EventHandler(this.OrderManagementForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblSelectedOrderHeader;
        private System.Windows.Forms.Label lblSelectedOrder;
        private System.Windows.Forms.Label lblOrderItems;
        private System.Windows.Forms.TextBox txtOrderItems;
        private System.Windows.Forms.Label lblPrescriptionPath;
        private System.Windows.Forms.TextBox txtPrescriptionPath;
        private System.Windows.Forms.Button btnViewPrescription;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.ComboBox cmbUpdateStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnRefresh;
    }
}
