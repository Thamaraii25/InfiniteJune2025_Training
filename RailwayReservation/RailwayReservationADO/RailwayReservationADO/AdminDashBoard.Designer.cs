
namespace RailwayReservationADO
{
    partial class AdminDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashBoard));
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnManageTrain = new System.Windows.Forms.Button();
            this.btnManageStation = new System.Windows.Forms.Button();
            this.btnManageFare = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To Railway Reservation System";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(426, 230);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 20);
            this.linkLabel1.TabIndex = 1;
            // 
            // btnManageTrain
            // 
            this.btnManageTrain.Location = new System.Drawing.Point(837, 287);
            this.btnManageTrain.Name = "btnManageTrain";
            this.btnManageTrain.Size = new System.Drawing.Size(135, 49);
            this.btnManageTrain.TabIndex = 2;
            this.btnManageTrain.Text = "Manage Train";
            this.btnManageTrain.UseVisualStyleBackColor = true;
            this.btnManageTrain.Click += new System.EventHandler(this.btnManageTrain_Click);
            // 
            // btnManageStation
            // 
            this.btnManageStation.Location = new System.Drawing.Point(837, 181);
            this.btnManageStation.Name = "btnManageStation";
            this.btnManageStation.Size = new System.Drawing.Size(135, 48);
            this.btnManageStation.TabIndex = 3;
            this.btnManageStation.Text = "Manage Station";
            this.btnManageStation.UseVisualStyleBackColor = true;
            this.btnManageStation.Click += new System.EventHandler(this.btnManageStation_Click);
            // 
            // btnManageFare
            // 
            this.btnManageFare.Location = new System.Drawing.Point(837, 396);
            this.btnManageFare.Name = "btnManageFare";
            this.btnManageFare.Size = new System.Drawing.Size(135, 47);
            this.btnManageFare.TabIndex = 4;
            this.btnManageFare.Text = "Manage Fare";
            this.btnManageFare.UseVisualStyleBackColor = true;
            this.btnManageFare.Click += new System.EventHandler(this.btnManageFare_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(837, 497);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(135, 42);
            this.btnSignOut.TabIndex = 5;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(88, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(668, 428);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // AdminDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 644);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnManageFare);
            this.Controls.Add(this.btnManageStation);
            this.Controls.Add(this.btnManageTrain);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Name = "AdminDashBoard";
            this.Text = "AdminDashBoard";
            this.Load += new System.EventHandler(this.AdminDashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnManageTrain;
        private System.Windows.Forms.Button btnManageStation;
        private System.Windows.Forms.Button btnManageFare;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}