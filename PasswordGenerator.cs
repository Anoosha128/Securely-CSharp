
//using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Loginpage
{
    public partial class PasswordGenerator : Form

    {
        public class Database
        {
            public static string ConnectionString =
                @"Data Source=.\SQLExpress;
          Initial Catalog=LoginDB;
          Integrated Security=True";
        }
        public string Username;
        private Panel[] bars;
        private int passwordLength = 8;
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
        public PasswordGenerator()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            bars = new Panel[]
{
    panelBar1,
    panelBar2,
    panelBar3,
    panelBar4,
    panelBar5,
    panelBar6
};
        }
        private void UpdateStrengthBar(int strength)
        {
            // Reset all bars (dark background)
            foreach (Panel bar in bars)
            {
                bar.BackColor = Color.FromArgb(56, 61, 92);   // #383D5C
            }

            // Gradient colors (same style as the screenshot)
            Color[] gradientColors =
            {
        Color.FromArgb(133, 63, 255),  // #853FFF
        Color.FromArgb(116, 77, 255),  // #744DFF
        Color.FromArgb(82, 121, 255),  // #5279FF
        Color.FromArgb(46, 177, 255),  // #2EB1FF
        Color.FromArgb(19, 215, 233),  // #13D7E9
        Color.FromArgb(0, 235, 170)    // #00EBAA
    };

            // Fill bars with gradient colors
            for (int i = 0; i < strength && i < bars.Length; i++)
            {
                bars[i].BackColor = gradientColors[i];
            }

            // Strength Label
            if (strength <= 2)
            {
                lblStrength.Text = "Weak";
                lblStrength.ForeColor = Color.FromArgb(255, 90, 90);    // Red
                lblStrength.BackColor = Color.FromArgb(45, 22, 30);
            }
            else if (strength <= 4)
            {
                lblStrength.Text = "Medium";
                lblStrength.ForeColor = Color.FromArgb(255, 196, 0);    // Yellow
                lblStrength.BackColor = Color.FromArgb(45, 40, 20);
            }
            else
            {
                lblStrength.Text = "Strong";
                lblStrength.ForeColor = Color.FromArgb(0, 235, 170);    // #00EBAA
                lblStrength.BackColor = Color.FromArgb(18, 40, 32);     // Dark Green
            }
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
         
            int score = 0;
            string chars = "";

            if (checkBox1.Checked)
                chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (checkBox2.Checked)
                chars += "abcdefghijklmnopqrstuvwxyz";

            if (checkBox3.Checked)
                chars += "0123456789";

            if (checkBox4.Checked)
                chars += "!@#$%^&*()_-+=<>?/[]{}";

            if (chars == "")
            {
                MessageBox.Show("Select at least one option.");
                return;
            }
          

            Random random = new Random();

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < passwordLength; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }
           
            txtPassword.Text = password.ToString();
            UpdateStrengthBar(score);

            CheckStrength();
        }
        private void CheckStrength()
        {
            string password = txtPassword.Text;

            int score = 0;

            // Password Length
            if (password.Length >= 8)
                score++;

            if (password.Length >= 12)
                score++;

            // Character types actually present in the password
            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSymbol = password.Any(ch => !char.IsLetterOrDigit(ch));

            if (hasUpper)
                score++;

            if (hasLower)
                score++;

            if (hasDigit)
                score++;

            if (hasSymbol)
                score++;

            // If the user disables an option, reduce the score
            if (!checkBox1.Checked && hasUpper)
                score--;

            if (!checkBox2.Checked && hasLower)
                score--;

            if (!checkBox3.Checked && hasDigit)
                score--;

            if (!checkBox4.Checked && hasSymbol)
                score--;

            // Keep score between 0 and 6
            score = Math.Max(0, Math.Min(score, 6));
            if (txtPassword.Text.Any(ch => !char.IsLetterOrDigit(ch)))
                score++;
            UpdateStrengthBar(score);
            //int score = 0;

            //if (txtPassword.Text.Length >= 8)
            //    score += 20;

            //if (txtPassword.Text.Length >= 12)
            //    score += 20;

            //if (checkBox1.Checked)
            //    score++;

            //if (checkBox2.Checked)
            //    score++;

            //if (checkBox3.Checked)
            //    score++;

            //if (checkBox4.Checked)
            //    score++;

            ////progressBar1.Value = score;

            //if (score <= 40)
            //{
            //    lblStrength.Text = "Weak";
            //}
            //else if (score <= 80)
            //{
            //    lblStrength.Text = "Medium";
            //}
            //else
            //{
            //    lblStrength.Text = "Strong";
            //}
           

            //// Update the bars and label
            //UpdateStrengthBar(score);
        }


        private void PasswordGenerator_Load(object sender, EventArgs e)
        {
            
            //form
            this.Size = new Size(1550, 1020);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.FromArgb(10, 12, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new Font("Segoe UI", 10F);

            this.Region = Region.FromHrgn(
                CreateRoundRectRgn(
                    0,
                    0,
                    this.Width,
                    this.Height,
                    30,
                    30));
            // MAIN PANEL
       

            Mainpanel.BackColor = Color.FromArgb(15, 18, 35);

            Mainpanel.Region = Region.FromHrgn(
                CreateRoundRectRgn(
                    0,
                    0,
                     Mainpanel.Width,
                     Mainpanel.Height,
                    25,
                    25));
            // btn design in pannellenght
           
            panelLength.BackColor = Color.FromArgb(22, 24, 42);

            panelLength.Region = Region.FromHrgn(
            CreateRoundRectRgn(0, 0, panelLength.Width, panelLength.Height, 18, 18));

            lblLength.Text = passwordLength.ToString();

            lblLength.ForeColor = Color.White;
            lblLength.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblLength.TextAlign = ContentAlignment.MiddleCenter;

            Button[] btns =
            {
    Downbtn,
    addbtn
};

            foreach (Button b in btns)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = Color.FromArgb(45, 35, 80);
                b.ForeColor = Color.White;
                b.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            }



           
            panelUsername.BackColor = Color.FromArgb(22, 24, 42);
            panelPassword.BackColor = Color.FromArgb(22, 24, 42);

            
            panelUsername.Region =
                Region.FromHrgn(CreateRoundRectRgn(
                0, 0, panelUsername.Width, panelUsername.Height, 20, 20));

            panelPassword.Region =
                Region.FromHrgn(CreateRoundRectRgn(
                0, 0, panelPassword.Width, panelPassword.Height, 20, 20));

            // TITLE
            

            label1.Text = "Password Generator";

            label1.Font =
                new Font("Segoe UI Semibold", 28, FontStyle.Bold);

            label1.ForeColor = Color.White;

           
            // SUBTITLE
         

            label2.Font =
                new Font("Segoe UI", 12);

            label2.ForeColor =
                Color.FromArgb(180, 180, 180);

            txtUsername.BackColor =
      Color.FromArgb(22, 24, 42);

            txtPassword.BackColor =
                Color.FromArgb(22, 24, 42);

            txtUsername.ForeColor = Color.White;
            txtPassword.ForeColor = Color.White;

            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;

            txtUsername.Font =
       new Font("Segoe UI", 13);
            panel2.BackColor =
Color.FromArgb(18, 20, 35);
            txtPassword.Font =
                new Font("Consolas", 18, FontStyle.Bold);
            //generate password panel
            panelPassword.BackColor = Color.FromArgb(22, 24, 42);

            panelPassword.Region = Region.FromHrgn(
            CreateRoundRectRgn(0, 0, panelPassword.Width, panelPassword.Height, 20, 20));
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.BackColor = panelPassword.BackColor;
            txtPassword.ForeColor = Color.White;
            txtPassword.Font = new Font("Consolas", 18, FontStyle.Bold);

            // COMBOBOX
            // ===========================

            checkBox1.BackColor =
                Color.FromArgb(22, 24, 42);

            checkBox1.ForeColor =
                Color.White;

            comboBox1.FlatStyle =
                FlatStyle.Flat;

            comboBox1.Font =
                new Font("Segoe UI", 12);

            // NUMERIC UP DOWN


           
            // CHECK BOXES
           

            foreach (CheckBox chk in new CheckBox[]
            {
        checkBox1,
        checkBox2,
        checkBox3,
        checkBox4
            })
            {
                chk.ForeColor = Color.White;

                chk.Font =
                    new Font("Segoe UI", 11);

                chk.BackColor =
                    Color.Transparent;
            }
            // BUTTONS
          

            Button[] buttons =
            {
        btnGenerate,
        btnCopy,
        btnSave
    };

            foreach (Button btn in buttons)
            {
                btn.FlatStyle = FlatStyle.Flat;

                btn.FlatAppearance.BorderSize = 0;

                btn.Font =
                    new Font("Segoe UI Semibold", 12);

                btn.ForeColor = Color.White;

                btn.Region = Region.FromHrgn(
                    CreateRoundRectRgn(
                        0,
                        0,
                        btn.Width,
                        btn.Height,
                        20,
                        20));
            }

            btnGenerate.BackColor =
                Color.FromArgb(104, 76, 255);

            btnCopy.BackColor =
                Color.FromArgb(40, 45, 70);

            btnSave.BackColor =
                Color.FromArgb(40, 45, 70);

          

           

            //--------------------------------------logic--------------------------------------------


            comboBox1.Items.Add("Google");
            comboBox1.Items.Add("Facebook");
            comboBox1.Items.Add("Instagram");
            comboBox1.Items.Add("GitHub");
            comboBox1.Items.Add("Netflix");
            comboBox1.Items.Add("Amazon");
            comboBox1.Items.Add("LinkedIn");
            comboBox1.Items.Add("Other");

            comboBox1.SelectedIndex = 0;
            panelCombo.BackColor =
Color.FromArgb(18, 20, 35);

           
            comboBox1.BackColor =
            Color.FromArgb(18, 20, 35);

            comboBox1.ForeColor = Color.White;
            
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;

            progresspanel.BackColor =
           Color.FromArgb(18, 20, 35);


           
            //numericUpDown1.Value = 16;

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                Clipboard.SetText(txtPassword.Text);
                MessageBox.Show("Password Copied");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Fill all information.");
                    return;
                }
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Fill all information.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(Database.ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                    "INSERT INTO SavedPasswords(Website,Username,Password,DateCreated) VALUES(@Website,@Username,@Password,@Date)",
                    con);

                    cmd.Parameters.AddWithValue("@Website", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password Saved Successfully.");
                    saved_form f1 = new saved_form();
                    f1.Show();
                    this.Hide();
                }

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
       

        private void PasswordGenerator_Paint(object sender, PaintEventArgs e)
        {
         
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;

            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    rect,
                    Color.FromArgb(8, 10, 20),
                    Color.FromArgb(20, 24, 48),
                    LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }

            using (SolidBrush glow =
                new SolidBrush(Color.FromArgb(45, 120, 90, 255)))
            {
                g.FillEllipse(glow, 420, -80, 260, 260);
                g.FillEllipse(glow, 950, 520, 300, 300);
            }
            tippanel.BackColor = Color.FromArgb(18, 20, 35);
            outertippanel.BackColor = Color.WhiteSmoke;
            outertippanel.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, tippanel.Width, tippanel.Height, 10, 7));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblLength_Click(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (passwordLength <= 29)
            {
                passwordLength++;
                lblLength.Text = passwordLength.ToString();
            }
        }

        private void Downbtn_Click(object sender, EventArgs e)
        {
            if (passwordLength >= 5)
            {
                passwordLength--;
                lblLength.Text = passwordLength.ToString();
            }
        }

        private void passwordpanel_Paint(object sender, PaintEventArgs e)
        {
            passwordpanel.BackColor =
Color.FromArgb(18, 20, 35);
        }
        private bool formLoaded = false;
        private void Mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (formLoaded)
                btnGenerate.PerformClick();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (formLoaded)
                btnGenerate.PerformClick();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (formLoaded)
                btnGenerate.PerformClick();
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (formLoaded)
                btnGenerate.PerformClick();
        }
    }
}
