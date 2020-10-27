using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            StudentEdit edit = new StudentEdit();
            var result = edit.ShowDialog();
            if (DialogResult.OK == result)
            {
                File.WriteAllText(@"C:\temp\StudentEdit.json", System.Text.Json.JsonSerializer.Serialize(edit.Get()));
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Toor toorEdit = new Toor();
            toorEdit.ShowDialog();
    
            MessageBox.Show("You chose a tour for " + Toor.preview + " for 7 day from " + Toor.bday.Day + "." + Toor.bday.Month + " to " + Toor.eday.Day + "." + Toor.eday.Month);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentListForm studentListForm = new StudentListForm();
            studentListForm.ShowDialog();
        }
    }
}
