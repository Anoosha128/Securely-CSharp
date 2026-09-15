using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loginpage
{

    public partial class Forget_Password : Form
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
        public Forget_Password()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(30, 21, 48);
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            textBox1.BackColor = Color.FromArgb(35, 35, 45);
            //textBox1.ForeColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox2.BackColor = Color.FromArgb(35, 35, 45);
            //textBox2.ForeColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            textBox3.BackColor = Color.FromArgb(35, 35, 45);
            //textBox2.ForeColor = Color.White;
            textBox3.BorderStyle = BorderStyle.None;
        }
        private void Forget_Password_Paint(object sender, PaintEventArgs e)

        {//Border colour
            Graphics g = e.Graphics;

            g.DrawLine(new Pen(Color.SkyBlue, 2), 0, 0, Width, 0);
            g.DrawLine(new Pen(Color.LightSkyBlue, 2), Width - 1, 0, Width - 1, Height);
            g.DrawLine(new Pen(Color.DeepSkyBlue, 2), Width - 1, Height - 1, 0, Height - 1);
            g.DrawLine(new Pen(Color.Cyan, 2), 0, Height - 1, 0, 0);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.CornflowerBlue, 3)) // Border color and thickness
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
Color.FromArgb(70, 110, 180)  , // Soft Cornflower (recommended)    // Bottom
                              //                        Color.FromArgb(20, 20, 20),      // Dark background
                              //                Color.FromArgb(0, 90, 100),
                              ////                Color.FromArgb(20, 20, 20),
                              ////Color.FromArgb(35, 45, 50),  // End color
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        
        private void Forget_Password_Load(object sender, EventArgs e)
        {
            textBox1.Text = "User Name";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "New Password";
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = "Confirm Password";
            textBox3.ForeColor = Color.Gray;
            pictureBox1.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Padding = new Padding(2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Padding = new Padding(2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Padding = new Padding(2);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Loginpg log = new Loginpg();
            log.Show();
            this.Hide();

            }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" ||
       textBox2.Text.Trim() == "" ||
       textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields.");
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
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Check if email exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email=@Email";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@Email", textBox1.Text.Trim());

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Email not found.");
                        return;
                    }

                    // Update password
                    string updateQuery = "UPDATE Users SET Password=@Password WHERE Email=@Email";

                    SqlCommand cmd = new SqlCommand(updateQuery, con);

                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox1.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password reset successfully.");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "NewPassword";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "NewPassword")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "ConfirmPassword")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ConfirmPassword ";
                textBox1.ForeColor = Color.White;
            }
        }
    }
}
