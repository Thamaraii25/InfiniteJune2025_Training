
namespace RailwayReservationADO
{
    partial class ManageStation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.btnAddStation = new System.Windows.Forms.Button();
            this.btnUpdateStationName = new System.Windows.Forms.Button();
            this.btnDeleteStationName = new System.Windows.Forms.Button();
            this.dgvManageStations = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageStations)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Stations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Station Name";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(598, 148);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(172, 26);
            this.txtStationName.TabIndex = 2;
            // 
            // btnAddStation
            // 
            this.btnAddStation.Location = new System.Drawing.Point(259, 220);
            this.btnAddStation.Name = "btnAddStation";
            this.btnAddStation.Size = new System.Drawing.Size(109, 39);
            this.btnAddStation.TabIndex = 3;
            this.btnAddStation.Text = "Add ";
            this.btnAddStation.UseVisualStyleBackColor = true;
            this.btnAddStation.Click += new System.EventHandler(this.btnAddStation_Click);
            // 
            // btnUpdateStationName
            // 
            this.btnUpdateStationName.Location = new System.Drawing.Point(524, 220);
            this.btnUpdateStationName.Name = "btnUpdateStationName";
            this.btnUpdateStationName.Size = new System.Drawing.Size(109, 39);
            this.btnUpdateStationName.TabIndex = 4;
            this.btnUpdateStationName.Text = "Update";
            this.btnUpdateStationName.UseVisualStyleBackColor = true;
            this.btnUpdateStationName.Click += new System.EventHandler(this.btnUpdateStationName_Click);
            // 
            // btnDeleteStationName
            // 
            this.btnDeleteStationName.Location = new System.Drawing.Point(803, 220);
            this.btnDeleteStationName.Name = "btnDeleteStationName";
            this.btnDeleteStationName.Size = new System.Drawing.Size(109, 39);
            this.btnDeleteStationName.TabIndex = 5;
            this.btnDeleteStationName.Text = "Delete";
            this.btnDeleteStationName.UseVisualStyleBackColor = true;
            this.btnDeleteStationName.Click += new System.EventHandler(this.btnDeleteStationName_Click);
            // 
            // dgvManageStations
            // 
            this.dgvManageStations.AllowUserToAddRows = false;
            this.dgvManageStations.AllowUserToDeleteRows = false;
            this.dgvManageStations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManageStations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvManageStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageStations.Location = new System.Drawing.Point(1, 315);
            this.dgvManageStations.Name = "dgvManageStations";
            this.dgvManageStations.RowHeadersWidth = 62;
            this.dgvManageStations.RowTemplate.Height = 28;
            this.dgvManageStations.Size = new System.Drawing.Size(1150, 308);
            this.dgvManageStations.TabIndex = 6;
            this.dgvManageStations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManageStations_CellClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(998, 48);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 38);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManageStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 645);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvManageStations);
            this.Controls.Add(this.btnDeleteStationName);
            this.Controls.Add(this.btnUpdateStationName);
            this.Controls.Add(this.btnAddStation);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageStation";
            this.Text = "ManageStation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageStations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Button btnAddStation;
        private System.Windows.Forms.Button btnUpdateStationName;
        private System.Windows.Forms.Button btnDeleteStationName;
        private System.Windows.Forms.DataGridView dgvManageStations;
        private System.Windows.Forms.Button btnBack;
    }
}