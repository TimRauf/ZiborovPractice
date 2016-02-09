using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputDatatable
{
    public partial class Form1 : Form
    {
        DataTable DTable;
        DataSet Dset;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Почти табличный редактор";
            button1.Text = "Запись";
            DTable = new DataTable();
            Dset = new DataSet();
            if (System.IO.File.Exists(@"C:\Temp\tabl.xml")==true)
            {
                Dset.ReadXml(@"C:\Temp\tabl.xml");
                var strXML = Dset.GetXml();
                dataGridView1.DataMember = "Название таблицы";
                dataGridView1.DataSource = Dset;
            }
            else
            {
                dataGridView1.DataSource = DTable;
                DTable.Columns.Add("ИМЕНА");
                DTable.Columns.Add("ТЕЛЕФОНЫ");
                Dset.Tables.Add(DTable);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTable.TableName = "Название таблицы";
            Dset.WriteXml(@"C:\Temp\tabl.xml");
        }
    }
}
