
namespace RailwayReservationADO
{
    partial class ManageTrain
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.txtTrainCode = new System.Windows.Forms.TextBox();
            this.txtTrainName = new System.Windows.Forms.TextBox();
            this.dgvRoutes = new System.Windows.Forms.DataGridView();
            this.txtStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clbRunningDays = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddTrain = new System.Windows.Forms.Button();
            this.btnManageExistingTrain = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvSeats = new System.Windows.Forms.DataGridView();
            this.txtClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCoachCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSeatCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancelTrain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Train Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Train Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Source";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(875, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Destination";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(654, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Running Days";
            // 
            // cmbSource
            // 
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(719, 112);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(121, 28);
            this.cmbSource.TabIndex = 6;
            // 
            // cmbDestination
            // 
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(997, 112);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(121, 28);
            this.cmbDestination.TabIndex = 7;
            // 
            // txtTrainCode
            // 
            this.txtTrainCode.Location = new System.Drawing.Point(155, 120);
            this.txtTrainCode.Name = "txtTrainCode";
            this.txtTrainCode.Size = new System.Drawing.Size(121, 26);
            this.txtTrainCode.TabIndex = 8;
            // 
            // txtTrainName
            // 
            this.txtTrainName.Location = new System.Drawing.Point(452, 117);
            this.txtTrainName.Name = "txtTrainName";
            this.txtTrainName.Size = new System.Drawing.Size(121, 26);
            this.txtTrainName.TabIndex = 9;
            // 
            // dgvRoutes
            // 
            this.dgvRoutes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoutes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoutes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtStationName,
            this.ArrivalTime,
            this.DepartureTime,
            this.RouteOrder});
            this.dgvRoutes.Location = new System.Drawing.Point(53, 258);
            this.dgvRoutes.Name = "dgvRoutes";
            this.dgvRoutes.RowHeadersWidth = 62;
            this.dgvRoutes.RowTemplate.Height = 28;
            this.dgvRoutes.Size = new System.Drawing.Size(494, 139);
            this.dgvRoutes.TabIndex = 10;
            // 
            // txtStationName
            // 
            this.txtStationName.HeaderText = "Station Name";
            this.txtStationName.MinimumWidth = 8;
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.HeaderText = "Arrival Time";
            this.ArrivalTime.MinimumWidth = 8;
            this.ArrivalTime.Name = "ArrivalTime";
            this.ArrivalTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DepartureTime
            // 
            this.DepartureTime.HeaderText = "DepartureTime";
            this.DepartureTime.MinimumWidth = 8;
            this.DepartureTime.Name = "DepartureTime";
            // 
            // RouteOrder
            // 
            this.RouteOrder.HeaderText = "RouteOrder";
            this.RouteOrder.MinimumWidth = 8;
            this.RouteOrder.Name = "RouteOrder";
            // 
            // clbRunningDays
            // 
            this.clbRunningDays.FormattingEnabled = true;
            this.clbRunningDays.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thrusday",
            "Friday",
            "Saturday"});
            this.clbRunningDays.Location = new System.Drawing.Point(658, 246);
            this.clbRunningDays.Name = "clbRunningDays";
            this.clbRunningDays.Size = new System.Drawing.Size(143, 165);
            this.clbRunningDays.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Enter All the Routes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(520, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Manage Trains";
            // 
            // btnAddTrain
            // 
            this.btnAddTrain.Location = new System.Drawing.Point(926, 258);
            this.btnAddTrain.Name = "btnAddTrain";
            this.btnAddTrain.Size = new System.Drawing.Size(193, 45);
            this.btnAddTrain.TabIndex = 16;
            this.btnAddTrain.Text = "Add Train";
            this.btnAddTrain.UseVisualStyleBackColor = true;
            this.btnAddTrain.Click += new System.EventHandler(this.btnAddTrain_Click);
            // 
            // btnManageExistingTrain
            // 
            this.btnManageExistingTrain.Location = new System.Drawing.Point(926, 391);
            this.btnManageExistingTrain.Name = "btnManageExistingTrain";
            this.btnManageExistingTrain.Size = new System.Drawing.Size(193, 45);
            this.btnManageExistingTrain.TabIndex = 17;
            this.btnManageExistingTrain.Text = "Manage Existing Train";
            this.btnManageExistingTrain.UseVisualStyleBackColor = true;
            this.btnManageExistingTrain.Click += new System.EventHandler(this.btnManageExistingTrain_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(639, 513);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(193, 45);
            this.btnUpdateStatus.TabIndex = 18;
            this.btnUpdateStatus.Text = "Update Train Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBack.Location = new System.Drawing.Point(997, 27);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(122, 39);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvSeats
            // 
            this.dgvSeats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtClass,
            this.txtCoachCount,
            this.txtSeatCount});
            this.dgvSeats.Location = new System.Drawing.Point(53, 483);
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.RowHeadersWidth = 62;
            this.dgvSeats.RowTemplate.Height = 28;
            this.dgvSeats.Size = new System.Drawing.Size(483, 117);
            this.dgvSeats.TabIndex = 20;
            // 
            // txtClass
            // 
            this.txtClass.HeaderText = "Class";
            this.txtClass.MinimumWidth = 8;
            this.txtClass.Name = "txtClass";
            // 
            // txtCoachCount
            // 
            this.txtCoachCount.HeaderText = "Coach Count";
            this.txtCoachCount.MinimumWidth = 8;
            this.txtCoachCount.Name = "txtCoachCount";
            // 
            // txtSeatCount
            // 
            this.txtSeatCount.HeaderText = "Seat Count Per Coach";
            this.txtSeatCount.MinimumWidth = 8;
            this.txtSeatCount.Name = "txtSeatCount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(235, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Enter Seat Count In Each Class";
            // 
            // btnCancelTrain
            // 
            this.btnCancelTrain.Location = new System.Drawing.Point(926, 504);
            this.btnCancelTrain.Name = "btnCancelTrain";
            this.btnCancelTrain.Size = new System.Drawing.Size(193, 48);
            this.btnCancelTrain.TabIndex = 22;
            this.btnCancelTrain.Text = "Cancel Train";
            this.btnCancelTrain.UseVisualStyleBackColor = true;
            this.btnCancelTrain.Click += new System.EventHandler(this.btnCancelTrain_Click);
            // 
            // ManageTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 638);
            this.Controls.Add(this.btnCancelTrain);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvSeats);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnManageExistingTrain);
            this.Controls.Add(this.btnAddTrain);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clbRunningDays);
            this.Controls.Add(this.dgvRoutes);
            this.Controls.Add(this.txtTrainName);
            this.Controls.Add(this.txtTrainCode);
            this.Controls.Add(this.cmbDestination);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageTrain";
            this.Text = "ManageTrains";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.TextBox txtTrainCode;
        private System.Windows.Forms.TextBox txtTrainName;
        private System.Windows.Forms.DataGridView dgvRoutes;
        private System.Windows.Forms.CheckedListBox clbRunningDays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddTrain;
        private System.Windows.Forms.Button btnManageExistingTrain;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvSeats;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCoachCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSeatCount;
        private System.Windows.Forms.Button btnCancelTrain;
    }
}