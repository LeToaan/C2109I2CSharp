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

namespace TRUNGNGHI_EXAM
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
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TRUNGNGHI_EXAM.Properties.Settings.StudentConnectionString"].ConnectionString;
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
            textMarkName.DataBindings.Add("Text", bindingSource1, "examName", true, DataSourceUpdateMode.OnPropertyChanged);
            textMark.DataBindings.Add("Text", bindingSource1, "examMark", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimeDob.DataBindings.Add("Value", bindingSource1, "examDate", true, DataSourceUpdateMode.OnPropertyChanged);
            textId.DataBindings.Add("Text", bindingSource1, "stuId", true, DataSourceUpdateMode.OnPropertyChanged);
            textIdExam.DataBindings.Add("Text", bindingSource1, "examId", true, DataSourceUpdateMode.OnPropertyChanged);

        }
        private void Load()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            command.CommandText = "InsertStudent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@stuCode", textCode.Text);
            command.Parameters.AddWithValue("@stuName", textName.Text);
            command.Parameters.AddWithValue("@stuAddress", textAddress.Text);
            command.Parameters.AddWithValue("@stuPhone", textPhone.Text);
            command.Parameters.AddWithValue("@stuEmail", textEmail.Text);
            command.Parameters.AddWithValue("@examName", textMarkName.Text);
            command.Parameters.AddWithValue("@examMark", textMark.Text);
            command.Parameters.AddWithValue("@examDate", dateTimeDob.Value);


            con.Open();
            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Add succes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
            textId.DataBindings.Clear();
            textIdExam.DataBindings.Clear();
            textCode.DataBindings.Clear();
            textName.DataBindings.Clear();
            textAddress.DataBindings.Clear();
            textPhone.DataBindings.Clear();
            textEmail.DataBindings.Clear();
            textMarkName.DataBindings.Clear();
            textMark.DataBindings.Clear();
            dateTimeDob.DataBindings.Clear();
            Load();
        }

    }
}
}
