using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZiborovPractice
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Print Greek letters";
            label1.Text = String.Format(" Надйем длину окружности {0} = 2{1}{2}{1}R",Convert.ToChar(0x3B2), Convert.ToChar(0x2219),
                Convert.ToChar(0x30), Math.PI);
            button1.Text = "Testing...";
            toolTip1.SetToolTip(button1, "Test phrase");
            toolTip1.IsBalloon = true;

            label2.Text = "Enter the radius";
            textBox1.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Single R;
            var isCypher = Single.TryParse(textBox1.Text,System.Globalization.NumberStyles.Number,System.Globalization.NumberFormatInfo.CurrentInfo,out R);
            if (isCypher == false)
            {
                MessageBox.Show("Вводите цифры!!!");
            }
            var beta = 2 * Math.PI * R;
            MessageBox.Show(String.Format("Длина окружности {0} = {1:F4}",Convert.ToChar(0x3B2),beta),"Греческая буква");

        }
    }
}
