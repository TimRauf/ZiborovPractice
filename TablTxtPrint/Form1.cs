using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablTxtPrint
{
    public partial class Form1 : Form
    {
        System.IO.StringReader Reader; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string NL = "\r\n";
            this.Text = "Формирование таблицы";
            double[] X =
            {
                5342736.17653, 2345.3333, 234683.853749,
                2438454.825368, 3425.72564, 5243.25,
                537407.6236, 6354328.9876, 5342.243
            };
            double[] Y =
            {
               27488.17, 3806703.356, 22345.72,
               54285.34, 2236767.3267, 57038.76,
               201722.3, 26434.001, 2164.022
            };
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Font = new Font("Courier New", 9.0F);
            textBox1.Text = "Каталог Координат" + NL;
            textBox1.Text += "------------------------------------" + NL;
            textBox1.Text += "|Пункт|     X      |       Y       |" + NL;
            textBox1.Text += "------------------------------------" + NL;
            for (int i = 0; i < 8; i++)
            {
                textBox1.Text += string.Format("| {0,3:D} |  {1,10:F2}|     {2,10:F2}|", i, X[i], Y[i]) + NL;
                textBox1.Text += "------------------------------------" + NL;
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                try
                {
                    printDocument1.Print();
                }
                finally 
                {
                    Reader.Close();                    
                }
            }
            catch (Exception sit)
            {
                MessageBox.Show(sit.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
