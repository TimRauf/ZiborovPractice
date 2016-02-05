using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveIntoBMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Save the clipboard copy into BMP";
            button1.Text = "SAVE";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var receiver = Clipboard.GetDataObject();
            Bitmap Rastr;
            if (receiver.GetDataPresent(DataFormats.Bitmap) == true)
            {
                var obj = receiver.GetData(DataFormats.Bitmap);
                Rastr = (Bitmap) obj;
                Rastr.Save(@"C:\Temp\Clip.bmp");
                MessageBox.Show(@"Изображение из буфера записано в D:\Clip.bmp", "Успех");

            }
            else MessageBox.Show("В буфере нет данных в формате битмап", "Запишите в него что-нибудь");
            {
                
            }
        }
    }
}
