using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ConsoleApplication1
{
    public partial class Form1 : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private Perceptron p = new Perceptron();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1postgres;Database=Labs;";
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "SELECT * FROM lab1";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                int i = 0;
                foreach (DataRow row in dt.Rows) {
                    for(int j = 0; j<3; j++)
                    {
                        int z;
                        z = j+1;
                        p.x[i, j] = Convert.ToInt32(row[Convert.ToString("x"+z)]);
                    }
                    i++;
                }
                dt.Reset();
                conn.Close();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Columns.Add("w1");
            dt.Columns.Add("w2");
            dt.Columns.Add("w3");
            dt.Columns.Add("teta");
            dt.Columns.Add("rate");
            dt.Columns.Add("x1");
            dt.Columns.Add("x2");
            dt.Columns.Add("x3");
            dt.Columns.Add("a");
            dt.Columns.Add("out");
            dt.Columns.Add("true result");
            dt.Columns.Add("delta1");
            dt.Columns.Add("delta2");
            dt.Columns.Add("delta3");
            dt.Columns.Add("sigma");


            bool finish;
           
            do
            {
                finish = false;
                
            for (int i = 0; i<8; i++)
            {
                p.activation(i);
                p.study(i);

                DataRow row = dt.NewRow();
                row["w1"] = p.weights[0];
                row["w2"] = p.weights[1];
                row["w3"] = p.weights[2];
                row["teta"] = Perceptron.teta;
                row["rate"] = Perceptron.rate;
                row["x1"] = p.x[i, 0];
                row["x2"] = p.x[i, 1];
                row["x3"] = p.x[i, 2];
                row["a"] = p.a;
                row["out"] = p.out1;
                row["true result"] = p.true_result;
                row["delta1"] = p.delta[0];
                row["delta2"] = p.delta[1];
                row["delta3"] = p.delta[2];
                row["sigma"] = p.sigma[i];
                dt.Rows.Add(row);
            }
                DataRow row1 = dt.NewRow();
                dt.Rows.Add(row1);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < p.sigma.Length; i++)
            {
               if (p.sigma[i] != 0)
                 {
                     finish = true;
                     break;
                 }
                 else continue;
             }
           } while (finish);
        }
    }
}
