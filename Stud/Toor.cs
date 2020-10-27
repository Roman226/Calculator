using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stud
{
    public partial class Toor : Form
    {
        public Toor()
        {
            InitializeComponent();
        }

        public static String preview;
        public static DateTime bday;
        public static DateTime eday;

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                preview = radioButton1.Text;
            }

            if (radioButton2.Checked == true)
            {
                preview = radioButton2.Text;
            }

            if (radioButton3.Checked == true)
            {
                preview = radioButton3.Text;
            }

            bday = monthCalendar1.SelectionStart;
            eday = monthCalendar1.SelectionEnd;

            var delta = eday - bday; 

            if (delta.Days == 6) 
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Not 7 days");
            }

        }
    }
}
