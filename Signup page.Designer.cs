namespace Loginpage
{
    partial class Signup_page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup_page));
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelInner = new System.Windows.Forms.Panel();
            this.Emailtxtbox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.signupbtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOuter.SuspendLayout();
            this.panelInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelInner);
            this.panelOuter.Location = new System.Drawing.Point(249, 89);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(291, 294);
            this.panelOuter.TabIndex = 1;
            this.panelOuter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOuter_Paint);
            // 
            // panelInner
            // 
            this.panelInner.Controls.Add(this.Emailtxtbox);
            this.panelInner.Controls.Add(this.panel3);
            this.panelInner.Controls.Add(this.label3);
            this.panelInner.Controls.Add(this.textBox2);
            this.panelInner.Controls.Add(this.pictureBox1);
            this.panelInner.Controls.Add(this.panel2);
            this.panelInner.Controls.Add(this.signupbtn);
            this.panelInner.Controls.Add(this.textBox1);
            this.panelInner.Controls.Add(this.panel1);
            this.panelInner.Controls.Add(this.label1);
            this.panelInner.Location = new System.Drawing.Point(3, -1);
            this.panelInner.Name = "panelInner";
            this.panelInner.Size = new System.Drawing.Size(283, 290);
            this.panelInner.TabIndex = 0;
            // 
            // Emailtxtbox
            // 
            this.Emailtxtbox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Emailtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Emailtxtbox.Location = new System.Drawing.Point(20, 115);
            this.Emailtxtbox.Name = "Emailtxtbox";
            this.Emailtxtbox.Size = new System.Drawing.Size(241, 13);
            this.Emailtxtbox.TabIndex = 12;
            this.Emailtxtbox.Text = "Email";
            this.Emailtxtbox.TextChanged += new System.EventHandler(this.Emailtxtbox_TextChanged);
            this.Emailtxtbox.Enter += new System.EventHandler(this.Emailtxtbox_Enter);
            this.Emailtxtbox.Leave += new System.EventHandler(this.Emailtxtbox_Leave);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(20, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 10);
            this.panel3.TabIndex = 13;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(17, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "< Back";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(20, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(241, 13);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Password";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(229, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(20, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 10);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // signupbtn
            // 
            this.signupbtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.signupbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signupbtn.Location = new System.Drawing.Point(79, 223);
            this.signupbtn.Name = "signupbtn";
            this.signupbtn.Size = new System.Drawing.Size(113, 35);
            this.signupbtn.TabIndex = 6;
            this.signupbtn.Text = "Sign up";
            this.signupbtn.UseVisualStyleBackColor = false;
            this.signupbtn.Click += new System.EventHandler(this.signupbtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(20, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 13);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "User Name";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(20, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 10);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(92, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Signup";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Signup_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelOuter);
            this.Name = "Signup_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signup_page";
            this.Load += new System.EventHandler(this.Signup_page_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Signup_page_Paint);
            this.panelOuter.ResumeLayout(false);
            this.panelInner.ResumeLayout(false);
            this.panelInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelInner;
        private System.Windows.Forms.Button signupbtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Emailtxtbox;
        private System.Windows.Forms.Panel panel3;
    }
}