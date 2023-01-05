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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["letoan"].ConnectionString;
            command.Connection = con;
            command.CommandText = "Select * from Student; select Id, FirstName from Student";
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bindingSource1.DataSource = ds.Tables[0];

            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            textId.DataBindings.Add("Text", bindingSource1, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            textFN.DataBindings.Add("Text", bindingSource1, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
            textLN.DataBindings.Add("Text", bindingSource1, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
            CheckBoxGender.DataBindings.Add("Checked", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimePickerDob.DataBindings.Add("Value", bindingSource1, "Dob", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            // ds.Tables[0].DefaultView = select * from Student
            //RowFilter = where
            ds.Tables[0].DefaultView.RowFilter = $"FirstName like '%{toolStripTextBox1.Text}%'";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            command.CommandText = "UpdateStu";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@firstname", textFN.Text);
            command.Parameters.AddWithValue("@lastname", textLN.Text);
            command.Parameters.AddWithValue("@gender", CheckBoxGender.Checked);
            command.Parameters.AddWithValue("@dob", dateTimePickerDob.Value);
            command.Parameters.AddWithValue("@id", textId.Text);

            //thay doi du lieu nen can mo ket noi
            con.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("success", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }

            textId.DataBindings.Clear();
            textFN.DataBindings.Clear();
            textLN.DataBindings.Clear();
            CheckBoxGender.DataBindings.Clear();
            dateTimePickerDob.DataBindings.Clear();
            LoadData();

        }
    }
}
