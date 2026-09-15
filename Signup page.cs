using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Loginpage
{
    public partial class Signup_page : Form
        
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
        public Signup_page()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            textBox1.BackColor = Color.FromArgb(35, 35, 45);
            //textBox1.ForeColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox2.BackColor = Color.FromArgb(35, 35, 45);
            //textBox2.ForeColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            Emailtxtbox.BorderStyle = BorderStyle.None;
            Emailtxtbox.BackColor = Color.FromArgb(35, 35, 45);

        }
   
        private void Signup_page_Paint(object sender, PaintEventArgs e)

        {//Border colour
            Graphics g = e.Graphics;

            g.DrawLine(new Pen(Color.SkyBlue, 2), 0, 0, Width, 0);
            g.DrawLine(new Pen(Color.LightSkyBlue, 2), Width - 1, 0, Width - 1, Height);
            g.DrawLine(new Pen(Color.DeepSkyBlue, 2), Width - 1, Height - 1, 0, Height - 1);
            g.DrawLine(new Pen(Color.Cyan, 2), 0, Height - 1, 0, 0);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Cyan, 3)) // Border color and thickness
            {
                //e.Graphics.DrawRectangle(pen, 1, 1, this.Width - 4, this.Height - 4);
                //Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

                //panelOuter.BackColor = Color.Cyan;
                panelOuter.BackColor = Color.DeepSkyBlue;
                panelInner.BackColor = Color.FromArgb(30, 35, 45);
                //panelInner.BackColor = Color.FromArgb(35, 35, 35);

                panelInner.Location = new Point(2, 2);
                panelInner.Size = new Size(panelOuter.Width - 4, panelOuter.Height - 4);

                panelOuter.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, panelOuter.Width, panelOuter.Height, 20, 20));

                panelInner.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, panelInner.Width, panelInner.Height, 18, 18));
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(20, 20, 20),  // Top
Color.FromArgb(0, 70, 90),    // Bottom
                              //                        Color.FromArgb(20, 20, 20),      // Dark background
                              //                Color.FromArgb(0, 90, 100),
                              ////                Color.FromArgb(20, 20, 20),
                              ////Color.FromArgb(35, 45, 50),  // End color
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }


        private void Signup_page_Load(object sender, EventArgs e)
        {
            textBox1.Text = "User Name";
            textBox1.ForeColor = Color.Gray;
            Emailtxtbox.Text = "Email";
            Emailtxtbox.ForeColor = Color.Gray;
            textBox2.Text = "Password";
            textBox2.ForeColor = Color.Gray;
            pictureBox1.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

        }

        private void panelOuter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Padding = new Padding(2);
        }


        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.PasswordChar =  '*';
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            panel2.BackColor = Color.DeepSkyBlue;
            panel2.Padding = new Padding(2);
        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (textBox1.Text.Trim() == "" ||
                Emailtxtbox.Text.Trim() == "" ||
                textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            // Validate Gmail address
            if (!Emailtxtbox.Text.Trim().EndsWith("@gmail.com" ))
            {
                MessageBox.Show("Please enter a valid Gmail address (example@gmail.com).");
                return;
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Check if email already exists
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email=@Email";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@Email", Emailtxtbox.Text.Trim());

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Email already exists.");
                    return;
                }

                // Insert new user
                string insertQuery = @"INSERT INTO Users
                               (FullName, Email, Password)
                               VALUES
                               (@Name, @Email, @Password)";

                SqlCommand cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", Emailtxtbox.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Account Created Successfully!");

                textBox1.Clear();
                Emailtxtbox.Clear();
                textBox2.Clear();
            }

            loading wel = new loading();
            wel.Show();
            this.Hide();

        }
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();

            //    SqlCommand cmd = new SqlCommand(
            //        "INSERT INTO Users(Username,Password) VALUES(@u,@p)", con);

            //    cmd.Parameters.AddWithValue("@u", textBox1.Text);
            //    cmd.Parameters.AddWithValue("@p", textBox2.Text);

            //    cmd.ExecuteNonQuery();

            //    MessageBox.Show("Account Created Successfully!");
            //};
        

        private void label3_Click(object sender, EventArgs e)
        {
            startpage start = new startpage();
            start.Show();
            this.Hide();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.White;
            }
        }

        private void Emailtxtbox_Enter(object sender, EventArgs e)
        {
            if (Emailtxtbox.Text == "Email")
            {
                Emailtxtbox.Text = "";
                Emailtxtbox.ForeColor = Color.White;
            }
        }

        private void Emailtxtbox_Leave(object sender, EventArgs e)
        {
            if (Emailtxtbox.Text == "")
            {
                Emailtxtbox.Text = "Email";
                Emailtxtbox.ForeColor = Color.White;
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.DeepSkyBlue;
            panel3.Padding = new Padding(2);
        }

        private void Emailtxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }


