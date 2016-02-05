using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot5Second
{
    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            i = 0;
            this.Text = "Запись каждые 5 секунд в файл";
            button1.Text = "Пуск";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i +=1;
            this.Text = String.Format("Прошло {0} секунд", i);
            if (i>=28)
            {
                timer1.Enabled = false; this.Close();

            }
            Single mod = i % 5;
            if (mod != 0) return;
            SendKeys.Send("%{PRTSC}");
            var receiver = Clipboard.GetDataObject();
            if (receiver.GetDataPresent(DataFormats.Bitmap) == true)
            {
                var obj = receiver.GetData(DataFormats.Bitmap);
                var rastr = (Bitmap)obj;
                var FileName = String.Format(@"C:\Temp\Pic{0}.bmp", i / 5);
                rastr.Save(FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = String.Format("Прошло 0 секунд");
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
    }
}
