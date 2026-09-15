using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loginpage
{
    public partial class Delete : Form
    {

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
        public Delete()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(30, 21, 48);
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Paint(object sender, PaintEventArgs e)
        {
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
                panelOuter.BackColor = Color.DarkSlateBlue;
                panelInner.BackColor = Color.FromArgb(30, 35, 45);
                //panelInner.BackColor = Color.FromArgb(35, 35, 35);

                //panelInner.Location = new Point(2, 2);
                //panelInner.Size = new Size(panelOuter.Width - 4, panelOuter.Height - 4);
                panelInner.Location = new Point(2, 25);   // 2 px from left, 5 px from top
                panelInner.Size = new Size(
                    panelOuter.Width - 4,
                    panelOuter.Height - 7  // 5 (top) + 2 (bottom)
                );

                panelOuter.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, panelOuter.Width, panelOuter.Height, 20, 20));

                panelInner.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, panelInner.Width, panelInner.Height, 18, 18));

            }
        }
    }
    }

