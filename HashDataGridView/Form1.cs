using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace HashDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Пример hash-таблицы";
            var Hashtab = new Hashtable();
            Hashtab["Украина"] = "Киев";
            Hashtab.Add("Россия", "Москва");
            Hashtab.Add("Казахстан","Астана");
            var Table = new DataTable();
            Table.Columns.Add("Государства");
            Table.Columns.Add("Столицы");
            foreach (DictionaryEntry onePair in Hashtab)
            {
                Table.Rows.Add(onePair.Key, onePair.Value);
            }
            dataGridView1.DataSource = Table;
        }
    }
}
