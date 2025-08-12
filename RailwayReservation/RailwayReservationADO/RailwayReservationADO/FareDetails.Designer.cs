
namespace RailwayReservationADO
{
    partial class FareDetails
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
            this.Sub = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFromSN = new System.Windows.Forms.ComboBox();
            this.cmbToSN = new System.Windows.Forms.ComboBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtFareAmount = new System.Windows.Forms.TextBox();
            this.btnAddFare = new System.Windows.Forms.Button();
            this.btnUpdateFare = new System.Windows.Forms.Button();
            this.btnDeleteFare = new System.Windows.Forms.Button();
            this.dgvFare = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrainCode = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFare)).BeginInit();
            this.SuspendLayout();
            // 
            // Sub
            // 
            this.Sub.AutoSize = true;
            this.Sub.Location = new System.Drawing.Point(524, 66);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(95, 20);
            this.Sub.TabIndex = 0;
            this.Sub.Text = "Fare Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Station Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Station Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Class";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(808, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fare Amount";
            // 
            // cmbFromSN
            // 
            this.cmbFromSN.FormattingEnabled = true;
            this.cmbFromSN.Location = new System.Drawing.Point(250, 152);
            this.cmbFromSN.Name = "cmbFromSN";
            this.cmbFromSN.Size = new System.Drawing.Size(121, 28);
            this.cmbFromSN.TabIndex = 6;
            // 
            // cmbToSN
            // 
            this.cmbToSN.FormattingEnabled = true;
            this.cmbToSN.Location = new System.Drawing.Point(623, 154);
            this.cmbToSN.Name = "cmbToSN";
            this.cmbToSN.Size = new System.Drawing.Size(121, 28);
            this.cmbToSN.TabIndex = 7;
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(623, 228);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(121, 26);
            this.txtClass.TabIndex = 8;
            // 
            // txtFareAmount
            // 
            this.txtFareAmount.Location = new System.Drawing.Point(959, 146);
            this.txtFareAmount.Name = "txtFareAmount";
            this.txtFareAmount.Size = new System.Drawing.Size(121, 26);
            this.txtFareAmount.TabIndex = 10;
            // 
            // btnAddFare
            // 
            this.btnAddFare.Location = new System.Drawing.Point(301, 307);
            this.btnAddFare.Name = "btnAddFare";
            this.btnAddFare.Size = new System.Drawing.Size(131, 39);
            this.btnAddFare.TabIndex = 13;
            this.btnAddFare.Text = "Add Fare";
            this.btnAddFare.UseVisualStyleBackColor = true;
            this.btnAddFare.Click += new System.EventHandler(this.btnAddFare_Click);
            // 
            // btnUpdateFare
            // 
            this.btnUpdateFare.Location = new System.Drawing.Point(514, 307);
            this.btnUpdateFare.Name = "btnUpdateFare";
            this.btnUpdateFare.Size = new System.Drawing.Size(131, 39);
            this.btnUpdateFare.TabIndex = 14;
            this.btnUpdateFare.Text = "Update Fare";
            this.btnUpdateFare.UseVisualStyleBackColor = true;
            this.btnUpdateFare.Click += new System.EventHandler(this.btnUpdateFare_Click);
            // 
            // btnDeleteFare
            // 
            this.btnDeleteFare.Location = new System.Drawing.Point(779, 307);
            this.btnDeleteFare.Name = "btnDeleteFare";
            this.btnDeleteFare.Size = new System.Drawing.Size(131, 39);
            this.btnDeleteFare.TabIndex = 15;
            this.btnDeleteFare.Text = "Delete Fare";
            this.btnDeleteFare.UseVisualStyleBackColor = true;
            this.btnDeleteFare.Click += new System.EventHandler(this.btnDeleteFare_Click);
            // 
            // dgvFare
            // 
            this.dgvFare.AllowUserToAddRows = false;
            this.dgvFare.AllowUserToDeleteRows = false;
            this.dgvFare.AllowUserToOrderColumns = true;
            this.dgvFare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFare.Location = new System.Drawing.Point(7, 381);
            this.dgvFare.Name = "dgvFare";
            this.dgvFare.RowHeadersWidth = 62;
            this.dgvFare.RowTemplate.Height = 28;
            this.dgvFare.Size = new System.Drawing.Size(1129, 268);
            this.dgvFare.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Train Code";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtTrainCode
            // 
            this.txtTrainCode.Location = new System.Drawing.Point(250, 237);
            this.txtTrainCode.Name = "txtTrainCode";
            this.txtTrainCode.Size = new System.Drawing.Size(121, 26);
            this.txtTrainCode.TabIndex = 18;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(972, 46);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 40);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FareDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1166, 661);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtTrainCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvFare);
            this.Controls.Add(this.btnDeleteFare);
            this.Controls.Add(this.btnUpdateFare);
            this.Controls.Add(this.btnAddFare);
            this.Controls.Add(this.txtFareAmount);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.cmbToSN);
            this.Controls.Add(this.cmbFromSN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sub);
            this.Name = "FareDetails";
            this.Text = "FareDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Sub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFromSN;
        private System.Windows.Forms.ComboBox cmbToSN;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtFareAmount;
        private System.Windows.Forms.Button btnAddFare;
        private System.Windows.Forms.Button btnUpdateFare;
        private System.Windows.Forms.Button btnDeleteFare;
        private System.Windows.Forms.DataGridView dgvFare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTrainCode;
        private System.Windows.Forms.Button btnBack;
    }
}