
namespace RailwayReservationADO
{
    partial class Payment
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
            this.txtTotalFare = new System.Windows.Forms.TextBox();
            this.txtUPI = new System.Windows.Forms.TextBox();
            this.btnPayment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter UPI ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Fare";
            // 
            // txtTotalFare
            // 
            this.txtTotalFare.Location = new System.Drawing.Point(648, 297);
            this.txtTotalFare.Name = "txtTotalFare";
            this.txtTotalFare.Size = new System.Drawing.Size(100, 26);
            this.txtTotalFare.TabIndex = 3;
            // 
            // txtUPI
            // 
            this.txtUPI.Location = new System.Drawing.Point(648, 213);
            this.txtUPI.Name = "txtUPI";
            this.txtUPI.Size = new System.Drawing.Size(100, 26);
            this.txtUPI.TabIndex = 4;
            // 
            // btnPayment
            // 
            this.btnPayment.AutoSize = true;
            this.btnPayment.Location = new System.Drawing.Point(495, 428);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(178, 30);
            this.btnPayment.TabIndex = 5;
            this.btnPayment.Text = "Submit To Book Ticket";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 657);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.txtUPI);
            this.Controls.Add(this.txtTotalFare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Payment";
            this.Text = "Enter UPI ID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalFare;
        private System.Windows.Forms.TextBox txtUPI;
        private System.Windows.Forms.Button btnPayment;
    }
}