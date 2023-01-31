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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            cmd.CommandText = "SELECT tblStudent.stuId,  stuCode, stuName,stuAddress, stuPhone, stuEmail, examId, examName, examMark, examDate, couName, couSemester, subName, depName, stuStatus FROM tblSubject INNER JOIN tblDepartment ON tblDepartment.subjectId = tblSubject.subjectId INNER JOIN tblStudent ON tblDepartment.depId = tblStudent.depId INNER JOIN tblExam ON tblExam.stuId = tblStudent.stuId INNER JOIN tblCourse ON tblCourse.couId = tblExam.couId WHERE stuStatus = 1";
            cmd.CommandType = CommandType.Text;
            ap.SelectCommand = cmd;
            ds.Tables.Clear();
            ap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bindingSource1.DataSource = ds.Tables[0];

            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            textCode.DataBindings.Add("Text", bindingSource1, "stuCode", true, DataSourceUpdateMode.OnPropertyChanged);
            textName.DataBindings.Add("Text", bindingSource1, "stuName", true, DataSourceUpdateMode.OnPropertyChanged);
            textAddress.DataBindings.Add("Text", bindingSource1, "stuAddress", true, DataSourceUpdateMode.OnPropertyChanged);
            textPhone.DataBindings.Add("Text", bindingSource1, "stuPhone", true, DataSourceUpdateMode.OnPropertyChanged);
            textEmail.DataBindings.Add("Text", bindingSource1, "stuEmail", true, DataSourceUpdateMode.OnPropertyChanged);
            textNameExam.DataBindings.Add("Text", bindingSource1, "examName", true, DataSourceUpdateMode.OnPropertyChanged);
            textMark.DataBindings.Add("Text", bindingSource1, "examMark", true, DataSourceUpdateMode.OnPropertyChanged);
            dateDob.DataBindings.Add("Value", bindingSource1, "examDate", true, DataSourceUpdateMode.OnPropertyChanged);
            textId.DataBindings.Add("Text", bindingSource1, "stuId", true, DataSourceUpdateMode.OnPropertyChanged);
            textIdExam.DataBindings.Add("Text", bindingSource1, "examId", true, DataSourceUpdateMode.OnPropertyChanged);



        }


        //int ID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private bool CheckInput()
        {
            
            
                if (string.IsNullOrWhiteSpace(textCode.Text))
                {
                    MessageBox.Show("You haven't enter student code!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textCode.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(textName.Text))
                {
                    MessageBox.Show("You haven't enter student name!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textName.Focus();
                    return false;
                }
            else if (string.IsNullOrWhiteSpace(textPhone.Text))
            {
                MessageBox.Show("You haven't enter student phone!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPhone.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textEmail.Text))
            {
                MessageBox.Show("You haven't enter student email!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEmail.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textAddress.Text))
            {
                MessageBox.Show("You haven't enter student address!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textAddress.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textNameExam.Text))
            {
                MessageBox.Show("You haven't enter exam name!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textNameExam.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textMark.Text))
            {
                MessageBox.Show("You haven't enter exam mark!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMark.Focus();
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                cmd.CommandText = "UpdateStu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stuCode", textCode.Text);
                cmd.Parameters.AddWithValue("@stuName", textName.Text);
                cmd.Parameters.AddWithValue("@stuAddress", textAddress.Text);
                cmd.Parameters.AddWithValue("@stuPhone", textPhone.Text);
                cmd.Parameters.AddWithValue("@stuEmail", textEmail.Text);
                cmd.Parameters.AddWithValue("@examName", textNameExam.Text);
                cmd.Parameters.AddWithValue("@examMark", textMark.Text);
                cmd.Parameters.AddWithValue("@examDate", dateDob.Value);
                cmd.Parameters.AddWithValue("@stuId", textId.Text);
                cmd.Parameters.AddWithValue("@examId", textIdExam.Text);


                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update succes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    conn.Close();

                    cmd.Parameters.Clear();
                }
                textId.DataBindings.Clear();
                textIdExam.DataBindings.Clear();
                textCode.DataBindings.Clear();
                textName.DataBindings.Clear();
                textAddress.DataBindings.Clear();
                textPhone.DataBindings.Clear();
                textEmail.DataBindings.Clear();
                textNameExam.DataBindings.Clear();
                textMark.DataBindings.Clear();
                dateDob.DataBindings.Clear();
                LoadData();
            }
           
        }

        private void textPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                cmd.CommandText = "InsertStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stuCode", textCode.Text);
                cmd.Parameters.AddWithValue("@stuName", textName.Text);
                cmd.Parameters.AddWithValue("@stuAddress", textAddress.Text);
                cmd.Parameters.AddWithValue("@stuPhone", textPhone.Text);
                cmd.Parameters.AddWithValue("@stuEmail", textEmail.Text);
                cmd.Parameters.AddWithValue("@examName", textNameExam.Text);
                cmd.Parameters.AddWithValue("@examMark", textMark.Text);
                cmd.Parameters.AddWithValue("@examDate", dateDob.Value);


                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Add succes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    conn.Close();
                    cmd.Parameters.Clear();
                }
                textId.DataBindings.Clear();
                textIdExam.DataBindings.Clear();
                textCode.DataBindings.Clear();
                textName.DataBindings.Clear();
                textAddress.DataBindings.Clear();
                textPhone.DataBindings.Clear();
                textEmail.DataBindings.Clear();
                textNameExam.DataBindings.Clear();
                textMark.DataBindings.Clear();
                dateDob.DataBindings.Clear();
                LoadData();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool check = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            cmd.CommandText = "DeleteStu";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stuId", textId.Text);

            if(check)
            {
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete succes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    conn.Close();
                    cmd.Parameters.Clear();
                }
                 textId.DataBindings.Clear();
                 textIdExam.DataBindings.Clear();
                 textCode.DataBindings.Clear();
                 textName.DataBindings.Clear();
                 textAddress.DataBindings.Clear();
                 textPhone.DataBindings.Clear();
                 textEmail.DataBindings.Clear();
                 textNameExam.DataBindings.Clear();
                 textMark.DataBindings.Clear();
                 dateDob.DataBindings.Clear();
                 LoadData();
            }
           
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = $"stuCode like '%{toolStripTextBox1.Text}%' OR "+ $"stuName like '%{toolStripTextBox1.Text}%' OR "+ $"stuPhone like '%{toolStripTextBox1.Text}%' OR "+ $"stuEmail like '%{toolStripTextBox1.Text}%'";
     

        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            textId.DataBindings.Clear();
            textIdExam.DataBindings.Clear();
            textCode.DataBindings.Clear();
            textName.DataBindings.Clear();
            textAddress.DataBindings.Clear();
            textPhone.DataBindings.Clear();
            textEmail.DataBindings.Clear();
            textNameExam.DataBindings.Clear();
            textMark.DataBindings.Clear();
            dateDob.DataBindings.Clear();
            LoadData();
        }

        private void btnListDel_Click(object sender, EventArgs e)
        {
            textId.DataBindings.Clear();
            textIdExam.DataBindings.Clear();
            textCode.DataBindings.Clear();
            textName.DataBindings.Clear();
            textAddress.DataBindings.Clear();
            textPhone.DataBindings.Clear();
            textEmail.DataBindings.Clear();
            textNameExam.DataBindings.Clear();
            textMark.DataBindings.Clear();
            dateDob.DataBindings.Clear();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["letoan"].ConnectionString;
            cmd.Connection = conn;
            cmd.CommandText = "SELECT tblStudent.stuId,  stuCode, stuName,stuAddress, stuPhone, stuEmail, examId, examName, examMark, examDate, couName, couSemester, subName, depName, stuStatus FROM tblSubject INNER JOIN tblDepartment ON tblDepartment.subjectId = tblSubject.subjectId INNER JOIN tblStudent ON tblDepartment.depId = tblStudent.depId INNER JOIN tblExam ON tblExam.stuId = tblStudent.stuId INNER JOIN tblCourse ON tblCourse.couId = tblExam.couId WHERE stuStatus = 0";
            cmd.CommandType = CommandType.Text;
            ap.SelectCommand = cmd;
            ds.Tables.Clear();
            ap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bindingSource1.DataSource = ds.Tables[0];

            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            textCode.DataBindings.Add("Text", bindingSource1, "stuCode", true, DataSourceUpdateMode.OnPropertyChanged);
            textName.DataBindings.Add("Text", bindingSource1, "stuName", true, DataSourceUpdateMode.OnPropertyChanged);
            textAddress.DataBindings.Add("Text", bindingSource1, "stuAddress", true, DataSourceUpdateMode.OnPropertyChanged);
            textPhone.DataBindings.Add("Text", bindingSource1, "stuPhone", true, DataSourceUpdateMode.OnPropertyChanged);
            textEmail.DataBindings.Add("Text", bindingSource1, "stuEmail", true, DataSourceUpdateMode.OnPropertyChanged);
            textNameExam.DataBindings.Add("Text", bindingSource1, "examName", true, DataSourceUpdateMode.OnPropertyChanged);
            textMark.DataBindings.Add("Text", bindingSource1, "examMark", true, DataSourceUpdateMode.OnPropertyChanged);
            dateDob.DataBindings.Add("Value", bindingSource1, "examDate", true, DataSourceUpdateMode.OnPropertyChanged);
            textId.DataBindings.Add("Text", bindingSource1, "stuId", true, DataSourceUpdateMode.OnPropertyChanged);
            textIdExam.DataBindings.Add("Text", bindingSource1, "examId", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
