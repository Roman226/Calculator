﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}