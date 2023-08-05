using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class Billings : Form
    {
        public Billings()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products ProObj = new Products();
            ProObj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees EmpObj = new Employees();
            EmpObj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Customers CusObj = new Customers();
            CusObj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Billings BillsObj = new Billings();
            BillsObj.Show();
            this.Hide();
        }

        SqlConnection Conn = new SqlConnection(@"Data Source=LAB1A\MSSQLSERVER1122;Initial Catalog=PetShopDb;Integrated Security=True");
        private void DisplayProducts()
        {
            try
            {
                Conn.Open();
                string SelectSqlQuery = "select * from ProductTbl";
                SqlDataAdapter Sda = new SqlDataAdapter(SelectSqlQuery, Conn);
                SqlCommandBuilder CmdBuilder = new SqlCommandBuilder(Sda);
                var Ds = new DataSet();
                Sda.Fill(Ds);
                ProductsDGV.DataSource = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
