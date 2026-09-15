using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Loginpage
{
    
    public partial class saved_form : Form
    {
        public static string ConnectionString =
       @"Data Source=.\SQLEXPRESS;
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
        public saved_form()
        {
            InitializeComponent();
        }
        private void LoadPasswords()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM SavedPasswords", con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
        private void saved_form_Load(object sender, EventArgs e)
        {
            //design
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

            dataGridView1.BackgroundColor = Color.FromArgb(15, 18, 35);

            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(104, 76, 255);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
            new Font("Segoe UI", 11, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.BackColor =
            Color.FromArgb(22, 24, 42);

            dataGridView1.DefaultCellStyle.ForeColor =
            Color.White;

            dataGridView1.DefaultCellStyle.SelectionBackColor =
            Color.FromArgb(0, 235, 170);

            dataGridView1.DefaultCellStyle.SelectionForeColor =
            Color.Black;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            Mainpanel.BackColor = Color.FromArgb(15, 18, 35);

            Mainpanel.Region = Region.FromHrgn(
                CreateRoundRectRgn(
                    0,
                    0,
                     Mainpanel.Width,
                     Mainpanel.Height,
                    25,
                    25));
            //dataGridView1.View = View.Details;
            dataGridView1.BackColor =
                Color.FromArgb(18, 22, 40);

            dataGridView1.ForeColor =
                Color.White;

            dataGridView1.BorderStyle =
                BorderStyle.None;
            LoadPasswords();
            //dataGridView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            //dataGridView1.FullRowSelect = true;
            //dataGridView1.MultiSelect = false;
            //dataGridView1.GridLines = false;



            //dataGridView1.View = View.Details;
        }

        //private void dataGridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //        return;

        //    string account = dataGridView1.SelectedRows[0].Text;
        //    string username = dataGridView1.SelectedRows[0].SubRow[1].Text;

        //    XLWorkbook workbook = new XLWorkbook(file);
        //    IXLWorksheet sheet = workbook.Worksheet(1);

        //    foreach (IXLRow row in sheet.RowsUsed().Skip(1))
        //    {
        //        if (row.Cell(1).GetString() == account &&
        //            row.Cell(2).GetString() == username)
        //        {
        //            txtPassword.Text = row.Cell(3).GetString();
        //            break;
        //        }
        //    }
   // } 
    }
}
