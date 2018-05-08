using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //create object for SQL connection and connect to data source. Go to Server Explorer>right click database>modify connection>advanced>copy from there.
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-9D9LNHM\SQLEXPRESS;Initial Catalog=userLogin;Integrated Security=True");
            //write sql query to get what the user entered
            string query = "select * from logins where username = '" +textBox1.Text.Trim()+ "' and '" +textBox2.Text.Trim()+"'";
            //new instance of class SqlDataAdapter to fill the data set and update database. Pass in local variable and SqlConnection as parameters.
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            //new instance of class that represents a table in memory data.
            DataTable dtbl = new DataTable();
            //use Fill to add or refresh rules in specified range in data set. Pass dtbl to sda.
            sda.Fill(dtbl);
            //once user enters username and password, this if statement will check to see if that row is in the database.
            if(dtbl.Rows.Count == 1)
            {
                //if username and password are correct, it will pull up the success form and hide the login form.
                frmLoggedIn objfrmLoggedIn = new frmLoggedIn();
                this.Hide();
                objfrmLoggedIn.Show();
            }
            //if the username/password does not match something in the database, it will show this error message.
            else

            {
                MessageBox.Show("Please check your username and password");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
