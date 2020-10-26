using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double? first;
        double? second;

        bool add;
        bool minus;
        bool div;
        bool mult;

        UInt16 numsAfterDot;
        bool dot;
        
        public Form1()
        {
            InitializeComponent();
            first = null;
            second = null;
            
            add = false;
            minus = false;
            div = false;
            mult = false;

            numsAfterDot = 0;
            dot = false;
        }

        private void _resetOperations()
        {
            add = false;
            minus = false;
            div = false;
            mult = false;
            dot = false;
            numsAfterDot = 0;
        }

        private void _setNums(double num)
        {
            if (dot == true)
            {
                ++numsAfterDot;
                for (int i = 0; i < numsAfterDot; ++i)
                {
                    num /= 10;
                }
                if (first == null)
                {
                    first = num;
                }
                else if (div == false && mult == false && minus == false && add == false)
                {
                    first += num;
                }
                else if (second == null)
                {
                    second = num;
                }
                else
                {
                    second += num;
                }
            }
            else
            {
                if (first == null)
                {
                    first = num;
                }
                else if (div == false && mult == false && minus == false && add == false)
                {
                    first *= 10;
                    first += num;
                }
                else if (second == null)
                {
                    second = num;
                }
                else
                {
                    second *= 10;
                    second += num;
                }
            }
        }

        //  /
        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "/";
            _resetOperations();
            div = true;
        }

        //*
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "x";
            _resetOperations();
            mult = true;
        }

        //-
        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "-";
            _resetOperations();
            minus = true;
        }

        //+
        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "+";
            _resetOperations();
            add = true;
        }

        //+/-
        private void button15_Click(object sender, EventArgs e)
        {
            if (div == false && mult == false && minus == false && add == false)
            {
                first *= -1;
                textBox1.Text = first.ToString();
            }
            else
            {
                second *= -1;
                textBox1.Text = second.ToString();
            }
        }

        //C
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            first = null;
            second = null;
        }

        //CE
        private void button8_Click(object sender, EventArgs e)
        {
            if (div == false && mult == false && minus == false && add == false)
            {
                first = null;
            }
            else
            {
                second = null;
            }
            textBox1.Text = "";
        }

        // 0 - 9 numbers
        private void button14_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text == "/" || textBox1.Text == "x" || textBox1.Text == "-" || textBox1.Text == "+")
            {
                textBox1.Text = "";
            }
            Button b = (Button)sender;
            textBox1.Text += b.Text;
            UInt16 num = 0;
            UInt16.TryParse(b.Tag.ToString(),out num);
            _setNums(num);
        }

        //=
        private void button16_Click(object sender, EventArgs e)
        {
            if (add == true)
            {
                textBox1.Text = (first + second).ToString();
                first = first + second;
            }
            if (minus == true)
            {
                textBox1.Text = (first - second).ToString();
                first = first - second;
            }
            if (mult == true)
            {
                textBox1.Text = (first * second).ToString();
                first = first * second;
            }
            if (div == true)
            {
                if (second == 0)
                {
                    textBox1.Text = "Can't divide by 0";
                    first = null;
                }
                else
                {
                    textBox1.Text = (first / second).ToString();
                    first = first / second;
                }
            }
            _resetOperations();
            second = null;
        }

        //x^2
        private void button12_Click(object sender, EventArgs e)
        {
            if (div == false && mult == false && minus == false && add == false)
            {
                first *= first;
                textBox1.Text = first.ToString();
            }
            else
            {
                second *= second;
                textBox1.Text = second.ToString();
            }
        }
        
        //.
        private void button13_Click(object sender, EventArgs e)
        {
            if (dot == false)
            {
                if (div == true || mult == true || minus == true || add == true)
                {
                    if (second != null)
                    {
                        dot = true;
                        textBox1.Text += ".";
                    }
                }
                if(div == false && mult == false && minus == false && add == false)
                {
                    if(first != null)
                    {
                        dot = true;
                        textBox1.Text += ".";
                    }
                }
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.Aqua;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.White;
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            Trace.WriteLine("mouse hover");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
