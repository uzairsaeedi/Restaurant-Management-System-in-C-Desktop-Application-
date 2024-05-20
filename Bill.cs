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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            label9.Text = Order.customerName.ToString();
            label3.Text = Order.itemName.ToString();
            label7.Text = Order.qty.ToString();
            label8.Text = Order.totalAmount.ToString();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.Show();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            this.Hide();
            staff.Show();
        }

        private void btn_tables_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            this.Hide();
            table.Show();
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
