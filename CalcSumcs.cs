using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tutorial.SqlConn;


namespace DiaryOfaNailMaster
{
    public partial class CalcSums : Form
    {
        public CalcSums()
        {
            InitializeComponent();
            
        }

        //внутри группировать по шаблону => вместо трех строк одинаковых написала бы "Услуга 100 рублей х 15 раз = 1500 рублей

        private void culcBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            OleDbConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();

                List<string[]> data = new List<string[]>();

                string d = Mounth_comBox.SelectedIndex + 1 + "." + Year_numUpDown.Value;

                string sql = $"SELECT SUM(s.s_price) AS SumPrice,s.s_name,v.v_date " +
                    $"FROM Service s " +
                    $"INNER JOIN Visit v ON s.s_id=v.s_id " +
                    $"WHERE v.v_date LIKE '%{d}%' " +
                    $"GROUP BY s.s_name,v.v_date " +
                    $"ORDER BY s.s_name ";

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    data.Add(new string[2]);
                    data[data.Count - 1][0] = r[0].ToString();
                    data[data.Count - 1][1] = r[1].ToString();
                }
                r.Close();

                foreach (string[] s in data)
                {
                    richTextBox1.Text += s[1] + " : " + s[0] + " руб.\n";
                }
                double sum = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    sum += Convert.ToDouble(data[i][0]);
                }
                richTextBox1.Text += "Итого: " + sum + " руб.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
                    conn.Close();
            
        }

        private void CalcSums_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }
    }
}
