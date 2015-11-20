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
            this.Text = "Улыбка";
            var tabPage3 = new TabPage();
            tabPage3.UseVisualStyleBackColor = true;
            this.tabControl1.Controls.Add(tabPage3);
            this.radioButton5.Location = new Point(20,15);
            this.radioButton6.Location = new Point(20, 38);
            tabControl1.TabPages[0].Text = "Text";
            tabControl1.TabPages[1].Text = "Color";
            tabControl1.TabPages[2].Text = "Size";
            radioButton1.Text = "1";
            radioButton2.Text = "2";
            radioButton3.Text = "3";
            radioButton4.Text = "4";
            radioButton5.Text = "5";
            radioButton6.Text = "6";
            label1.Text = radioButton1.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton2.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton4.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton3.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton5.Text;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton6.Text;
        }
    }
}
