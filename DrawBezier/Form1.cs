using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawBezier
{
    public partial class Form1 : Form
    {
        private PointF[] PointArray;
        private Boolean Manage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Manage = false;
            this.Text = "Управление сплайном Безье";
            var p0 = new PointF(50, 50);
            var p1 = new PointF(125, 125);
            var p2 = new PointF(125, 125);
            var p3 = new PointF(200.0F, 200.0F);
            PointArray = new PointF[] {p0, p1, p2, p3};

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var Grafika = e.Graphics;
            var Pen = new Pen(Color.Blue, 3);
            Grafika.DrawEllipse(Pen, PointArray[0].X - 2, PointArray[0].Y - 2, 4.0F, 4.0F);
            Grafika.DrawEllipse(Pen, PointArray[3].X - 2, PointArray[3].Y - 2, 4.0F, 4.0F );
            Pen.Color = Color.Red;
            Grafika.DrawRectangle(Pen, PointArray[1].X-2, PointArray[1].Y-2, 4.0F,4.0F);
            Pen.Color = Color.Blue;
            Grafika.DrawBeziers(Pen, PointArray);
            Grafika.Dispose();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Math.Abs(e.X - PointArray[1].X) < 4.0F &&
                Math.Abs(e.Y - PointArray[1].Y) < 4.0F && Manage == true)
            {
                PointArray[1].X = e.X;
                PointArray[1].Y = e.Y;
                PointArray[2].X = e.X;
                PointArray[2].Y = e.Y;
                this.Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Manage = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Manage = true;
        }
    }
}
