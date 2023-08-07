using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Configuration;
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
            GetCustomer();
        }
        SqlConnection Conn = new SqlConnection(@"Data Source=LAB1A\MSSQLSERVER1122;Initial Catalog=PetShopDb;Integrated Security=True");
        private void GetCustomer()
        {
            try
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand("Select CustId From CustomerTbl", Conn);
                SqlDataReader Rdr;
                Rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("CustId", typeof(int));
                dt.Load(Rdr);
                CusIDCb.ValueMember = "CustId";
                CusIDCb.DataSource = dt;

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
        private void GetCustName()
        {
            try
            {
                string Query = "Select * From CustomerTbl Where CustId ='" + CusIDCb.SelectedValue.ToString() + "'";
                Conn.Open();
                SqlCommand cmd = new SqlCommand(Query, Conn);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    CusNameTb.Text = dr["CustName"].ToString();
                }
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
        private void Reset()
        {

        }

        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();            
        }
        private void AddToBillBtn_Click(object sender, EventArgs e)
        {

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
        private void label4_Click(object sender, EventArgs e)
        {
            Billings BillsObj = new Billings();
            BillsObj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Customers CusObj = new Customers();
            CusObj.Show();
            this.Hide();
        }


    }
}
