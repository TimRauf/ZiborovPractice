using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablIntoHtml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Таблица в формате HTML";
            String[] Names =
            {
                "Андрей - раб", "Света-Х", "ЖЭК",
                "Справка по тел", "Александр Степанович", "Мама - дом",
                "Карапузова Таня", "погода сегодня", "Театр Браво" };
            String[] Phones =
            {
                "274-88-17", "+38(962)55555", "23-56-89",
                "002", "12-78-987", "(951)56489865",
                "4566698", "(8552)23-87-98", "(8552)91-91-91"
            };
            var text = "<title>Пример таблицы</title>" +
                       "<table border><caption>" +
                       "Таблица телефонов</caption>" + "\r\n";
            for (int i = 0; i <= 8; i++)
            {
                text += String.Format("<tr><td>{0}<td>{1}", Names[i], Phones[i]) + "\r\n";
            }
            text = text + "</table>";
            var Writer = new System.IO.StreamWriter(@"C:\Temp\tabl_tel1.doc", false, System.Text.Encoding.GetEncoding(1251));
            try
            {
                System.Diagnostics.Process.Start("WinWord", @"C:\Temp\tabl_tel1.doc");

            }
            catch (Exception situat)
            {
                MessageBox.Show(situat.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
