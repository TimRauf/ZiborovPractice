using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedTables
{
    public partial class Form1 : Form
    {
        Boolean ShowCust;
        DataSet DataP;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Switch tables";
            this.Text = "Linked Tables";
            var Table = new DataTable("Custs");
            var Column = new DataColumn("Name");
            Column.ReadOnly = true;
            Column.Unique = true;
            Table.Columns.Add(Column);
            Table.Columns.Add("Contact");
            Table.Columns.Add("Telephone");
            DataP = new DataSet();
            DataP.Tables.Add(Table);
            Table.Rows.Add("НИИАСС", "Погребицкий Олег", "095 456 456");
            Table.Rows.Add("КНУБА", "Юрий Александрович", "927 456 123456");
            Table.Rows.Add("МИИГАИК", "Стороженко Светалана", "4567877878");
            Table = new DataTable("Orders");
            var Column1 = new DataColumn("Order number");
            Column1.DataType = Type.GetType("System.Int32");
            Column1.ReadOnly = true;
            Column1.Unique = true;
            Table.Columns.Add(Column1);
            Table.Columns.Add("Order Value");
            Table.Columns.Add("Customer");
            
            DataP.Tables.Add(Table);
            Table.Rows.Add(1, "230000","НИИАСС");
            Table.Rows.Add(2, "178900", "КНУБА");
            Table.Rows.Add(3, "300000", "НИИАСС");
            Table.Rows.Add(4, "345000", "МИИГАИК");
            Table.Rows.Add(5, "308000", "КНУБА");

            var Parent = DataP.Tables["Custs"].Columns["Name"];
            var Child = DataP.Tables["Orders"].Columns["Customer"];
            var Link = new DataRelation("Order links", Parent, Child);
            DataP.Tables["Orders"].ParentRelations.Add(Link);

            dataGrid1.SetDataBinding(DataP, "Custs");
            dataGrid1.CaptionText = "Parent table \"Custs\"";
            dataGrid1.CaptionFont = new Font("Consolas", 11);

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowCust = !ShowCust;
            if (ShowCust==true)
            {
                dataGrid1.SetDataBinding(DataP, "Custs");
                dataGrid1.CaptionText = "Parent table \"Custs\"";
            }
            else
            {
                dataGrid1.SetDataBinding(DataP, "Orders");
                dataGrid1.CaptionText = "Child table \"Orders\"";
            }
        }
    }
}
