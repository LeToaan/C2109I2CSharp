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
using static System.Net.Mime.MediaTypeNames;

namespace EXAM_NGHI_C2109I2
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
            con.ConnectionString = ConfigurationManager.ConnectionStrings["EXAM_NGHI_C2109I2.Properties.Settings.StudentConnectionString"].ConnectionString;
            command.Connection = con;
            command.CommandText = "SELECT tblStudent.stuId, stuCode, stuName, stuAddress, stuPhone, stuEmail, examId, examName, examMark, examDate, depName, couName, couSemester FROM tblStudent\t INNER JOIN tblDepartment ON tblDepartment.depId = tblStudent.depId INNER JOIN tblExam ON tblExam.stuId = tblStudent.stuId INNER JOIN tblCourse ON tblCourse.couId = tblExam.couId";
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bindingSource1.DataSource = ds.Tables[0];

            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            textCode.DataBindings.Add("Text", bindingSource1, "stuCode", true, DataSourceUpdateMode.OnPropertyChanged);
            textName.DataBindings.Add("Text", bindingSource1, "stuName", true, DataSourceUpdateMode.OnPropertyChanged);
            textAddress.DataBindings.Add("Text", bindingSource1, "stuAddress", true, DataSourceUpdateMode.OnPropertyChanged);
            textPhone.DataBindings.Add("Text", bindingSource1, "stuPhone", true, DataSourceUpdateMode.OnPropertyChanged);
            textEmail.DataBindings.Add("Text", bindingSource1, "stuEmail", true, DataSourceUpdateMode.OnPropertyChanged);
            textMarkN.DataBindings.Add("Text", bindingSource1, "examName", true, DataSourceUpdateMode.OnPropertyChanged);
            textMark.DataBindings.Add("Text", bindingSource1, "examMark", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimeDob.DataBindings.Add("Value", bindingSource1, "examDate", true, DataSourceUpdateMode.OnPropertyChanged);
            textId.DataBindings.Add("Text", bindingSource1, "stuId", true, DataSourceUpdateMode.OnPropertyChanged);
            textIdMark.DataBindings.Add("Text", bindingSource1, "examId", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            command.CommandText = "InsertStu";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@stuCode", textCode.Text);
            command.Parameters.AddWithValue("@stuName", textName.Text);
            command.Parameters.AddWithValue("@stuAddress", textAddress.Text);
            command.Parameters.AddWithValue("@stuPhone", textPhone.Text);
            command.Parameters.AddWithValue("@stuEmail", textEmail.Text);
            command.Parameters.AddWithValue("@examName", textMarkN.Text);
            command.Parameters.AddWithValue("@examMark", textMark.Text);
            command.Parameters.AddWithValue("@examDate", dateTimeDob.Value);


            con.Open();
            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
            textId.DataBindings.Clear();
            textIdMark.DataBindings.Clear();
            textCode.DataBindings.Clear();
            textName.DataBindings.Clear();
            textAddress.DataBindings.Clear();
            textPhone.DataBindings.Clear();
            textEmail.DataBindings.Clear();
            textMarkN.DataBindings.Clear();
            textMark.DataBindings.Clear();
            dateTimeDob.DataBindings.Clear();
            LoadData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            command.CommandText = "UpdateStu";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@stuCode", textCode.Text);
            command.Parameters.AddWithValue("@stuName", textName.Text);
            command.Parameters.AddWithValue("@stuAddress", textAddress.Text);
            command.Parameters.AddWithValue("@stuPhone", textPhone.Text);
            command.Parameters.AddWithValue("@stuEmail", textEmail.Text);
            command.Parameters.AddWithValue("@examName", textMarkN.Text);
            command.Parameters.AddWithValue("@examMark", textMark.Text);
            command.Parameters.AddWithValue("@examDate", dateTimeDob.Value);
            command.Parameters.AddWithValue("@stuId", textId.Text);
            command.Parameters.AddWithValue("@examId", textIdMark.Text);


            con.Open();
            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();

                command.Parameters.Clear();
            }
            textId.DataBindings.Clear();
            textIdMark.DataBindings.Clear();
            textCode.DataBindings.Clear();
            textName.DataBindings.Clear();
            textAddress.DataBindings.Clear();
            textPhone.DataBindings.Clear();
            textEmail.DataBindings.Clear();
            textMarkN.DataBindings.Clear();
            textMark.DataBindings.Clear();
            dateTimeDob.DataBindings.Clear();
            LoadData();
        }

        private void Del_Click(object sender, EventArgs e)
        {
            command.CommandText = "DeleteStu";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@examId", textIdMark.Text);
            command.Parameters.AddWithValue("@stuId", textId.Text);

            con.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { con.Close();
                command.Parameters.Clear();
            }
            textId.DataBindings.Clear();
            textIdMark.DataBindings.Clear();
            textCode.DataBindings.Clear();
            textName.DataBindings.Clear();
            textAddress.DataBindings.Clear();
            textPhone.DataBindings.Clear();
            textEmail.DataBindings.Clear();
            textMarkN.DataBindings.Clear();
            textMark.DataBindings.Clear();
            dateTimeDob.DataBindings.Clear();
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = $"stuCode like '%{toolStripTextBox1.Text}%'";
        }
    }
}
