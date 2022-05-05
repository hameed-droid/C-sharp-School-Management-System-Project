using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class ManageUsers : Form
    {
       
        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB; initial catalog=SchoolManagementSystem; integrated security=true;";
        public ManageUsers()
        {
            InitializeComponent();
           
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM Users";
            SqlDataAdapter sda = new SqlDataAdapter(queryString, connection);

            DataSet dataSet = new DataSet();
            sda.Fill(dataSet, "Users");
            //   DataTable dataTable = new DataTable("Students");
            DataRow dr = dataSet.Tables["Users"].NewRow();

            dr[1] = tbUsername.Text;
            dr[2] = tbPassword.Text;

            dataSet.Tables["Users"].Rows.Add(dr);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dataSet.Tables["Users"]);
            MessageBox.Show("The User has been added");
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }


    }
}
