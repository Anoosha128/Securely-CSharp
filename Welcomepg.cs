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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Loginpage
{
    public partial class Welcomepg : Form
        

    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
int left,
int top,
int right,
int bottom,
int width,
int height);
        
        public Welcomepg()
        {
            InitializeComponent();
           
        }

        private void Welcomepg_Load(object sender, EventArgs e)
        {

            // Formlocation
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            //Form

            this.Region = Region.FromHrgn(
        CreateRoundRectRgn(
            0, 0,
            Width, Height,
            30, 30));
            //Picture
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.Location = new Point(270, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor =
            Color.Transparent;
            //titleposition
            lblTitle.Size = new Size(500, 55);
            lblTitle.Location = new Point(205, 110);

            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.BackColor =
           Color.Transparent;
            //subtitleposition
            Subtitle.Size = new Size(540, 60);
            Subtitle.Location = new Point(170, 165);

            Subtitle.TextAlign = ContentAlignment.MiddleCenter;

            //Subtitle.Font = new Font("Segoe UI", 12);
//            Subtitle.Text =
//"Store, organize and protect your passwords in one secure place.";

            Subtitle.Font =
            new Font("Segoe UI", 13, FontStyle.Regular);

            Subtitle.ForeColor =
            Color.FromArgb(180, 180, 180);

            Subtitle.BackColor =
            Color.Transparent;
            //welcome lbl
            Welcomelbl.Font =
            new Font("Segoe UI", 14, FontStyle.Bold);
            Welcomelbl.Location = new Point(110, 215);

            Welcomelbl.ForeColor =
            Color.FromArgb(180, 180, 180);

            Welcomelbl.BackColor =
            Color.Transparent;
            //panel position
            panel1.Size = new Size(720, 550);
            panel1.Location = new Point(110, 40);
            //panel1.Size = new Size(150, 4);

            //panel1.Location = new Point(285, 125);

            panel1.BackColor = Color.FromArgb(110, 90, 255);
            //featureposition
            lblFeature1.Size = new Size(260, 25);
            lblFeature1.Location = new Point(100, 245);
            lblFeature2.Size = new Size(260, 25);
            lblFeature2.Location = new Point(100, 275);
            lblFeature3.Size = new Size(260, 25);
            lblFeature3.Location = new Point(100, 305);
            //btnpositon
            //btnStart.Size = new Size(180, 50);

            //btnStart.Location = new Point(270, 445);
            btnStart.Size = new Size(180, 48);

            btnStart.Location = new Point(240, 350);

            btnStart.Font =
            new Font("Segoe UI Semibold", 12);
            //footerposition
            Footer.Size = new Size(520, 20);

            Footer.Location = new Point(280, 400);


            Footer.TextAlign = ContentAlignment.MiddleCenter;

            //panel1
            panel1.Region = Region.FromHrgn(
CreateRoundRectRgn(
0,
0,
panel1.Width,
panel1.Height,
30,
30));
            this.BackColor = Color.FromArgb(12, 15, 28);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitle.Text = "Password Vault";
            lblTitle.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;

            Subtitle.Text = "Securely store and manage your \npasswords with military-grade encryption.";
            Subtitle.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            Subtitle.ForeColor = Color.FromArgb(170, 170, 170);
            Welcomelbl.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            btnStart.Text = "Get Started";
            btnStart.Font = new Font("Segoe UI Semibold", 12F);

            //btnStart.BackColor = Color.FromArgb(104, 76, 255);
            //btnStart.ForeColor = Color.White;
            //btnStart.FlatStyle = FlatStyle.Flat;
            //btnStart.FlatAppearance.BorderSize = 0;

            btnStart.BackColor =
            Color.FromArgb(105, 80, 255);

            btnStart.ForeColor = Color.White;

            btnStart.Font =
            new Font("Segoe UI Semibold", 12);

            btnStart.Region = Region.FromHrgn(
            CreateRoundRectRgn(
            0,
            0,
            btnStart.Width,
            btnStart.Height,
            25,
            25));

            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            //features
            lblFeature1.Text = "✓ AES-256 Encryption";
            lblFeature2.Text = "✓ Password Generator";
            lblFeature3.Text = "✓ Fast & Secure Access";

            foreach (Label lbl in new Label[]
            {
        lblFeature1,
        lblFeature2,
        lblFeature3
            })
            {
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.Transparent;
            }

            }

       

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordGenerator main = new PasswordGenerator();
            main.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = panel1.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(10, 12, 28),
                Color.FromArgb(40, 45, 90),
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }
            //using (SolidBrush glow = new SolidBrush(Color.FromArgb(40, 110, 90, 255)))
            //{
            //    e.Graphics.FillEllipse(glow, 260, 0, 180, 180);
            //}
        }

        private void Footer_Paint(object sender, PaintEventArgs e)
        {
            Footer.Text = "Version 1.0 • © 2026";

            Footer.Font =
            new Font("Segoe UI", 9);

            Footer.ForeColor =
            Color.FromArgb(140, 140, 140);

            Footer.BackColor =
            Color.Transparent;
        }

        private void Welcomelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
