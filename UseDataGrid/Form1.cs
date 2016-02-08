using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseDataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Формирование таблицы";
            String[] Names =
            {
                "Andrew - work", "Bob - pizza", "Alice",
                "George", "JamesBond", "Ann", "Tomhardware", "Orta"
            };
            String[] Phones =
            {
                "(555)123789", "4589775", "48738979324",
                "(8552)3-10-45", "123", "456", "234424", "232333"
            };
            var Table = new DataTable();
            Table.Columns.Add("NAMES");
            Table.Columns.Add("PHONES");
            for (int i = 0; i <= 8; i++)
            {
                Table.Rows.Add(Names[i], Phones[i]);
            }
            dataGridView1.DataSource = Table;
        }
    }
}
