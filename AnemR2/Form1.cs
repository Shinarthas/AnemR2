using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnemR2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = (textBox1.Text);
            string t2 = (textBox2.Text);
            string t3 = (textBox3.Text);
            string t4 = (textBox4.Text);
            if (t1 == "" || t2 == "" || t3 == "" || t4 == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            label4.Text="status: "+calcStatus().ToString();
        }

        public int calcStatus()
        {
            double t1 = Convert.ToDouble(textBox1.Text);
            double t2 = Convert.ToDouble(textBox2.Text);
            double t3 = Convert.ToDouble(textBox3.Text);
            double t4 = Convert.ToDouble(textBox4.Text);
            double c1 = 0.317;
            double c2 = 0.416;
            double c3 = 0.676;
            double c4 = 0.047;
            double c5 = -12.165;
            double res = t1*c1 + t2*c2 + t3*c3 + t4*c4 + c5;
            return res > 0 ? 1 : 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if (this.Text.IndexOf(',') != -1 || this.Text.Length == 0)
                    e.Handled = true;
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1))
                        button1.Focus();
                    else
                    {
                        button1.Focus();
                    }
                }
                return;
            }
            e.Handled = true;
        }
    }
}
