﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZiborovPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*private void label1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Done it!\nGreat!!!!");
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Enter your password";
            textBox1.Text = String.Empty;
            textBox1.TabIndex = 0;
            textBox1.PasswordChar = '+';
            textBox1.Font = new Font("Calibri", 12.0F);
            label1.Text = String.Empty;
            label1.Font = new Font("Courier New", 14.0F);
            button1.Text = "Show your password";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Single X;
            bool isItCypher = Single.TryParse(textBox1.Text,System.Globalization.NumberStyles.Number,System.Globalization.NumberFormatInfo.CurrentInfo,out X);
            if (isItCypher == false)
            {
                return;
            }
            var Y = (Single)Math.Sqrt(X);*/
            label1.Text = textBox1.Text;
        }


    }
}
