namespace Loginpage
{
    partial class Welcomepg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcomepg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Welcomelbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Footer = new System.Windows.Forms.Label();
            this.lblFeature1 = new System.Windows.Forms.Label();
            this.lblFeature2 = new System.Windows.Forms.Label();
            this.lblFeature3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.Subtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Welcomelbl);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Footer);
            this.panel1.Controls.Add(this.lblFeature1);
            this.panel1.Controls.Add(this.lblFeature2);
            this.panel1.Controls.Add(this.lblFeature3);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.Subtitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(93, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 376);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Welcomelbl
            // 
            this.Welcomelbl.Location = new System.Drawing.Point(35, 155);
            this.Welcomelbl.Name = "Welcomelbl";
            this.Welcomelbl.Size = new System.Drawing.Size(100, 23);
            this.Welcomelbl.TabIndex = 8;
            this.Welcomelbl.Click += new System.EventHandler(this.Welcomelbl_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(251, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Footer
            // 
            this.Footer.AutoSize = true;
            this.Footer.Location = new System.Drawing.Point(306, 342);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(19, 13);
            this.Footer.TabIndex = 6;
            this.Footer.Text = "00";
            this.Footer.Paint += new System.Windows.Forms.PaintEventHandler(this.Footer_Paint);
            // 
            // lblFeature1
            // 
            this.lblFeature1.AutoSize = true;
            this.lblFeature1.Location = new System.Drawing.Point(35, 207);
            this.lblFeature1.Name = "lblFeature1";
            this.lblFeature1.Size = new System.Drawing.Size(59, 13);
            this.lblFeature1.TabIndex = 5;
            this.lblFeature1.Text = "lblFeature1";
            // 
            // lblFeature2
            // 
            this.lblFeature2.AutoSize = true;
            this.lblFeature2.Location = new System.Drawing.Point(35, 234);
            this.lblFeature2.Name = "lblFeature2";
            this.lblFeature2.Size = new System.Drawing.Size(31, 13);
            this.lblFeature2.TabIndex = 4;
            this.lblFeature2.Text = "kkkk";
            // 
            // lblFeature3
            // 
            this.lblFeature3.AutoSize = true;
            this.lblFeature3.Location = new System.Drawing.Point(35, 264);
            this.lblFeature3.Name = "lblFeature3";
            this.lblFeature3.Size = new System.Drawing.Size(29, 13);
            this.lblFeature3.TabIndex = 3;
            this.lblFeature3.Text = "label";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(285, 276);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Get Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Location = new System.Drawing.Point(306, 118);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(15, 13);
            this.Subtitle.TabIndex = 1;
            this.Subtitle.Text = "w";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(261, 88);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Password Vault";
            // 
            // Welcomepg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Welcomepg";
            this.Text = "Welcomepg";
            this.Load += new System.EventHandler(this.Welcomepg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label Footer;
        private System.Windows.Forms.Label lblFeature1;
        private System.Windows.Forms.Label lblFeature2;
        private System.Windows.Forms.Label lblFeature3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Welcomelbl;
    }
}