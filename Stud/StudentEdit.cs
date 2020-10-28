using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stud
{
    public partial class StudentEdit : Form
    {
        public StudentEdit()
        {
            InitializeComponent();
        }


        private Guid _id = Guid.NewGuid();

        public void Put(Student student)
        {
            textBox1.Text = student.Fname;
            textBox2.Text = student.Lname;
            textBox3.Text = student.Group;
            textBox4.Text = student.Age.ToString();
            dateTimePicker1.Value = student.DateBirth;
            _id = student.Id;
        }
        public Student Get()
        {
            Student student = new Student();
            student.Fname = textBox1.Text;
            student.Lname = textBox2.Text;
            student.Group = textBox3.Text;
            student.Age = int.Parse(textBox4.Text);
            student.DateBirth = dateTimePicker1.Value;
            student.Id = _id;
            return student;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int a))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Koppppeeetsss");
            }

        }
    }
}
