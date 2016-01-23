using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyBoardTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Работа с буфером обмена";
            textBox1.Clear();
            textBox2.Clear();
            textBox1.TabIndex = 0;
            button1.Text = "Write to copyboard";
            button2.Text = "Paste from copyboard";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != String.Empty)
            {
                Clipboard.SetDataObject(textBox1.SelectedText);
                textBox2.Text = String.Empty;

            }
            else
            {
                textBox2.Text = "В верхнем поле текст не выделен";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var receiver = Clipboard.GetDataObject();
            if (receiver.GetDataPresent(DataFormats.Text) == true)
            {
                textBox2.Text = receiver.GetData(DataFormats.Text).ToString();

            }
            else textBox2.Text = "Нет в буфере текстового формата";
        }
    }
}
