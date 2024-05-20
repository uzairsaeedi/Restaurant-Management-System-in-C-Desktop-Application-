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

    public partial class Order : Form
    {
        private string gender;
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RMS2.mdf;Integrated Security=True;Trust Server Certificate=True";
        public static string customerName;
        public static string itemName;
        public static string qty;
        public static string totalAmount;
        public Order()
        {
            InitializeComponent();
            cb_foodcategory.SelectedIndexChanged += cb_foodcategory_SelectedIndexChanged;
            cb_country.SelectedIndexChanged += cb_country_SelectedIndexChanged;
            cb_province.SelectedIndexChanged += cb_province_SelectedIndexChanged;
            BindGrid();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.Visible = true;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            cb_country.Items.Add("Pakistan");
            cb_country.Items.Add("India");

            cb_foodcategory.Items.Clear();

            string query = "SELECT [Category Name] FROM Restaurant.Category";

            using (SqlConnection con = new SqlConnection(connection))
            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cb_foodcategory.Items.Add(reader["Category Name"].ToString());
                    }
                }
            }
        }

        private void cb_foodcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            cb_food.Items.Clear();

            cb_food.Text = string.Empty;

            string selectedCategory = cb_foodcategory.Text;

            string query = "SELECT [Item Name] FROM Restaurant.MenuItem join Restaurant.Category on MenuItem.[Category ID] = Category.[Category ID] WHERE [Category Name] = @Category";

            using (SqlConnection con = new SqlConnection(connection))
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Category", selectedCategory);

                con.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cb_food.Items.Add(reader["Item Name"].ToString());
                    }
                }
                con.Close();
            }
        }
        public void BindGrid()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Restaurant.Orders join Restaurant.Customer on Orders.[Customer ID] = Customer.[Customer ID]", connection);


            DataSet ds = new DataSet();


            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
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
                        return -1; 
                    }
                }
            }
        }

       
        private int GetFoodId(string food)
        {
            string query = "SELECT TOP 1 [Menu Item ID] FROM Restaurant.MenuItem WHERE [Item Name] = '" + food + "' ORDER BY [Menu Item ID]";

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
                        MessageBox.Show("No available Food found.");
                        return -1;
                    }
                }
            }
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



        private void btn_place_order_Click(object sender, EventArgs e)
        {

            if (checkQuantity())
            {
                try
                {
                    customerName = txt_firstname.Text;
                    itemName = cb_food.Text;
                    qty = txt_quantity.Text;
                    totalAmount = txt_total.Text;
                    string name = txt_firstname.Text;
                    string emailaddress = txt_emailaddress.Text;
                    string phone = txt_phone.Text;
                    string address = txt_address.Text;
                    string country = cb_country.Text;
                    string city = cb_City.Text;
                    string province = cb_province.Text;
                    string food = cb_food.Text;
                    string foodcategory = cb_foodcategory.Text;
                    string quantity = txt_quantity.Text;
                    string gender = setgender();
                    DateTime date = dt_date.Value;
                    string total = txt_total.Text;

                    int customerid = GetCustomerId(name);

                    if (customerid == -1)
                    {
                        DialogResult result = MessageBox.Show("Customer not found. Do you want to register the customer?", "Customer not found", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            RegisterCustomer(name, emailaddress, phone,gender);
                            customerid = GetCustomerId(name);
                        }
                        else
                        {
                            return;
                        }
                    }

                    int foodid = GetFoodId(food);

                    using (SqlConnection sqlcon = new SqlConnection())
                    {
                        sqlcon.ConnectionString = connection;
                        sqlcon.Open();

                        string query = "INSERT INTO Restaurant.Orders VALUES(@foodid, @customer_id, @date, @total, @quantity)";
                        using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                        {
                            cmd.Parameters.AddWithValue("@foodid", foodid);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@quantity", quantity);

                            cmd.ExecuteNonQuery();
                        }

                        string query3 = "INSERT INTO Restaurant.Address([Address Line 1], City, Country, State) VALUES(@address, @city, @country, @state)";
                        using (SqlCommand cmnd = new SqlCommand(query3, sqlcon))
                        {
                            cmnd.Parameters.AddWithValue("@address", address);
                            cmnd.Parameters.AddWithValue("@city", city);
                            cmnd.Parameters.AddWithValue("@country", country);
                            cmnd.Parameters.AddWithValue("@state", province);

                            cmnd.ExecuteNonQuery();
                        }

                        MessageBox.Show("You've Placed Your Order");
                        BindGrid();
                        Bill bill = new Bill();
                        this.Hide();
                        bill.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }

        private void RegisterCustomer(string name, string email, string phone,string gender)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connection))
                {
                    sqlcon.ConnectionString = connection;
                    sqlcon.Open();

                    string query = "INSERT INTO Restaurant.Customer ([Customer Name], [Email Address], [Mobile No], Gender) VALUES (@Name, @Email, @Phone,@gender)";
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@gender", gender);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering customer: {ex.Message}");
            }
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

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            string foodName = cb_food.Text;
            string query = "SELECT Price FROM Restaurant.MenuItem WHERE [Item Name] = @FoodName";

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@FoodName", foodName);

                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int price = Convert.ToInt32(reader["Price"]);
                            int quantity = 0;

                            if (!string.IsNullOrEmpty(txt_quantity.Text))
                            {
                                quantity = Convert.ToInt32(txt_quantity.Text);
                            }

                            int totalPrice = price * quantity;
                            txt_total.Text = totalPrice.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public bool checkQuantity()
        {
            bool cond = false;
            string foodName = cb_food.Text;
            string query = "SELECT Price FROM Restaurant.MenuItem WHERE [Item Name] = @FoodName";

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@FoodName", foodName);

                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int price = Convert.ToInt32(reader["Price"]);
                            int quantity = 0;

                            if (int.TryParse(txt_quantity.Text, out quantity) && quantity >= 0)
                            {
                                txt_total.Text = (price * quantity).ToString();
                                cond = true;
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid non-negative quantity.");
                                txt_total.Text = "0";
                                cond = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return cond;
        }


    }
}
