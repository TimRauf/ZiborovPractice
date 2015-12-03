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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Произошло событие \"щелчок на первой кнопке\"");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //button1.PerformClick();
            //button1_Click(null, null);
            button1_Click(button1, EventArgs.Empty);

        }
    }
}

