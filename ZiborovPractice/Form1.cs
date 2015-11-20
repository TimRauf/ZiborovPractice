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
            this.Text = "Test the ToolTip";
            label1.Text = "Test test";
            button1.Text = "Testing...";
            toolTip1.SetToolTip(button1, "Test phrase");
            toolTip1.IsBalloon = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
        }
    }
}
