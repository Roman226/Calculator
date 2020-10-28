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

        private Timer _timer = new Timer();

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
            studentListForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentListForm2 studentListForm = new StudentListForm2();
            studentListForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _timer.Start();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 1000;
            
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                _timer.Stop();
            }
            else
            {
                ++progressBar1.Value;
            }
        }
    }
}
