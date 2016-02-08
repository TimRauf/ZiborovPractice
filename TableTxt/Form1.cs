using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string NL = "\r\n";
            this.ClientSize = new Size(438, 272);
            this.textBox1.Size = new Size(415, 229);
            this.Text = "ФОрмирование основной таблицы";
            string[] Names = {"Андрей-раб", "Света-Х", "ЖЭК", "Справка по тел", "Алек Степанович",
                "Мама - дом", "Карапузова Таня", "Театр"};
            string[] Tel = { "2-22-45", "2-54-89", "2-65-89", "2-54-77", "2-10-90", "112", "900", "4-78998787" };
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Font = new Font("Courier New", 9.0F);
            textBox1.Text = "Таблица Телефонов" + NL + NL;
            var i = 0;
            foreach (var Name in Names)
            {
                textBox1.Text += String.Format("{0, -21} {1, -21}" + NL, Name, Tel[i]);
                i += 1;
            }
            textBox1.Text += NL + "Примечание:" + NL + "для корректного отображения таблицы" +
                NL + "в Блокноте укажите шрифт Courier New";
            var writer = new System.IO.StreamWriter(@"C:\Temp\TestTable.txt", false, System.Text.Encoding.GetEncoding(1251));
            writer.Write(textBox1.Text);
            writer.Close();
        }

        private void показатьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Notepad", @"C:\Temp\TestTable.txt");
            }
            catch (Exception sit)
            {
                MessageBox.Show(sit.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
