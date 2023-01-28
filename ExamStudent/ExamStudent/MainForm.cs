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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ap = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["letoan"].ConnectionString;
            cmd.Connection = conn;
            cmd.CommandText = "SELECT stuCode[Code], stuName[FullName],stuAddress[Address], stuPhone[Numphone], stuEmail[Email], stuPass[Status Pass], examName[Name Exam], examMark[Mark], examDate[Date Exam], couName[Course Name], couSemester [Semester], subName [Subject Name], depName [Department Name] FROM tblSubject INNER JOIN tblDepartment ON tblDepartment.subjectId = tblSubject.subjectId INNER JOIN tblStudent ON tblDepartment.depId = tblStudent.depId INNER JOIN tblExam ON tblExam.stuId = tblStudent.stuId INNER JOIN tblCourse ON tblCourse.couId = tblExam.couId";
            cmd.CommandType = CommandType.Text;
            ap.SelectCommand = cmd;
            ds.Tables.Clear();
            ap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bindingSource1.DataSource = ds.Tables[0];

            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            textCode.DataBindings.Add("Text", bindingSource1, "tblStudent.stuCode", true, DataSourceUpdateMode.OnPropertyChanged);
            textName.DataBindings.Add("Text", bindingSource1, "tblStudent.stuName", true, DataSourceUpdateMode.OnPropertyChanged);
            textAddress.DataBindings.Add("Text", bindingSource1, "tblStudent.stuAddress", true, DataSourceUpdateMode.OnPropertyChanged);
            textPhone.DataBindings.Add("Text", bindingSource1, "tblStudent.stuPhone", true, DataSourceUpdateMode.OnPropertyChanged);
            //textMark.DataBindings.Add("Text", bindingSource1, "examMark", true, DataSourceUpdateMode.OnPropertyChanged);



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
