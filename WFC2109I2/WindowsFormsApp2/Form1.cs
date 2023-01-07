using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var ef = new WFC2109I2Entities()) {
               
                bindingSource1.DataSource = ef.Students.ToList();
                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
                
                textId.DataBindings.Add("Text", bindingSource1, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
                textFN.DataBindings.Add("Text", bindingSource1, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
                textLN.DataBindings.Add("Text", bindingSource1, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
                CBGender.DataBindings.Add("Checked", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
                dateDob.DataBindings.Add("Value", bindingSource1, "Dob", true, DataSourceUpdateMode.OnPropertyChanged);


                //dataGridView1.DataSource = ef.Students.ToList();



                //dataGridView1.DataSource = ef.Students.Select(
                //    stu => new
                //    {
                //        stu.Id, stu.FirstName, stu.LastName
                //    }).ToList();
            }


        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var ef = new WFC2109I2Entities())
            {
                var findId = Convert.ToInt32(textId.Text);
                var obj = await ef.Students.FirstOrDefaultAsync(stu => stu.Id == findId);
                if(obj != null)
                {
                    obj.FirstName = textFN.Text;
                    obj.LastName  = textLN.Text;
                    obj.Gender    = CBGender.Checked;
                    obj.Dob       = dateDob.Value;
                }
                await ef.SaveChangesAsync();

                bindingSource1.DataSource = await ef.Students.ToListAsync();
                MessageBox.Show("Success", "Info");
            }


        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var ef = new WFC2109I2Entities())
            {
                var stu = new Student();
                stu.FirstName = textFN.Text;
                stu.LastName = textLN.Text;
                stu.Gender = CBGender.Checked;
                stu.Dob= dateDob.Value;

                ef.Students.Add(stu);

                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.ToListAsync();
                MessageBox.Show("Add Success", "Info");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (var ef = new WFC2109I2Entities())
            { 
                var findId = Convert.ToInt32(textId.Text);

                foreach (var stu in ef.Students)
                {
                    if(stu.Id== findId)
                    {
                        ef.Students.Remove(stu);
                    }
                    

                }
                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.ToListAsync();
                MessageBox.Show("Delete Success", "Info");
            }
        }
    }
}
