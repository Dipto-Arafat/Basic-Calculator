using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Task_2
{
    public partial class Form1 : Form
    {
        string operationType = "",lastButton="",tempType="";
        double result = 0;
        bool isPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="0" || (isPerformed))
            {
                textBox1.Clear();
            }
            if (textBox2.Text == "0")
            {
                textBox2.Clear();
            }

            if (lastButton == "=")
            {
                textBox2.Clear();
                textBox1.Clear();
            }
            Button btn =(Button)sender;
            if (btn.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                {
                    textBox1.Text = textBox1.Text + btn.Text;
                    textBox2.Text = textBox2.Text + btn.Text;
                }
            }
            else
            {
                textBox2.Text = textBox2.Text + btn.Text;
                textBox1.Text = textBox1.Text + btn.Text;
            }
            isPerformed = false;
            lastButton = btn.Text;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Clear();
            tempType = "=";
            operationType = "";
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Clear();
            tempType = "=";
            operationType = "";
        }
        private void Operator_Click(object sender, EventArgs e)
        {
            if (lastButton == "=")
            {
                if (textBox1.Text == "MATH ERROR")
                {
                    textBox2.Text = "0";
                }
                else
                textBox2.Text = textBox1.Text;
            }
            if (lastButton == ".")
            {
                //
            }
            if (lastButton == "+" || lastButton == "-" || lastButton == "×" || lastButton == "÷" )
            {
                textBox2.Text= textBox2.Text.TrimEnd(textBox2.Text[textBox2.Text.Length-1]);
                textBox2.Text += ((Button)sender).Text;
                operationType = ((Button)sender).Text;
            }
            else
            {
                Button btn = (Button)sender;
                textBox2.Text = textBox2.Text + btn.Text;
                tempType = operationType;
                if (tempType == "+" || tempType == "-" || tempType == "×" || tempType == "÷")
                {
                    Button4_Click(sender, e);
                }
                if (textBox1.Text == "MATH ERROR") { textBox1.Text = "0"; }
                result = double.Parse(textBox1.Text);
                operationType = btn.Text;
                isPerformed = true;
                lastButton = btn.Text;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text + "^2";
            textBox1.Text = (double.Parse(textBox1.Text) * double.Parse(textBox1.Text)).ToString();
            lastButton = "=";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox2.Text = "SQRT("+textBox1.Text+")";
            textBox1.Text = (Math.Sqrt(double.Parse(textBox1.Text))).ToString();
            lastButton = "=";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "MATH ERROR";
                lastButton = "=";
            }
            else
            {
                textBox2.Text = "(1/" + textBox1.Text + ")";
                textBox1.Text = (1 / double.Parse(textBox1.Text)).ToString();
                lastButton = "=";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text + "%";
            textBox1.Text = (double.Parse(textBox1.Text)* double.Parse(textBox1.Text) / 100).ToString();
            lastButton = "=";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "NEG("+textBox1.Text + ")";
            textBox1.Text = (-(double.Parse(textBox1.Text))).ToString();
            lastButton = "=";
        }
        
        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            if(textBox1.Text.Length >= 1)
               textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            textBox2.Text = textBox1.Text;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (lastButton == "=")
            {
                textBox1.Text = textBox1.Text;
            }
            else
            {
                switch (operationType)
                {
                    case (""):
                        textBox1.Text = result.ToString();
                        break;
                    case ("+"):
                        textBox1.Text = (result + double.Parse(textBox1.Text)).ToString();
                        break;
                    case ("-"):
                        textBox1.Text = (result - double.Parse(textBox1.Text)).ToString();
                        break;
                    case ("×"):
                        textBox1.Text = (result * double.Parse(textBox1.Text)).ToString();
                        break;
                    case ("÷"):
                        if (double.Parse(textBox1.Text) == 0)
                        {
                            textBox1.Text = "MATH ERROR";
                        }
                        else
                        {
                            textBox1.Text = (result / double.Parse(textBox1.Text)).ToString();
                        }
                        operationType = "";
                        break;
                    default:
                        operationType = "";
                        break;
                }
            }
            lastButton = ((Button)sender).Text;
            tempType = "=";
            operationType = "";
        }
    }
}
