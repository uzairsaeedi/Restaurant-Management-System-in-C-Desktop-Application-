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
    public partial class AdminTable : Form
    {
        public static string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RMS2.mdf;Integrated Security=True;Trust Server Certificate=True";

        SqlConnection con = new SqlConnection(connection);

        public AdminTable()
        {
            InitializeComponent();
        }

        private void btn_reservation_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime selectedDate = dateTimePicker1.Value;

                if (selectedDate.Date < currentDate.Date)
                {
                    MessageBox.Show("Cannot reserve a table for a previous date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string members = txt_members.Text;
                string customername = txt_customername.Text;

                string timeSlot = cb_timeslots.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(timeSlot))
                {
                    MessageBox.Show("Please select a valid time slot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime combinedDateTime = selectedDate.Date.Add(TimeSpan.Parse(timeSlot));

                if (combinedDateTime < currentDate)
                {
                    MessageBox.Show("Cannot reserve a table for a previous time on the selected date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (IsTableReserved(selectedDate, timeSlot))
                {
                    MessageBox.Show("The table is already reserved for the selected date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "INSERT INTO Restaurant.Reservation VALUES(@table_id, @customer_id, @date, @members, @timeSlot)";
                using (SqlConnection sqlcon = new SqlConnection(connection))
                {
                    sqlcon.Open();

                    SqlCommand cmd = new SqlCommand(query, sqlcon);

                    int table_id = Int32.Parse(txt_Tableid.Text);
                    int customer_id = GetCustomerId(customername);

                    cmd.Parameters.AddWithValue("@table_id", table_id);
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@date", selectedDate);
                    cmd.Parameters.AddWithValue("@timeSlot", timeSlot);
                    cmd.Parameters.AddWithValue("@members", members);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("You've Booked the table");

                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool IsTableReserved(DateTime selectedDate, string timeSlot)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Restaurant.Reservation WHERE [Table ID] = @table_id AND [Date] = @date AND [TimeSlot] = @timeSlot";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        int table_id = Int32.Parse(txt_Tableid.Text);

                        command.Parameters.AddWithValue("@table_id", table_id);
                        command.Parameters.AddWithValue("@date", selectedDate.Date);
                        command.Parameters.AddWithValue("@timeSlot", timeSlot);

                        con.Open();
                        int reservationCount = (int)command.ExecuteScalar();

                        return reservationCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in IsTableReserved: {ex.Message}");
                return true;
            }
        }

        private void btn_add_table_Click(object sender, EventArgs e)
        {
            string status = cb_table.Text;
            string QRY = "Insert into Restaurant.Tables([Table Status])Values('" + status + "')";

            SqlCommand obj = new SqlCommand(QRY, con);

            con.Open();
            obj.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Table Inserted");

            BindGrid();

        }
        private int GetCustomerId(string customerName)
        {
            string query = "SELECT TOP 1 [Customer ID] FROM Restaurant.Customer WHERE [Customer Name] = @CustomerName";

            using (SqlConnection con1 = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand(query, con1))
                {
                    command.Parameters.AddWithValue("@CustomerName", customerName);

                    con1.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                        return -1;
                    }
                }
            }
        }

        private int GetTableId(string status)
        {
            string query = "SELECT TOP 1 [Table ID] FROM Restaurant.Tables WHERE [Table Status] = '" + status + "'";

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
                        MessageBox.Show("No available tables found.");
                        return -1;
                    }
                }
            }
        }
        public void BindGrid()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Restaurant.Reservation join Restaurant.Customer on Reservation.[Customer ID] = Customer.[Customer ID]", con);


            DataSet ds = new DataSet();


            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        private void PopulateTimeSlots()
        {
            List<string> timeSlots = new List<string>();

            TimeSpan startTime = TimeSpan.Zero;
            TimeSpan endTime = new TimeSpan(23, 50, 0);
            TimeSpan interval = new TimeSpan(0, 50, 0);

            while (startTime <= endTime)
            {
                timeSlots.Add(startTime.ToString(@"hh\:mm"));
                startTime = startTime.Add(interval);
            }

            cb_timeslots.DataSource = timeSlots;
        }
        private void AdminTable_Load(object sender, EventArgs e)
        {
            BindGrid();
            PopulateTimeSlots();
            cb_table.Items.Add("Available");
            cb_table.Items.Add("Not Available");
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
            AdminTable tables = new AdminTable();
            this.Hide();
            tables.Visible = true;

        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Visible = true;
        }

        private void txt_customername_TextChanged(object sender, EventArgs e)
        {
            
            string customerName = txt_customername.Text;

        }
    }
}
