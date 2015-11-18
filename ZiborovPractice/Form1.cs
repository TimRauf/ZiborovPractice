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

        private void label1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Done it!\nGreat!!!");
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
