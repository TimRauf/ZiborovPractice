using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZiborovPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*private void label1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Done it!\nGreat!!!!");
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            base.Text = "Извлечение квадр.корня";
            button1.Text = "Извлечь корень";
            textBox1.Clear();
            label1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Single X;
            bool isItCypher = Single.TryParse(textBox1.Text,System.Globalization.NumberStyles.Number,System.Globalization.NumberFormatInfo.CurrentInfo,out X);
            if (isItCypher == false)
            {
                label1.Text = "please enter a number";
                label1.ForeColor = Color.Red;
                return;
            }
            var Y = (Single)Math.Sqrt(X);
            label1.ForeColor = Color.Black;
            label1.Text = String.Format("Корень из {0} равен {1:F5}",X,Y);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = string.Format("Выбранная дата - {0}",dateTimePicker1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
            SendKeys.Send("{F4}");
        }
    }
}
