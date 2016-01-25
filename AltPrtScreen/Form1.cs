using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltPrtScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "имитация нажатия на альт + принт скрин";
            button1.Text = "методом Send класса Sendkeys";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("%{PRTSC}");
        }
    }
}
