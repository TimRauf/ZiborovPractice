using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZiborovPractice
{
    public partial class Form1 : Form
    {
        string[] Months;
        int[] Sales;
        Graphics Grafika;
        Bitmap Rastr;
        int OtLeft, OtRight, OtDown, OtUp;
        int OYLen, OXLen, OXy, Xmax, XBegEpur;

        

        Double HorStep;
        int VertStep;
        int i;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs ae)
        {
            Months = new string[] { "Янв", "Фев", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Сен", "Окт", "Ноя", "Дек" };
            Sales = new int[] { 335, 414, 572, 629, 750, 931, 753, 599, 422, 301, 245, 155 };
            OtLeft = 35; OtRight = 15; OtDown = 20; OtUp = 10;
            this.Text = "Построение графика";
            button1.Text = "Нарисовать график";
            this.ClientSize = new Size(593, 319);
            pictureBox1.Size = new Size(569, 242);
            Rastr = new Bitmap(pictureBox1.Width,
                pictureBox1.Height,
                pictureBox1.CreateGraphics());
            //pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            OXy = pictureBox1.Height - OtDown;
            Xmax = pictureBox1.Width - OtRight;
            OXLen = pictureBox1.Width - (OtLeft + OtRight);
            OYLen = OXy - OtUp;
            HorStep = Convert.ToDouble(OXLen / Sales.Length);
            VertStep = Convert.ToInt32(OYLen / 10);
            XBegEpur = OtLeft + 30;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Grafika = Graphics.FromImage(Rastr);
            DrawAxes();
            DrawHorizLines();
            DrawVertLines();
            DrawEpur();
            pictureBox1.Image = Rastr;
            Grafika.Dispose();
         }
        void DrawAxes()
        {
            var DrawPen = new Pen(Color.Black, 2);
            Grafika.DrawLine(DrawPen, OtLeft, OXy, OtLeft, OtUp);
            Grafika.DrawLine(DrawPen, OtLeft, OXy, Xmax, OXy);
            var Type = new Font("Arial", 8);
            for (this.i = 1; i < 10; i++)
            {
                int Y = OXy - i * VertStep;
                Grafika.DrawLine(DrawPen, OtLeft - 4, Y , OtLeft, Y);
                Grafika.DrawString((i*100).ToString(), Type, Brushes.Black, 0 , Y - 5);

            }
            for (this.i = 0; i < Months.Length - 1; i++)
            {
                Grafika.DrawString(Months[i], Type, Brushes.Black, (int)(OtLeft + 18 + i * HorStep), (OXy + 4));
            }

        }
        void DrawHorizLines()
        {
            var ThinPen = new Pen(Color.LightGray, 1);
            for (this.i = 1; i <= 10; i++)
            {
                int Y = OXy - VertStep * i;
                Grafika.DrawLine(ThinPen, OtLeft + 3, Y, Xmax, Y);

            }
            ThinPen.Dispose();
        }
        void DrawVertLines()
        {
            var ThinPen = new Pen(Color.Bisque, 1);
            for (this.i = 0; i <= Months.Length - 1; i++)
            {
                int X = XBegEpur + Convert.ToInt32(HorStep * i);
                Grafika.DrawLine(ThinPen, X, OtUp, X, OXy - 4);
            }
            ThinPen.Dispose();
        }
        void DrawEpur()
        {
            var VertScale = Convert.ToDouble(OYLen / 1000.0);
            var Y = new int[Sales.Length];
            var X = new int[Sales.Length];
            for (this.i = 0; this.i <= Sales.Length - 1; this.i++)
            {
                Y[i] = OXy - Convert.ToInt32(Sales[i] * VertScale);
                X[i] = XBegEpur + Convert.ToInt32(HorStep * i);
            }
            var Penn = new Pen(Color.Blue, 3);
            Grafika.DrawEllipse(Penn, X[0] - 2, Y[0] - 2, 4, 4);
            for (this.i = 0; this.i <= Sales.Length - 2; this.i++)
            {
                Grafika.DrawLine(Penn, X[i], Y[i], X[i + 1], Y[i + 1]);
                Grafika.DrawEllipse(Penn, X[i + 1] - 2, Y[i + 1] - 2, 4, 4);
            }
        }
    }
}

