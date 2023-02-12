using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsAppbt2
{
    public partial class Form1 : Form
    {
        int ban = 0;
        DataTable[] dt = new DataTable[4];
        string path = @"D:\ki4\dotnet\text2.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt[0] = new DataTable();
            dt[1] = new DataTable();
            dt[2] = new DataTable();
            dt[3] = new DataTable();
            dt[0].Columns.Add("Mon an");
            dt[0].Columns.Add("So luong");
            dt[1].Columns.Add("Mon an");
            dt[1].Columns.Add("So luong");
            dt[2].Columns.Add("Mon an");
            dt[2].Columns.Add("So luong");
            dt[3].Columns.Add("Mon an");
            dt[3].Columns.Add("So luong");
            dt[0].Columns[1].DataType = typeof(int);
            dt[1].Columns[1].DataType = typeof(int);
            dt[2].Columns[1].DataType = typeof(int);
            dt[3].Columns[1].DataType = typeof(int);
        }

        private void dsban_SelectedIndexChanged(object sender, EventArgs e)
        {
            ban = (int)dsban.SelectedIndex + 1;
            dataGridView1.DataSource = dt[ban - 1];
            dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 0.42);
            dataGridView1.Columns[1].Width = (int)(dataGridView1.Width * 0.5);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        
        private void button4_Click(object sender, EventArgs e)
        {
            if (ban == 0)
            {
                MessageBox.Show("Vui long chon ten ban truoc.");
            }
            else
            {
                Button b = (Button)sender;
                int ok = 0;
                for (int i = 0; i < dt[ban - 1].Rows.Count; i++)
                {
                    //MessageBox.Show(dt[ban - 1].Rows[i + 1][1].ToString());
                    if (b.Text.Equals(dt[ban - 1].Rows[i][0].ToString()))
                    {
                        
                        dt[ban - 1].Rows[i][1] = (int)dt[ban - 1].Rows[i][1] + 1;
                        ok = 1;
                    };
                }
                if (ok == 0)
                {
                    DataRow row;
                    row = dt[ban - 1].NewRow();
                    row[0] = b.Text;
                    row[1] = 1;
                    dt[ban - 1].Rows.Add(row);
                    
                }
                /*dataGridView1.DataSource = dt[ban - 1];
                dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 0.42);
                dataGridView1.Columns[1].Width = (int)(dataGridView1.Width * 0.5);*/
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (ban == 0)
            {
                MessageBox.Show("Vui long chon ten ban truoc.");
            }
            else
            {
                dt[ban - 1].Rows.Clear();
                /*dataGridView1.DataSource = dt[ban - 1];
                dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 0.42);
                dataGridView1.Columns[1].Width = (int)(dataGridView1.Width * 0.5);*/
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (ban == 0)
            {
                MessageBox.Show("Vui long chon ten ban truoc.");
            }
            else
            {
                Button button = (Button)sender;
                using (StreamWriter sw = File.AppendText(path))
                {
                    DateTime date = DateTime.Now;
                    sw.WriteLine("\t Ban " + ban + " : " + date + "\n");
                    for (int i = 0; i < dt[ban - 1].Rows.Count; i++)
                    {
                        sw.WriteLine(dt[ban - 1].Rows[i][0] + "\t" + dt[ban - 1].Rows[i][1] + "\n");
                    }
                    sw.Close();
                };
                MessageBox.Show("Da duoc dat.");
            }
        }
    }
}