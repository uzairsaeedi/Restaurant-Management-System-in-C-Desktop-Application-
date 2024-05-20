using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class Staff : Form
    {
        string username = Form1.username;
        string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RMS2.mdf;Integrated Security=True;Trust Server Certificate=True";
        public Staff()
        {
            InitializeComponent();
            BindGrid();
        }
        private int GetEmployeeId(string username)
        {
            string query = "SELECT TOP 1 [Employee ID] FROM Restaurant.Employee WHERE Name = '" + username + "' ORDER BY [Employee ID]";

            using (SqlConnection con2 = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand(query, con2))
                {
                    con2.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("No available Category found.");
                        return -1;
                    }
                }
            }
        }
        public void BindGrid()
        {
            int loggedInEmployeeId = GetEmployeeId(username);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Restaurant.Employee WHERE [Employee ID] = {loggedInEmployeeId}", connection);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }


        private void btn_order_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.Visible = true;
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Visible = true;
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            this.Hide();
            staff.Visible = true;
        }

        private void btn_tables_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            this.Hide();
            table.Visible = true;
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Visible = true;
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.username;
        }
    }
}
