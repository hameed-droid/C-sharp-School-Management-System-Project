using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class ManageStudents : Form
    {
        
        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB; initial catalog=SchoolManagementSystem; integrated security=true;";
        public ManageStudents()
        {
            InitializeComponent();

        }
        

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM Students";
            SqlDataAdapter sda = new SqlDataAdapter(queryString, connection);

            DataSet dataSet = new DataSet();
            sda.Fill(dataSet,"Students");
         //   DataTable dataTable = new DataTable("Students");
            DataRow dr = dataSet.Tables["Students"].NewRow();

            dr[0] = Convert.ToInt32(tbSID.Text);
            dr[1] = tbName.Text;
            dr[2] = tbGender.Text;
            dr[3] = dateTimePicker1.Value;
            dr[4] = tbClass.Text;
            dr[5] = tbClass.Text;

            dataSet.Tables[0].Rows.Add(dr);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dataSet.Tables["Students"]);
            MessageBox.Show("The Student has been added");
            

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbSID.Text))
            {
                int sid = Convert.ToInt32(tbSID.Text);
                bool contains = false;
                SqlConnection connection = new SqlConnection(connectionString);
                string queryString = "SELECT * FROM Students";
                SqlDataAdapter sda = new SqlDataAdapter(queryString, connection);

                DataSet dataSet = new DataSet();
                sda.Fill(dataSet, "Students");
                DataRow dr = dataSet.Tables["Students"].NewRow();

                int tableSize = dataSet.Tables["Students"].Rows.Count;
                DataTableReader dtr = new DataTableReader(dataSet.Tables["Students"]);
                int count = 0;

                while (dtr.Read())
                {
                    count++;
                    if (Convert.ToInt32(dtr[0]) == sid)
                    {
                        contains = true;
                        dataSet.Tables["Students"].Rows[count - 1].Delete();
                        MessageBox.Show("The User has been deleted!!!");
                        SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                        sda.Update(dataSet.Tables["Students"]);
                        break;
                    }

                }

                if (!contains)
                    MessageBox.Show("The Student is not present!!!");

            }
            else
                MessageBox.Show("Please Enter A Valid ID!!!");
                
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbSID.Text))
            {
                int sid = Convert.ToInt32(tbSID.Text);
                bool contains = false;
                SqlConnection connection = new SqlConnection(connectionString);
                string queryString = "SELECT * FROM Students";
                SqlDataAdapter sda = new SqlDataAdapter(queryString, connection);

                DataSet dataSet = new DataSet();
                sda.Fill(dataSet, "Students");
                DataRow dr = dataSet.Tables["Students"].NewRow();

                int tableSize = dataSet.Tables["Students"].Rows.Count;
                DataTableReader dtr = new DataTableReader(dataSet.Tables["Students"]);
                int count = 0;

                while (dtr.Read())
                {
                    count++;
                    if (Convert.ToInt32(dtr[0]) == sid)
                    {
                        contains = true;
                        dataSet.Tables["Students"].Rows[count - 1][1] = tbName.Text;
                        dataSet.Tables["Students"].Rows[count - 1][2] = tbGender.Text;
                        dataSet.Tables["Students"].Rows[count - 1][3] = dateTimePicker1.Value;
                        dataSet.Tables["Students"].Rows[count - 1][4] = tbClass.Text;
                        dataSet.Tables["Students"].Rows[count - 1][5] = tbGrade.Text;
                        MessageBox.Show("The Student has been Updated!!!");
                        SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                        sda.Update(dataSet.Tables["Students"]);
                        break;
                    }

                }

                if (!contains)
                    MessageBox.Show("The Student is not present!!!");

            }
            else
                MessageBox.Show("Please Enter A Valid ID!!!");
        }
    }
}
