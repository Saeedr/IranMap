namespace IranMap
{
    partial class Form4
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
            this.pibIran = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pibIran)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pibIran
            // 
            this.pibIran.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pibIran.Location = new System.Drawing.Point(12, 12);
            this.pibIran.Name = "pibIran";
            this.pibIran.Size = new System.Drawing.Size(132, 80);
            this.pibIran.TabIndex = 1;
            this.pibIran.TabStop = false;
            this.pibIran.MouseLeave += new System.EventHandler(this.pibIran_MouseLeave);
            this.pibIran.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pibIran_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.pibIran);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 285);
            this.panel1.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.Location = new System.Drawing.Point(12, 209);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(433, 67);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 285);
            this.Controls.Add(this.panel1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pibIran)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pibIran;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfo;
    }
}