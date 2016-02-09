using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SLAU
{
    public partial class Form1 : Form
    {
        int n;
        DataTable DTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Решение системы уравнений";
            textBox1.TabIndex = 0;
            dataGridView1.Visible = false;
            label1.Text = "Введите количество неизвестных";
            button1.Text = "Ввести";
            DTable = new DataTable();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;
            Double[,] A;
            Double[] L;
            var isNum = false;
            var tmp = "временная рабочая переменная";
            if (button1.Text == "Ввести")
            
                for (; ; )
                {
                    isNum = int.TryParse(textBox1.Text, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out n);
                    if (isNum == false) return;
                    button1.Text = "Решить";
                    textBox1.Enabled = false;
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = DTable;
                    for (i = 1; i <= n; i++)
                    {
                        tmp = "X" + Convert.ToString(i);
                        DTable.Columns.Add(new DataColumn(tmp));
                    }
                    DTable.Columns.Add(new DataColumn("L"));
                    return;
                }
            else
            {
               if (DTable.Rows.Count != 1)
               {
                    MessageBox.Show("Количество строк не равно количеству колонок!");
                    return;
               }
                A = new Double[n, n];
                L = new Double[n];
                for (j = 0; j <= n - 1; j++)
                {
                    for (i = 0; i <= n - 1; i++)
                    {
                        A[j, i] = getNum(j, i, ref isNum);
                        if (isNum == false) return;
                    }
                }

            }
            gauss(n, A, ref L);
            var s = "Неизвестные равны:\n";
            for (j = 1; j < n; j++)
            {
                tmp = L[j - 1].ToString();
                s = s + "X" + j.ToString() + " = " + tmp + ";\n";
            }
            MessageBox.Show(s);
            }
        Double getNum(int j, int i, ref Boolean isNum)
        {
            double rab;
            var tmp = DTable.Rows[j][i].ToString();
            isNum = Double.TryParse(tmp, NumberStyles.Number, NumberFormatInfo.CurrentInfo, out rab);
            if (isNum == false)
            {
                tmp = String.Format("Номер тсроки {0}, номер столбца " + "{1}," + "\n в данном поле-не число", j + 1, i + 1);
                MessageBox.Show(tmp);
            }
            return rab;
        }
        void gauss(int n, double[,] A, ref double[] LL)
        {
            int i, j, l = 0;
            double c1, c2, c3;
            for (i = 0; i <= n - 1; i++)
            {
                c1 = 0;
                for (j = 0; j <= n - 1; j++)
                {
                    c2 = A[j, i];
                    if (Math.Abs(c2)>Math.Abs(c1))
                    {
                        l = j; c1 = c2;
                    }
                }
                for (j = i; j <= n - 1; j++)
                {
                    c3 = A[l, j] / c1;
                    A[l, j] = A[i, j];
                    A[i, j] = c3;
                }
                c3 = LL[l] / c1;
                LL[l] = LL[i]; LL[i] = c3;
                for (j = 0; j <= n - 1; j++)
                {
                    if (j == i) continue;
                    for (l = i + 1; l <= n - 1; l++)
                    {
                        A[j, l] = A[j, l] - A[i, l] * A[j, i];
                    }
                    LL[j] = LL[j] - LL[i] * A[j, i];
                }
            }
        }
        }
    }

