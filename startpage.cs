using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loginpage
{
    public partial class startpage : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
int left,
int top,
int right,
int bottom,
int width,
int height);
        public startpage()
        {
            InitializeComponent();
        }

        private void startpage_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(
       CreateRoundRectRgn(
           0, 0,
           Width, Height,
           30, 30));
            this.BackColor = Color.FromArgb(11, 16, 32);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = "Password Vault";
            label1.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
           
            weltitle.BackColor = Color.Transparent;
            subtitle.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
           
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            login.Font = new Font("Segoe UI Semibold", 12F);
            login.BackColor =
          Color.FromArgb(42, 48, 82);

            login.ForeColor = Color.White;

            login.Font =
              new Font("Segoe UI Semibold", 12);

            login.Region = Region.FromHrgn(
            CreateRoundRectRgn(
            0,
            0,
            login.Width,
            login.Height,
            25,
            25));

            login.FlatStyle = FlatStyle.Flat;
            login.FlatAppearance.BorderSize = 0;
            login.Font = new Font("Segoe UI Semibold", 12F);
            button1.Font = new Font("Segoe UI Semibold", 12F);
            button1.BackColor =
          Color.FromArgb(108, 92, 255);

            button1.ForeColor = Color.White;

          button1.Font =
            new Font("Segoe UI Semibold", 12);

            button1.Region = Region.FromHrgn(
            CreateRoundRectRgn(
            0,
            0,
            button1.Width,
            button1.Height,
            25,
            25));

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            panelInner.BackColor = Color.FromArgb(30, 35, 65);
            panelg.BackColor = Color.FromArgb(30, 35, 65);
        }

        private void panelInner_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = panelInner.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(10, 12, 28),
                Color.FromArgb(40, 45, 90),
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }
            using (SolidBrush glow = new SolidBrush(Color.FromArgb(35, 120, 90, 255)))
            {
                g.FillEllipse(glow, -120, -120, 400, 400);
            }

            using (SolidBrush glow2 = new SolidBrush(Color.FromArgb(25, 0, 200, 255)))
            {
                g.FillEllipse(glow2, 900, 450, 500, 500);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup_page si = new Signup_page();
            si.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            Loginpg log = new Loginpg();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PasswordGenerator pg = new PasswordGenerator();
            pg.Show();
            this.Hide();
        }

        private void startpage_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect = this.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(10, 12, 30),   // Top
                Color.FromArgb(28, 35, 70),   // Bottom
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }
        }
    }
}
