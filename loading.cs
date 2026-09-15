using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Loginpage
{

    public partial class loading : Form
    {
     
        Panel panel1;
        Label label1;
        Timer timer1;

        int currentDot = 0;
        int totalDots = 12;
        int rotations = 0;
        public loading()
        {
           
            InitializeComponent();
            this.Text = "Password Vault";
            this.BackColor = Color.FromArgb(12, 15, 28);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(500, 300);
            this.DoubleBuffered = true;
            CreateUI();

        }
        private void CreateUI()
        {
            // Title
            label1 = new Label();
            label1.Text = "Please Wait";
            label1.ForeColor = Color.White;
            label1.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            label1.AutoSize = true;
            label1.Location = new Point(170, 50);

            this.Controls.Add(label1);

            // Spinner Panel
            panel1 = new Panel();
            panel1.Size = new Size(120, 120);
            //panel1.Location = new Point(
            //    (this.ClientSize.Width - panel1.Width) / 2,
            //    120);

            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(
    (this.ClientSize.Width - panel1.Width) / 2,
    (this.ClientSize.Height - panel1.Height) / 2 + 40
);
            panel1.Paint += panel_Paint;

            this.Controls.Add(panel1);

            // Timer
            timer1 = new Timer();
            timer1.Interval = 70;
            timer1.Tick += timer2_Tick;
            timer1.Start();
        }
        private void loading_Load(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
        
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int radius = 35;
            int dotSize = 8;

            Point center = new Point(
                panel1.Width / 2,
                panel1.Height / 2);

            for (int i = 0; i < totalDots; i++)
            {
                double angle = (i * 2 * Math.PI / totalDots) - (Math.PI / 2);
                int x = center.X + (int)(radius * Math.Cos(angle)) - dotSize / 2;
                int y = center.Y + (int)(radius * Math.Sin(angle)) - dotSize / 2;

                int alpha = 40;

                if (i == currentDot)
                    alpha = 255;
                else if (i == (currentDot + totalDots - 1) % totalDots)
                    alpha = 180;
                else if (i == (currentDot + totalDots - 2) % totalDots)
                    alpha = 120;
                else if (i == (currentDot + totalDots - 3) % totalDots)
                    alpha = 70;

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, Color.White)))
                {
                    g.FillEllipse(brush, x, y, dotSize, dotSize);
                }
            }
        
    }

        private void timer2_Tick(object sender, EventArgs e)
        {
            currentDot++;

            if (currentDot >= totalDots)
            {
                currentDot = 0;
                rotations++;
            }

            panel1.Invalidate();

            if (rotations >= 3)
            {
                timer1.Stop();

                Welcomepg login = new Welcomepg();
                login.Show();

                this.Hide();
            }
        }
    }
}
