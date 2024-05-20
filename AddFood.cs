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
    public partial class AddFood : Form
    {

        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RMS2.mdf;Integrated Security=True;Trust Server Certificate=True";

        public AddFood()
        {
            InitializeComponent();
        }

        private void btn_add_food_Click(object sender, EventArgs e)
        {
            try
            {
                string food = txt_food.Text;
                string priceText = txt_price.Text;
                string description = txt_description.Text;
                string foodcategory = cb_foodcategory.Text;
                int categoryid = GetCategoryId(foodcategory);

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please select an image for the food item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the price value is a valid non-negative decimal
                if (!decimal.TryParse(priceText, out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] imageBytes = ImageToByteArray(pictureBox1.Image);

                using (SqlConnection sqlcon = new SqlConnection())
                {
                    sqlcon.ConnectionString = connection;
                    sqlcon.Open();

                    string query = "INSERT INTO Restaurant.MenuItem([Category ID],[Item Name], [Item Description], Price, Image) VALUES(@categoryid,@food,@description,@price, @imageData)";
                    using (SqlCommand cmnd = new SqlCommand(query, sqlcon))
                    {
                        cmnd.Parameters.AddWithValue("@categoryid", categoryid);
                        cmnd.Parameters.AddWithValue("@food", food);
                        cmnd.Parameters.AddWithValue("@description", description);
                        cmnd.Parameters.AddWithValue("@price", price);
                        cmnd.Parameters.AddWithValue("@imageData", imageBytes);

                        cmnd.ExecuteNonQuery();
                    }

                    MessageBox.Show("You've Added Food Item");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private int GetCategoryId(string category)
        {
            string query = "SELECT TOP 1 [Category ID] FROM Restaurant.Category WHERE [Category Name] = '" + category + "' ORDER BY [Category ID]";

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
        private void AddFood_Load(object sender, EventArgs e)
        {
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
