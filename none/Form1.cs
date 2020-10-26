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

namespace none
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Timer timer;
        Random rand = new Random();

        private void quit(object sender, EventArgs e)
        {
            var a = MessageBox.Show("", "Do you really want to close program??", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                Config config = new Config();
                config.X = Location.X;
                config.Y = Location.Y;
                config.Width = Width;
                config.Height = Height;
                var str = System.Text.Json.JsonSerializer.Serialize(config);
                File.WriteAllText(@"C:\temp/Config.json", str);
                
                Close();
            }
        }

        private void changeSize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void showMessageBox(object sender, EventArgs e)
        {
            var a = new Form1();
            a.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Config config = System.Text.Json.JsonSerializer.Deserialize<Config>(File.ReadAllText(@"C:\temp\Config.json"));
            Point p = new Point(config.X, config.Y);
            Location = p;
            Width = config.Width;
            Height = config.Height;
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Point p = new Point(rand.Next(0, 1000), rand.Next(0, 600));
            Location = p;
           
        }
    }
}
