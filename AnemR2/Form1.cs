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
            label6.Text = "P: " + calcP().ToString();
            label8.Text = "sgot: " + Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text)/6;
            label9.Text = "chol: " + Convert.ToDouble(textBox2.Text) + Convert.ToDouble(textBox3.Text) / 2;
            label10.Text = "trig: " + Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox3.Text) / 2;
            label11.Text = "platent: " + Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox3.Text) + Convert.ToDouble(textBox4.Text);
            pictureBox1.Refresh();
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
        public double calcP()
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
            double res = t1 * c1 + t2 * c2 + t3 * c3 + t4 * c4 + c5;
            return res;
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p1=new Pen(Color.Black,2);
            Pen p2 = new Pen(Color.DarkRed, 2);
            Pen p3 = new Pen(Color.DarkMagenta, 2);
            Pen p4 = new Pen(Color.DarkOrange, 2);
            e.Graphics.DrawLine(p1, 0, Convert.ToSingle(textBox1.Text), 400, Convert.ToSingle(textBox1.Text) * Convert.ToSingle(textBox1.Text) / 6);
            e.Graphics.DrawLine(p2, 0, Convert.ToSingle(textBox2.Text), 400, Convert.ToSingle(textBox2.Text) + Convert.ToSingle(textBox3.Text) / 2);
            e.Graphics.DrawLine(p3, 0, Convert.ToSingle(textBox3.Text), 400, Convert.ToSingle(textBox4.Text) * Convert.ToSingle(textBox3.Text) /10);
            e.Graphics.DrawLine(p4, 0, Convert.ToSingle(textBox4.Text), 400, Convert.ToSingle(textBox1.Text) * Convert.ToSingle(textBox3.Text)/10 + Convert.ToSingle(textBox4.Text)-60);
        }
    }
}
