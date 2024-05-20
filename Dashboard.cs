using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
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
            Table tables = new Table();
            this.Hide();
            tables.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            this.Hide();
            staff.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Table tables = new Table();
            this.Hide();
            tables.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            this.Hide();
            staff.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            this.Hide();
            table.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Visible = true;
        }
    }
}
