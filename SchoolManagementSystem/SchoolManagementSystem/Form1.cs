using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class LoginForm : Form
    {
        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB; initial catalog=SchoolManagementSystem; integrated security=true;";
        public LoginForm()
        {
            InitializeComponent();

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if(tbPassword.UseSystemPasswordChar != Enabled)
            tbPassword.UseSystemPasswordChar = Enabled;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(tbUsername.Text) && (!string.IsNullOrWhiteSpace(tbPassword.Text)))
            {
                bool contains = false;
                SqlConnection connection = new SqlConnection(connectionString);
                string queryString = "SELECT * FROM Users";
                SqlDataAdapter sda = new SqlDataAdapter(queryString, connection);

                DataSet dataSet = new DataSet();
                sda.Fill(dataSet, "Users");
                DataRow dr = dataSet.Tables["Users"].NewRow();

                int tableSize = dataSet.Tables["Users"].Rows.Count;
                DataTableReader dtr = new DataTableReader(dataSet.Tables["Users"]);

                while (dtr.Read())
                {
                    if (Convert.ToString((dtr[1])) == tbUsername.Text && Convert.ToString(dtr[2]) == tbPassword.Text)
                    {
                        contains = true;
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                        break;
                    }

                }

                if (!contains)
                    MessageBox.Show("Invalid user!!!");

            }
            else
                MessageBox.Show("Please Enter A Valid ID!!!");
        }

       
    }
 }
