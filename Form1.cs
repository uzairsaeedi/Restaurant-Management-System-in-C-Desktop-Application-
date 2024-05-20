using Microsoft.Data.SqlClient;
using System.Data;

namespace RMS
{
    public partial class Form1 : Form
    {
        public static string username;
        private string role;
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\login.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

        }

        public string Role { get => role; set => role = value; }

        public string setrole()
        {
            if (rb_admin.Checked == true)
                Role = "admin";
            else if (rb_employee.Checked == true)
                Role = "staff";
            else
                Role = " ";
            return Role;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = connection;
            sqlcon.Open();

            username = txt_username.Text;
            string password = txt_password.Text;
            string role = setrole();
            string query = "SELECT username, password, role FROM login WHERE username = @username AND password = @password AND role = @role";

            using (SqlCommand cmd = new SqlCommand(query, sqlcon))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    username = dt.Rows[0]["username"].ToString();

                    if (role == "admin")
                    {
                        AdminDashboard dashboard = new AdminDashboard();
                        this.Hide();
                        dashboard.Visible = true;
                    }
                    else if (role == "staff")
                    {
                        Dashboard dashboard = new Dashboard();
                        this.Hide();
                        dashboard.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Login please check username/password/role");
                }
            }

            sqlcon.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.PasswordChar = checkBox1.Checked ? '\0' : '*';

        }
    }
}
