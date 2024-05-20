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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RMS
{
    public partial class AdminStaff : Form
    {
        private string role;
       private string gender;
       
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RMS2.mdf;Integrated Security=True;Trust Server Certificate=True");

        public string Role { get => role; set => role = value; }

        public string setrole()
        {
            if (rb_chef.Checked == true)
                Role = "Chef";
            else if (rb_waiter.Checked == true)
                Role = "Waiter";
            else if (rb_manager.Checked == true)
                Role = "Manager";
            else
                Role = " ";
            return Role;
        }

        public string Gender { get => gender; set => gender = value; }

        public string setgender()
        {
            if (rb_male.Checked == true)
                Gender = "Male";
            else if (rb_female.Checked == true)
                Gender = "Female";
            else
                Gender = " ";
            return Gender;
        }
        private void cb_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_City.Items.Clear();
            cb_City.Text = string.Empty;

            cb_province.Items.Clear();
            cb_province.Text = string.Empty;

            if (cb_country.Text == "Pakistan")
            {

                cb_province.Items.Add("Sindh");
                cb_province.Items.Add("Balochistan");
                cb_province.Items.Add("KhyberPakhtunkhwa");
                cb_province.Items.Add("Punjab");



            }
            else if (cb_country.Text == "India")
            {
                cb_province.Items.Add("Delhi");
                cb_province.Items.Add("Maharashtra");
                cb_province.Items.Add("Karnataka");
                cb_province.Items.Add("Telangana");
                cb_province.Items.Add("Gujarat");
                cb_province.Items.Add("Tamil Nadu");
                cb_province.Items.Add("West Bengal");
                cb_province.Items.Add("Utar Pardesh");
                cb_province.Items.Add("Madhya Pardesh");
                cb_province.Items.Add("Andhra Pardesh");
                cb_province.Items.Add("Bihar");
                cb_province.Items.Add("Punjab");
                cb_province.Items.Add("Haryana");
                cb_province.Items.Add("Jharkhand");

            }
        }

        
        private void cb_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_City.Items.Clear();
            cb_City.Text = string.Empty;

            if (cb_province.Text == "Sindh")
            {

                cb_City.Items.Add("Karachi");
                cb_City.Items.Add("Dadu");
                cb_City.Items.Add("Hyderabad");
                cb_City.Items.Add("Moroo");
                cb_City.Items.Add("Mirpur khas");
                cb_City.Items.Add("Tando Adam");
                cb_City.Items.Add("Khairpur");
                cb_City.Items.Add("Sukkur");
                cb_City.Items.Add("Shikarpur");
                cb_City.Items.Add("Jackabad");
                cb_City.Items.Add("Kandhkot");

            }
            else if (cb_province.Text == "Balochistan")
            {

                cb_City.Items.Add("Khuzdar");
                cb_City.Items.Add("Dera Murad Jamali");
                cb_City.Items.Add("Zhob");
                cb_City.Items.Add("Turbat");
                cb_City.Items.Add("Gwadar");
                cb_City.Items.Add("Sibi");
                cb_City.Items.Add("Bela");
                cb_City.Items.Add("Chaman");
                cb_City.Items.Add("Quetta");

            }
            else if (cb_province.Text == "Punjab")
            {

                cb_City.Items.Add("Bahawalpur");
                cb_City.Items.Add("Rawalpindi");
                cb_City.Items.Add("Islamabad");
                cb_City.Items.Add("Gujranwala");
                cb_City.Items.Add("Gujrat");
                cb_City.Items.Add("Chiniot");
                cb_City.Items.Add("Lahore");
                cb_City.Items.Add("Faisalabad");
                cb_City.Items.Add("Multan");
                cb_City.Items.Add("Sahiwal");
                cb_City.Items.Add("Sargodha");
                cb_City.Items.Add("Sialkot");
                cb_City.Items.Add("Sheikhupura");
                cb_City.Items.Add("Rahimyar Khan");
                cb_City.Items.Add("Okara");
                cb_City.Items.Add("Dera Ghazi Khan");
                cb_City.Items.Add("Kasur");

            }
            else if (cb_province.Text == "KhyberPakhtunkhwa")
            {
                cb_City.Items.Add("Swat");
                cb_City.Items.Add("Mingora");
                cb_City.Items.Add("Peshawar");
                cb_City.Items.Add("Kohat");
                cb_City.Items.Add("Abbotabad");
                cb_City.Items.Add("Dera Ismail Khan");
                cb_City.Items.Add("Charsada");
                cb_City.Items.Add("Swabi");
                cb_City.Items.Add("Mansehra");
                cb_City.Items.Add("Nowshera");
                cb_City.Items.Add("Mardan");
                cb_City.Items.Add("Hunza");
                cb_City.Items.Add("Skardu");

            }
            if (cb_province.Text == "Delhi")
            {

                cb_City.Items.Add("New Delhi");
                cb_City.Items.Add("Dadu");
                cb_City.Items.Add("Hyderabad");
                cb_City.Items.Add("Moroo");
                cb_City.Items.Add("Mirpur khas");
                cb_City.Items.Add("Tando Adam");
                cb_City.Items.Add("Khairpur");
                cb_City.Items.Add("Sukkur");
                cb_City.Items.Add("Shikarpur");
                cb_City.Items.Add("Jackabad");
                cb_City.Items.Add("Kandhkot");

            }
            else if (cb_province.Text == "Maharashtra")
            {

                cb_City.Items.Add("Mumbai");
                cb_City.Items.Add("Pune");
                cb_City.Items.Add("Nagpur");
                cb_City.Items.Add("Thane");
                cb_City.Items.Add("Pimpri Chinwad");
                cb_City.Items.Add("Vasaivirar");
                cb_City.Items.Add("Aurangabad");
                cb_City.Items.Add("Navi Mumbai");
                cb_City.Items.Add("Solapur");
                cb_City.Items.Add("Mira-Bhayandar");
                cb_City.Items.Add("Bhiwandi");
                cb_City.Items.Add("Amravati");
                cb_City.Items.Add("Nanded");
                cb_City.Items.Add("Kolhapur");
                cb_City.Items.Add("Akola");
                cb_City.Items.Add("Ulhasnagar");
                cb_City.Items.Add("Sangli-Miraj & Kupwad");
                cb_City.Items.Add("Malegaon");
                cb_City.Items.Add("Jalgaon");

            }
            else if (cb_province.Text == "Karnataka")
            {

                cb_City.Items.Add("Bangalore");
                cb_City.Items.Add("Hubballi Dharwad");
                cb_City.Items.Add("Mysore");
                cb_City.Items.Add("Tiruchirappalli");
                cb_City.Items.Add("Tiruppur");
                cb_City.Items.Add("Gulbarga");
                cb_City.Items.Add("Davanagere");
                cb_City.Items.Add("Belgaum");
                cb_City.Items.Add("Mangalore");

            }
            else if (cb_province.Text == "Telangana")
            {
                cb_City.Items.Add("Hyderabad");
                cb_City.Items.Add("Warangal");

            }
            else if (cb_province.Text == "Gujarat")
            {
                cb_City.Items.Add("Gujarat");
                cb_City.Items.Add("Vadodara");
                cb_City.Items.Add("Surat");
                cb_City.Items.Add("Bhavnagar");
                cb_City.Items.Add("Jamnagar");
            }
            else if (cb_province.Text == "Tamil Nadu")
            {
                cb_City.Items.Add("Chennai");
                cb_City.Items.Add("Coimbatore");
                cb_City.Items.Add("Madurai");
                cb_City.Items.Add("Salem");
                cb_City.Items.Add("Erode");
                cb_City.Items.Add("Ambattur");
                cb_City.Items.Add("Tirunelveli");
            }
            else if (cb_province.Text == "West Bengal")
            {
                cb_City.Items.Add("Kolkata");
                cb_City.Items.Add("Howrah");
                cb_City.Items.Add("Asansol");
                cb_City.Items.Add("Durgapur");
                cb_City.Items.Add("Siliguri");
                cb_City.Items.Add("Maheshtala");
            }
            else if (cb_province.Text == "Utar Pardesh")
            {
                cb_City.Items.Add("Lucknow");
                cb_City.Items.Add("Kanpur");
                cb_City.Items.Add("Ghaziabad");
                cb_City.Items.Add("Agra");
                cb_City.Items.Add("Varanasi");
                cb_City.Items.Add("Allahabad");
                cb_City.Items.Add("Moradabad");
                cb_City.Items.Add("Bareily");
                cb_City.Items.Add("Aligarh");
                cb_City.Items.Add("Saharanpur");
                cb_City.Items.Add("Noida");
                cb_City.Items.Add("Gorakhpur");
                cb_City.Items.Add("Loni");
                cb_City.Items.Add("Firozabad");
                cb_City.Items.Add("Jhansi");
            }
            else if (cb_province.Text == "Madhya Pardesh")
            {
                cb_City.Items.Add("Indore");
                cb_City.Items.Add("Bhopal");
                cb_City.Items.Add("Jabalpur");
                cb_City.Items.Add("Gwalior");
                cb_City.Items.Add("Ujjain");
            }
            else if (cb_province.Text == "Andhra Pardesh")
            {
                cb_City.Items.Add("Visakhapatnam");
                cb_City.Items.Add("Vijayawada");
                cb_City.Items.Add("Guntur");
                cb_City.Items.Add("Nellore");
                cb_City.Items.Add("Kurnool");
                cb_City.Items.Add("Rajahmundry");
            }
            else if (cb_province.Text == "Bihar")
            {
                cb_City.Items.Add("Patna");
                cb_City.Items.Add("Gaya");
            }
            else if (cb_province.Text == "Punjab")
            {
                cb_City.Items.Add("Jalandhar");
            }
            else if (cb_province.Text == "Haryana")
            {
                cb_City.Items.Add("Faridabad");
                cb_City.Items.Add("Gurgaon");
            }
            else if (cb_province.Text == "Jharkhand")
            {
                cb_City.Items.Add("Ranchi");
                cb_City.Items.Add("Jamshedpur");
            }
        }
        public AdminStaff()
        {
            InitializeComponent();
            cb_country.SelectedIndexChanged += cb_country_SelectedIndexChanged;
            cb_province.SelectedIndexChanged += cb_province_SelectedIndexChanged;
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
            form.Show();
            this.Close();
        }

        private void btn_addstaff_Click(object sender, EventArgs e)
        {
            string name = txt_employeename.Text;
            string phone = txt_phone.Text;
            string address = txt_address.Text;
            string city = cb_City.Text;
            string salaryText = txt_salary.Text;
            DateTime dateTime = dt_date.Value;
            string country = cb_country.Text;
            string state = cb_province.Text;
            string gender = setgender();
            string role = setrole();

            try
            {
                if (!decimal.TryParse(salaryText, out decimal salary) || salary < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative salary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dateTime > DateTime.Now)
                {
                    MessageBox.Show("Hire date cannot be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                con.Open();

                string employeeQuery = "INSERT INTO Restaurant.Employee(Phone, Name, Role, Salary, [Hire Date], Gender) VALUES(@Phone, @Name, @Role, @Salary, @HireDate, @Gender); SELECT SCOPE_IDENTITY();";

                using (SqlCommand employeeCommand = new SqlCommand(employeeQuery, con))
                {
                    employeeCommand.Parameters.AddWithValue("@Phone", phone);
                    employeeCommand.Parameters.AddWithValue("@Name", name);
                    employeeCommand.Parameters.AddWithValue("@Role", role);
                    employeeCommand.Parameters.AddWithValue("@Salary", salary);
                    employeeCommand.Parameters.AddWithValue("@HireDate", dateTime);
                    employeeCommand.Parameters.AddWithValue("@Gender", gender);

                    int employeeId = Convert.ToInt32(employeeCommand.ExecuteScalar());

                    string addressQuery = "INSERT INTO Restaurant.Address([Employee ID], [Address Line 1], City, Country, State) VALUES(@EmployeeID, @AddressLine1, @City, @Country, @State);";

                    using (SqlCommand addressCommand = new SqlCommand(addressQuery, con))
                    {
                        addressCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                        addressCommand.Parameters.AddWithValue("@AddressLine1", address);
                        addressCommand.Parameters.AddWithValue("@City", city);
                        addressCommand.Parameters.AddWithValue("@Country", country);
                        addressCommand.Parameters.AddWithValue("@State", state);

                        addressCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Staff Added");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }



        public void BindGrid()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Restaurant.Employee ", con);


            DataSet ds = new DataSet();


            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void AdminStaff_Load(object sender, EventArgs e)
        {
            cb_country.Items.Add("Pakistan");
            cb_country.Items.Add("India");

            BindGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_employeeid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_employeename.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_phone.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_address.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_salary.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cb_City.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cb_country.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            cb_province.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = setgender();
                string role = setrole();
                DateTime dateTime = dt_date.Value;

                string updateQuery = "UPDATE Restaurant.Employee SET ";

                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(txt_employeename.Text))
                {
                    updateQuery += "Name = @Name, ";
                    parameters.Add(new SqlParameter("@Name", txt_employeename.Text));
                }

                if (!string.IsNullOrEmpty(txt_phone.Text))
                {
                    updateQuery += "Phone = @Phone, ";
                    parameters.Add(new SqlParameter("@Phone", txt_phone.Text));
                }
                if (!string.IsNullOrEmpty(cb_City.Text))
                {
                    updateQuery += "City = @City, ";
                    parameters.Add(new SqlParameter("@City", cb_City.Text));
                }
                if (!string.IsNullOrEmpty(txt_address.Text))
                {
                    updateQuery += "Address = @Address, ";
                    parameters.Add(new SqlParameter("@Address", txt_address.Text));
                }
                if (!string.IsNullOrEmpty(cb_country.Text))
                {
                    updateQuery += "Country = @Country, ";
                    parameters.Add(new SqlParameter("@Country", cb_country.Text));
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    updateQuery += "Gender = @Gender, ";
                    parameters.Add(new SqlParameter("@Gender", gender));
                }
                if (!string.IsNullOrEmpty(role))
                {
                    updateQuery += "Role = @Role, ";
                    parameters.Add(new SqlParameter("@role", role));
                }

                if (!string.IsNullOrEmpty(txt_salary.Text))
                {
                    if (!decimal.TryParse(txt_salary.Text, out decimal salary) || salary <= 0)
                    {
                        MessageBox.Show("Please enter a valid salary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    updateQuery += "Salary = @Salary, ";
                    parameters.Add(new SqlParameter("@Salary", salary));
                }


                if (parameters.Count == 0)
                {
                    MessageBox.Show("No fields to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                updateQuery = updateQuery.TrimEnd(',', ' ');

                updateQuery += " WHERE [Employee ID] = @EmployeeID";
                parameters.Add(new SqlParameter("@EmployeeID", txt_employeeid.Text));

                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddRange(parameters.ToArray());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                BindGrid();

                MessageBox.Show("Staff updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Restaurant.Employee WHERE [Employee ID] = " + txt_employeeid.Text, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
            MessageBox.Show("Staff deleted successfully.");

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Restaurant.Employee WHERE [Employee ID] = " + txt_employeeid.Text, con);
            DataSet ds = new DataSet();

            da.Fill(ds);

            BindGrid();
            dataGridView1.DataSource = ds.Tables[0];
        
        }
    }
}
