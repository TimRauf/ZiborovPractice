using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ziborov2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true; textBox1.Clear();
            this.Text = "Simple text editor";
            openFileDialog1.FileName = @"C:\txttest.txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;

            try
            {
                var reader = new System.IO.StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
            }
            catch (System.IO.FileNotFoundException Exception)
            {
                MessageBox.Show(Exception.Message + "\nNo such file","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) WriteMode();
        }
        private void WriteMode()
        {
            try
            {
                var writer = new System.IO.StreamWriter(saveFileDialog1.FileName,false,System.Text.Encoding.GetEncoding(1251));
                writer.Write(textBox1.Text);
                writer.Close(); textBox1.Modified = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nNo such file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void выдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Modified == false) return;
            var mbox = MessageBox.Show("Text was modified " + "Save changes?","Simple editor",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation);
            if (mbox == DialogResult.No) return;
            if (mbox == DialogResult.Cancel) e.Cancel = true;
            if (mbox == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    WriteMode();
                    return;
                }
                else e.Cancel = true;
            }
        }
    }
}
