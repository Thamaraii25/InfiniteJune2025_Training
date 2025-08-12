
namespace RailwayReservationADO
{
    partial class ManageExistingTrain
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
            this.dgvManageExistingTrain = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTrain = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageExistingTrain)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Existing Train";
            // 
            // dgvManageExistingTrain
            // 
            this.dgvManageExistingTrain.AllowUserToOrderColumns = true;
            this.dgvManageExistingTrain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManageExistingTrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageExistingTrain.Location = new System.Drawing.Point(57, 207);
            this.dgvManageExistingTrain.Name = "dgvManageExistingTrain";
            this.dgvManageExistingTrain.RowHeadersWidth = 62;
            this.dgvManageExistingTrain.RowTemplate.Height = 28;
            this.dgvManageExistingTrain.Size = new System.Drawing.Size(1056, 417);
            this.dgvManageExistingTrain.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(798, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Add New Train...Click Here...";
            // 
            // btnAddTrain
            // 
            this.btnAddTrain.Location = new System.Drawing.Point(1012, 126);
            this.btnAddTrain.Name = "btnAddTrain";
            this.btnAddTrain.Size = new System.Drawing.Size(83, 27);
            this.btnAddTrain.TabIndex = 3;
            this.btnAddTrain.Text = "Add Train";
            this.btnAddTrain.UseVisualStyleBackColor = true;
            this.btnAddTrain.Click += new System.EventHandler(this.btnAddTrain_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1012, 45);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 35);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManageExistingTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 661);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddTrain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvManageExistingTrain);
            this.Controls.Add(this.label1);
            this.Name = "ManageExistingTrain";
            this.Text = "ManageExistingTrain";
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageExistingTrain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvManageExistingTrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTrain;
        private System.Windows.Forms.Button btnBack;
    }
}