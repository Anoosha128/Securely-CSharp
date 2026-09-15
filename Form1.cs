using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using ClosedXML.Excel;
//using System.IO;




namespace Loginpage
{
    
   
    public partial class Loginpg : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;
Initial Catalog=LoginDB;
Integrated Security=True;
TrustServerCertificate=True;";
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Loginpg()
        {
         
            InitializeComponent();
            this.BackColor = Color.FromArgb(12, 15, 28);
            this.ForeColor = Color.White;
           
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
           
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            textBox1.BackColor = Color.FromArgb(22, 24, 42);
            textBox1.ForeColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            

            textBox2.BackColor = Color.FromArgb(22, 24, 42);
            textBox2.ForeColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            //textBox1.BackColor = Color.FromArgb(35, 35, 35);
            //textBox1.ForeColor = Color.White;
            //textBox1.BorderStyle = BorderStyle.None;
            //textBox2.BackColor = Color.FromArgb(35, 35, 35);
            //textBox2.ForeColor = Color.White;
            //textBox2.BorderStyle = BorderStyle.None;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.FromArgb(180, 180, 180);
            label3.ForeColor = Color.FromArgb(180, 180, 180);
            login.BackColor = Color.FromArgb(104, 76, 255);
            login.ForeColor = Color.White;

            login.FlatStyle = FlatStyle.Flat;
            login.FlatAppearance.BorderSize = 0;

            login.Font = new Font("Segoe UI Semibold", 12F);

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(1, 1, Width - 4, Height - 4);

                GraphicsPath path = new GraphicsPath();
                int radius = 20;

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Soft glow
               
                using (SolidBrush glow = new SolidBrush(Color.FromArgb(25,110,90,255)))
{
    e.Graphics.FillEllipse(glow,-180,-100,420,420);

    e.Graphics.FillEllipse(glow,650,350,350,350);
}

                // Gradient border
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(110, 90, 255),
                    Color.FromArgb(60, 45, 170),
                    LinearGradientMode.Vertical))
                {
                    using (Pen border = new Pen(brush, 2))
                    {
                        e.Graphics.DrawPath(border, path);
                    }
                }

                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

                panelOuter.BackColor = Color.FromArgb(110, 90, 255);

                panelInner.BackColor = Color.FromArgb(22, 24, 42);

                panelInner.Location = new Point(2, 2);
                panelInner.Size = new Size(panelOuter.Width - 4, panelOuter.Height - 4);

                panelOuter.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, panelOuter.Width, panelOuter.Height, 20, 20));

                panelInner.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, panelInner.Width, panelInner.Height, 18, 18));
            }
            login.Region = Region.FromHrgn(
           CreateRoundRectRgn(
           0,
           0,
           login.Width,
           login.Height,
           25,
           25));
        }
        

       
            private void panelOuter_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(1, 1, panelOuter.Width - 3, panelOuter.Height - 3);

            int radius = 20;

            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            using (Pen glow = new Pen(Color.FromArgb(45, 200, 200, 200), 6))
            {
                e.Graphics.DrawPath(glow, path);
            }

            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    rect,
                    Color.FromArgb(120, 95, 255),
                    Color.FromArgb(70, 50, 180),
                    LinearGradientMode.Vertical))
            {
                using (Pen pen = new Pen(brush, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(90, 95, 100);
            panel1.Padding = new Padding(2);
        }
     
     
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(12, 15, 28),
                Color.FromArgb(25, 30, 55),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            textBox1.Text = "Email";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Password";
            textBox2.ForeColor = Color.Gray;
            pictureBox1.BackColor = Color.FromArgb(22, 24, 42);
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            panel2.BackColor = Color.FromArgb(90, 95, 100);
            panel2.Padding = new Padding(2);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Forget_Password fg = new Forget_Password();
            fg.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Signup_page sp = new Signup_page();
            sp.Show();
            this.Hide();
        }

    


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Email")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Email";
                textBox1.ForeColor = Color.White;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            startpage start = new startpage();
            start.Show();
            this.Hide();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text =="Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.White;
            }
        }

        private void login_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text.Trim() == "" ||
        textBox1.Text == "Email" ||
        textBox2.Text.Trim() == "" ||
        textBox2.Text == "Password")
                {
                    MessageBox.Show("Please enter Email and Password.");
                    return;
                }

                if (!textBox1.Text.Trim().EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Please enter a valid Gmail address (example@gmail.com).",
                                    "Invalid Email",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();

                    SqlCommand checkEmail = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Email=@Email", con);

                    checkEmail.Parameters.AddWithValue("@Email", textBox1.Text.Trim());

                    int emailExists = (int)checkEmail.ExecuteScalar();

                    if (emailExists == 0)
                    {
                        MessageBox.Show("No account found. Please signup first!");
                        return;
                    }
                   
                    SqlCommand loginCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Email=@Email AND Password=@Password", con);

                    loginCmd.Parameters.AddWithValue("@Email", textBox1.Text.Trim());
                    loginCmd.Parameters.AddWithValue("@Password", textBox2.Text);

                    int loginSuccess = (int)loginCmd.ExecuteScalar();

                    if (loginSuccess > 0)
                    {
                        MessageBox.Show("Login Successful!");

                        loading load = new loading();
                        load.Show();

                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Incorrect Password!");
                    }
    //                SqlCommand Cmd = new SqlCommand(
    //"SELECT FullName FROM Users WHERE Email=@Email AND Password=@Password", con);

    //                Cmd.Parameters.AddWithValue("@Email", textBox1.Text.Trim());
    //                Cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                   

                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
    }
    

    
