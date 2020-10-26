using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace From1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point p = new Point(panel1.Location.X, panel1.Location.Y);

            if (e.KeyCode == Keys.W)
            {
                if (p.Y < 0)
                {
                    p.Y = Height;
                }
                else
                {
                    p.Y -= 10;
                }
                panel1.Location = p;
            }
            if (e.KeyCode == Keys.A)
            {
                if (p.X < 0)
                {
                    p.X = Width;
                }
                else
                {
                    p.X -= 10;
                }
                panel1.Location = p;
            }
            if (e.KeyCode == Keys.S)
            {
                if (p.Y > Height)
                {
                    p.Y = 0;
                }
                else
                {
                    p.Y += 10;
                }
                panel1.Location = p;
            }
            if (e.KeyCode == Keys.D)
            {
                if (p.X > Width)
                {
                    p.X = 0;
                }
                else
                {
                    p.X += 10;
                }
                panel1.Location = p;
            }
        }
    }
}
