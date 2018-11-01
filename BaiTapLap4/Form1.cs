using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLap5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from KHOA", @"Data Source=.;Initial Catalog=QLSINHVIEN4;Integrated Security=True");
                DataSet ds = new DataSet();
                da.Fill(ds, "KHOA");
                ds.WriteXml("../../khoa.xml");
                MessageBox.Show("Ghi thanh cong");
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("../../khoa.xml");
                dataGridView1.DataSource = ds.Tables[0];
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from KHOA", @"Data Source=.;Initial Catalog=QLSINHVIEN4;Integrated Security=True");
                DataSet ds = new DataSet();
                da.Fill(ds, "KHOA");

                DataRow r = ds.Tables["KHOA"].Rows[0];

                r["NamThanhLap"] = "2000";

                ds.WriteXml("../../khoadiff.xml", XmlWriteMode.DiffGram);
                MessageBox.Show("Ghi thanh cong");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
