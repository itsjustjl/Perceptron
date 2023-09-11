using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        Perceptron p;
        Boolean button2on = false;
        Boolean button3on = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = new Perceptron();
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double[][] inputSet =
            {
                new double[] {1, 1},
                new double[] {1, -1},
                new double[] {-1, 1},
                new double[] {-1, -1}
            };
            int[] outputSet = { 1, -1, -1, -1 };
            int epochs = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < epochs; i++)
            {
                for (int j = 0; j < inputSet.Length; j++)
                {
                    p.activation(inputSet[j]);
                    p.adjust(outputSet[j]);
                }
            }

            double[] input = new double[2];
            if(button2.BackColor == Color.Black)
            {
                input[0] = 1;
            }
            else
            {
                input[0] = -1;
            }

            if (button3.BackColor == Color.Black)
            {
                input[1] = 1;
            }
            else
            {
                input[1] = -1;
            }
            int output = p.activation(input);
            Console.WriteLine(output);
            if(output == 1)
            {
                button5.BackColor = Color.Black;
            }
            else
            {
                button5.BackColor = Color.White;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2on == false)
            {
                button2on = true;
                button2.BackColor = Color.Black;
            }
            else
            {
                button2on = false;
                button2.BackColor = Color.White;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3on == false)
            {
                button3on = true;
                button3.BackColor = Color.Black;
            }
            else
            {
                button3on = false;
                button3.BackColor = Color.White;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
