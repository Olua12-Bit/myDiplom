using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;

namespace DiaryOfaNailMaster
{
    public partial class AddDataVisit : Form
    {
        public AddDataVisit()
        {
            InitializeComponent();
         
        }

        private OleDbConnection conn;

        private void GetData()
            {
            try
            {
                Master_comBox.Items.Clear();
                Client_comBox.Items.Clear();
                Service_comBox.Items.Clear();
               
                List<string[]> data = new List<string[]>();
                
                string sql = $"SELECT DISTINCT cl.cl_id,cl.cl_fname,cl.cl_name, " +
             $"m.m_id,m.m_fname,m.m_name, " +
             $"s.s_id,s.s_name " +
             $"FROM Client cl INNER JOIN(Master m INNER JOIN(Service s INNER JOIN Visit v ON s.s_id = v.s_id) ON m.m_id = v.m_id) ON cl.cl_id = v.cl_id " +
             $"GROUP BY cl.cl_id,cl.cl_fname,cl.cl_name, " +
             $"m.m_id,m.m_fname,m.m_name, " +
             $"s.s_id,s.s_name ";

                conn = DBUtils.GetDBConnection();

                conn.Open();

                using (var cmd = new OleDbCommand(sql, conn))
                {
                    OleDbDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string[] d = new string[8];

                        for (int j = 0; j < d.Length; j++)
                        {
                            d[j] = rdr[j].ToString();
                        }
                        
                        //Client_comBox.Items.Add(rdr[0] + " " + rdr[1] + " " + rdr[2]);
                        //Master_comBox.Items.Add(rdr[3] + " " + rdr[4] + " " + rdr[5]);
                        //Service_comBox.Items.Add(rdr[6] + " " + rdr[7]);

                        data.Add(d);

                    }
                        rdr.Close();
                }
                foreach (string[] s in data)
                {
                    Client_comBox.Items.Add(s[0] + " " + s[1] + " " + s[2]);
                    Master_comBox.Items.Add(s[3] + " " + s[4] + " " + s[5]);
                    Service_comBox.Items.Add(s[6] + " " + s[7]);
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.ToString());
            }
            
           
        }
        private void AddData()
        {
            try
            {
                if (Master_comBox.SelectedIndex < 0  || Client_comBox.SelectedIndex < 0 || LastingService_txtBox.Text == "" || LastingService_txtBox.Text == " " || Day_dateTimePicker.Value == null || Time_dateTimePicker == null)
                {
                    MessageBox.Show("Проверьте выбранные и введенные данные");
                }
                else
                    {

                    string m_id = Master_comBox.SelectedItem.ToString().Remove(Master_comBox.SelectedItem.ToString().IndexOf(" "));
                    string cl_id = Client_comBox.SelectedItem.ToString().Remove(Client_comBox.SelectedItem.ToString().IndexOf(" "));
                    string s_id = Service_comBox.SelectedItem.ToString().Remove(Service_comBox.SelectedItem.ToString().IndexOf(" "));

                    string sql = $"INSERT INTO Visit(m_id,cl_id,s_id,s_time,v_date,v_time,v_status)" +
                    $"VALUES('" + m_id + "'," +
                    $"'" + cl_id + "'," +
                    $"'" + s_id + "'," +
                    $"'" + LastingService_txtBox.Text + "'," +
                    $"'" + Day_dateTimePicker.Value.ToShortDateString() + "'," +
                   $"'" + Time_dateTimePicker.Value.ToLongTimeString() + "'," +
                    $"'Услуга принята')";

                    conn = DBUtils.GetDBConnection();

                    conn.Open();

                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные добавлены!");
                    }

                }
                GetData();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
           
        }

        private void AddDataVisit_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            Day_dateTimePicker.Value.ToShortDateString();
            Time_dateTimePicker.ShowUpDown = true;

            DateTime dt = DateTime.Now;
            Time_dateTimePicker.Value = dt;

            Time_dateTimePicker.Format = DateTimePickerFormat.Time;


            //Time_dateTimePicker.CustomFormat = "HH:MM";
            //Time_dateTimePicker.Format = DateTimePickerFormat.Custom;

            //DateTime res = dt.AddMilliseconds(-dt.Millisecond).AddSeconds(-dt.Second);

            //Time_dateTimePicker.Value = res;

            //Time_dateTimePicker.ToString().Remove(2).ToString();

            ////удаление времени после даты
            //d[0] = r[0].ToString().Remove(10);

            ////удаление даты перед временем
            //d[1] = r[1].ToString().Remove(0, 11).Remove(4, 3);


            label6.Font = new Font("Times New Roman", 14, FontStyle.Bold);
          
            GetData();

        }

        private void Insert_btn_Click_1(object sender, EventArgs e)
        {
            AddData();
        }

        private void Time_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //DateTimePicker datePicker = new DateTimePicker();
            //Time_dateTimePicker.MinDate = DateTime.Parse("00:00:00");

            //var max = new TimeSpan(23, 59, 22);
            //if (Time_dateTimePicker.Value.TimeOfDay >= max)
            //{
            //    Time_dateTimePicker.Value = Time_dateTimePicker.Value.Date + max;
            //}
        }

        private void AddDataVisit_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}
