using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Radiostancija
{
    public partial class Form5 : Form
    {
        int ms, s, m, t;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button1.Text = "Запись";
                if (ms == 99)
                {
                    ms = 0;
                    if (s == 59)
                    {
                        s = 0;
                        if (m == 99)
                        {
                            m = 0;
                        }
                        else m++;
                    }
                    else s++;
                }
                else ms++;
            }


            if (s <= 9)
                label2.Text = "0" + s.ToString();
            else if (s > 9)
                label2.Text = s.ToString();
            if (m <= 9)
                label1.Text = "0" + m.ToString();
            else if (m > 9)
                label1.Text = m.ToString();

            if (ms == 1)
                label3.Text = ":";
            else if (ms == 50)
                label3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.Text = "Продолжить";
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                t++;
                if (t == 99)
                    t = 0;


                if (t == 1)
                    label3.Text = ":";
                else if (t == 50)
                    label3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            label1.Text = "00";
            label2.Text = "00";
            label3.Text = ":";
            m = 0; s = 0; ms = 0;
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = true;
            button6.Enabled = true;
        }

        public Form5()
        {
            InitializeComponent();
            ms = 0; s = 0; m = 0; t = 0;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
