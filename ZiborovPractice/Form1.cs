using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZiborovPractice
{
    public partial class Form1 : Form
    {
        string fName;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new System.IO.StreamReader(fName);
                textBox1.Text = reader.ReadToEnd();
                reader.Close();

            }
            catch (System.IO.FileNotFoundException situate)
            {
                MessageBox.Show(situate.Message + "\n" + "Нет такого файла", "ОШибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //throw;
            }
            catch (Exception situate)
            {
                MessageBox.Show(situate.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var writer = new System.IO.StreamWriter(fName, false);
                writer.Write(textBox1.Text);
                //writer.Close();
                System.IO.File.WriteAllText(@"C:\Temp\11.txt", textBox1.Text);
            }
            catch (Exception situate)
            {
                MessageBox.Show(situate.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true; textBox1.Clear();
            button1.Text = "Open"; button1.TabIndex = 0;
            button2.Text = "Save";
            this.Text = "Unicode here";
            fName = @"C:\Temp\11.txt";
        }
    }
}

