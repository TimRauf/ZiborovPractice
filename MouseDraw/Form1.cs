using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseDraw
{
    public partial class Form1 : Form
    {
        Boolean IsCanDraw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Рисую мышью в форме";
            button1.Text = "Стереть";
            IsCanDraw = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            IsCanDraw = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            IsCanDraw = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCanDraw == true)
            {
                var Grafika = CreateGraphics();
                Grafika.FillRectangle(new SolidBrush(Color.Azure), e.X, e.Y, 10, 10);
                Grafika.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Grafika = CreateGraphics();
            Grafika.Clear(this.BackColor);
        }
    }
}
