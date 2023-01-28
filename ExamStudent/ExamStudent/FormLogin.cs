using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamStudent
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-23FPH155;Initial Catalog=ExamStudent;Persist Security Info=True;User ID=sa;Password=0123456");
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {

                string sql = "Select * from tblAccount where Username = '" + username + "' and [Password] = '" + password + "'";
                SqlDataAdapter dta = new SqlDataAdapter(sql, con);
                DataTable dtable = new DataTable();
                dta.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = txtUsername.Text;
                    password = txtPassword.Text;
                    MessageBox.Show("Login success");
                    MainForm form = new MainForm();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid!");

                }



            }
            catch
            {
                MessageBox.Show("Connection error");
            }
            finally
            {
                con.Close();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
