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
            Months = new string[] { "Янв", "Фев", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            Sales = new int[] { 335, 414,572,629,750,931,753,599,422,301,245,155};
            OtLeft = 35; OtRight = 15; OtDown = 20; OtUp = 10;
            this.Text = "График";
            button1.Text
             

    }
}

