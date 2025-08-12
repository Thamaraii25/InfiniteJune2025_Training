
namespace RailwayReservationADO
{
    partial class BookingHistory
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
            this.dgvBookingHistory = new System.Windows.Forms.DataGridView();
            this.btnCancelTicket = new System.Windows.Forms.Button();
            this.btnBackHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking History";
            // 
            // dgvBookingHistory
            // 
            this.dgvBookingHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookingHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookingHistory.Location = new System.Drawing.Point(100, 195);
            this.dgvBookingHistory.Name = "dgvBookingHistory";
            this.dgvBookingHistory.RowHeadersWidth = 62;
            this.dgvBookingHistory.RowTemplate.Height = 28;
            this.dgvBookingHistory.Size = new System.Drawing.Size(765, 392);
            this.dgvBookingHistory.TabIndex = 1;
            // 
            // btnCancelTicket
            // 
            this.btnCancelTicket.Location = new System.Drawing.Point(939, 309);
            this.btnCancelTicket.Name = "btnCancelTicket";
            this.btnCancelTicket.Size = new System.Drawing.Size(130, 53);
            this.btnCancelTicket.TabIndex = 2;
            this.btnCancelTicket.Text = "Cancel Ticket";
            this.btnCancelTicket.UseVisualStyleBackColor = true;
            this.btnCancelTicket.Click += new System.EventHandler(this.btnCancelTicket_Click);
            // 
            // btnBackHome
            // 
            this.btnBackHome.Location = new System.Drawing.Point(939, 405);
            this.btnBackHome.Name = "btnBackHome";
            this.btnBackHome.Size = new System.Drawing.Size(130, 47);
            this.btnBackHome.TabIndex = 3;
            this.btnBackHome.Text = "Close";
            this.btnBackHome.UseVisualStyleBackColor = true;
            this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
            // 
            // BookingHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 658);
            this.Controls.Add(this.btnBackHome);
            this.Controls.Add(this.btnCancelTicket);
            this.Controls.Add(this.dgvBookingHistory);
            this.Controls.Add(this.label1);
            this.Name = "BookingHistory";
            this.Text = "BookingHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBookingHistory;
        private System.Windows.Forms.Button btnCancelTicket;
        private System.Windows.Forms.Button btnBackHome;
    }
}