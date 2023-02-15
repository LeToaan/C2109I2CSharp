using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Configuration;


namespace EXAM_TRUNGNGHI_C2109I2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter= new SqlDataAdapter();
        DataSet ds= new DataSet();
        private void Form1_Load(object sender, EventArgs e)
        {
            Load();
        }
        private void Load()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["trungnghi"].ConnectionString;
            command.Connection = con;
            command.CommandText = "SELECT stuCode, stuName, stuAddress, stuPhone, stuEmail, examName, examMark, examDate, depName, couName, couSemester FROM tblStudent INNER JOIN tblDepartment ON tblDepartment.depId = tblStudent.depId INNER JOIN tblExam ON tblExam.stuId = tblStudent.stuId INNER JOIN tblCourse ON tblCourse.couId = tblExam.couId";
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            bindingSource2.DataSource = ds.Tables[0];

            dataGridView2.DataSource = bindingSource2;
            bindingNavigator2.BindingSource = bindingSource2;
        }
    }
}
