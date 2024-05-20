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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            AddFood food = new AddFood();
            this.Hide();
            food.Visible = true;
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            AdminMenu menu = new AdminMenu();
            this.Hide();
            menu.Visible = true;
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            AdminStaff staff = new AdminStaff();
            this.Hide();
            staff.Visible = true;
        }

        private void btn_tables_Click(object sender, EventArgs e)
        {
            AdminTable table = new AdminTable();
            this.Hide();
            table.Visible = true;
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Visible = true;
        }
    }
}
