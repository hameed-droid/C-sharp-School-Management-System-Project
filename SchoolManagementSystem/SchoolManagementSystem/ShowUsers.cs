using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class ShowUsers : Form
    {
     
        public ShowUsers()
        {
            InitializeComponent();
           

        }

        private void ShowUsers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolManagementSystemDataSet4.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.schoolManagementSystemDataSet4.Users);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }
}
