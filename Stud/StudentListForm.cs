using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stud
{
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(DataBaseService.dbContext.StudentList.ToArray());
        }
        //
        //Add
        //
        private void button2_Click(object sender, EventArgs e)
        {
            StudentEdit edit = new StudentEdit();
            var result = edit.ShowDialog();
            if (DialogResult.OK == result)
            {
                Student student = edit.Get();
                DataBaseService.dbContext.StudentList.Add(student);
                listBox1.Items.Add(student);
                DataBaseService.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                return;
            }
            if(listBox1.SelectedItem != null)
            {
                Student student = new Student ();
                student = (Student)listBox1.SelectedItem;
                DataBaseService.dbContext.StudentList.Remove(student);
                listBox1.Items.Remove(student);
                DataBaseService.Save();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            if (listBox1.SelectedItem != null)
            {
                Student student = (Student)listBox1.SelectedItem;
                StudentEdit edit = new StudentEdit();
                var result = edit.ShowDialog();
                if (DialogResult.OK == result)
                {
                    student = edit.Get();
                    var key = DataBaseService.dbContext.StudentList.SingleOrDefault(s=>s.Id== student.Id);
                    if (key != null)
                    {
                        int index = DataBaseService.dbContext.StudentList.IndexOf(student);
                        DataBaseService.dbContext.StudentList[index] = student;
                    }
                    DataBaseService.Save();
                }
            }
        }
    }
}
