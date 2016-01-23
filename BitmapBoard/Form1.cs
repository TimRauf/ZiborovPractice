using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Содержимое буфера обмена:";
            button1.Text = "извлечь из БО:";
            pictureBox1.Size = new Size(184, 142);
            try
            {
                pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\test.png");
            }
            catch (System.IO.FileNotFoundException err)
            {
                MessageBox.Show("Нет такого файла!\n" + err.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                button1.Enabled = false;
                return;
            }
            Clipboard.SetDataObject(pictureBox1.Image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var receiver = Clipboard.GetDataObject();
            Bitmap Rastr;
            if (receiver.GetDataPresent(DataFormats.Bitmap) == true)
            {
                Rastr = (Bitmap) receiver.GetData(DataFormats.Bitmap);
                pictureBox1.Image = Rastr;
            }
        }
    }
}
