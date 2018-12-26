using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            table.Columns.Add("프로젝트명", typeof(string));
            table.Columns.Add("수량", typeof(int));
            table.Columns.Add("단가", typeof(int));
            table.Columns.Add("금액", typeof(int));
            table.Columns.Add("부가세", typeof(int));
            table.Columns.Add("합계", typeof(int));

            this.SalesGV.DataSource = table;
        }

        private void SalesGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());
            int q = 0;
            int p = 0;

            for (int i = 0; i <= e.RowIndex; i++)
            {
                if (e.RowIndex >= 0)
                {
                    //수량
                    if ((string)SalesGV.Rows[i].Cells[1].Value.ToString() == "")
                    {
                        SalesGV.Rows[i].Cells[1].Value = 0;
                    }
                    else
                    {
                        p = Convert.ToInt32(SalesGV.Rows[i].Cells[1].Value);
                    }

                    //단가
                    if ((string)SalesGV.Rows[i].Cells[2].Value.ToString() == "")
                    {
                        SalesGV.Rows[i].Cells[2].Value = 0;
                    }
                    else
                    {
                        q = Convert.ToInt32(SalesGV.Rows[i].Cells[2].Value);
                    }

                    //금액
                    if ((string)SalesGV.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        SalesGV.Rows[i].Cells[3].Value =
                        0;
                    }
                    else
                    {
                        SalesGV.Rows[i].Cells[3].Value = q * p; // < --이 부분에서 StackOverflow (무한루프)
                    }

                    //SalesGV.Rows[i].Cells[3].Value = q * p;

                    //VAT
                    if ((string)SalesGV.Rows[i].Cells[4].Value.ToString() == "")
                    {
                        SalesGV.Rows[i].Cells[4].Value = 0;
                    }
                    else
                    {
                        SalesGV.Rows[i].Cells[4].Value = Convert.ToInt32(((q * p) * 1.1) - (q * p));
                    }
                    //SalesGV.Rows[i].Cells[4].Value = v;

                    //합계
                    if ((string)SalesGV.Rows[i].Cells[5].Value.ToString() == "")
                    {
                        SalesGV.Rows[i].Cells[5].Value = 0;
                    }
                    else
                    {
                        SalesGV.Rows[i].Cells[5].Value = Convert.ToInt32((q * p) * 1.1);
                    }
                    //SalesGV.Rows[i].Cells[5].Value = t;
                }
            }
        }
    }
}
