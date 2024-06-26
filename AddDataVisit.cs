using Dapper;
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

        private void GetClient()
        {
            try
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();

                Client_comBox.Items.Clear();
             string   sql = $"SELECT cl_id AS {nameof(Client.IdClient)}," +
                 $"cl_fname AS {nameof(Client.FnameClient)}," +
                 $"cl_name AS {nameof(Client.NameClient)} " +
                 $"FROM Client";
                var client = conn.Query<Client>(sql);
                foreach (Client c in client)
                {
                    Client_comBox.Items.Add(c.IdClient + " " + c.FnameClient + " " + c.NameClient);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetMaster()
        {
            try
            {
                Master_comBox.Items.Clear();

                conn = DBUtils.GetDBConnection();

                conn.Open();

                string sql = $"SELECT m_id AS {nameof(Master.IdMaster)}," +
               $"m_fname AS {nameof(Master.FnameMaster)}," +
               $"m_name AS {nameof(Master.NameMaster)} " +
               $"FROM Master";
                var master = conn.Query<Master>(sql);
                foreach (Master m in master)
                {
                    Master_comBox.Items.Add(m.IdMaster + " " + m.FnameMaster + " " + m.NameMaster);
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetSer()
            {
            try
            {
                conn=DBUtils.GetDBConnection();

                conn.Open();

                Service_comBox.Items.Clear();
               
               
           string sql = $"SELECT s_id AS {nameof(Service.IdService)}," +
                  $"s_name AS {nameof(Service.NameService)}," +
                  $"s_price AS {nameof(Service.PriceService)} " +
                  $"FROM Service";
                var service = conn.Query<Service>(sql);
                foreach (Service s in service)
                {
                    Service_comBox.Items.Add(s.IdService + " " + s.NameService+ " " + s.PriceService);
                }
                conn.Close();

            }
            catch (Exception ex) {

                MessageBox.Show(ex.ToString());
            }
        }

        private void AddData()
        {
            try
            {
                if (Master_comBox.SelectedIndex < 0  || Client_comBox.SelectedIndex < 0 || LastingService_txtBox.Text == "" || 
                    LastingService_txtBox.Text == " " || Day_dateTimePicker.Value == null || Time_dateTimePicker == null)
                {
                    MessageBox.Show("Проверьте введенные данные");
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
               
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
           
        }

        private void AddDataVisit_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Day_dateTimePicker.Value.ToShortDateString();
            Time_dateTimePicker.ShowUpDown = true;

            DateTime dt = DateTime.Now;
            Time_dateTimePicker.Value = dt;

            //Time_dateTimePicker.Format = DateTimePickerFormat.Time;

            //Time_dateTimePicker.CustomFormat = "HH:MM";
            //Time_dateTimePicker.Format = DateTimePickerFormat.Custom;

            GetSer();
            GetMaster();
            GetClient();

        }

        private void Insert_btn_Click_1(object sender, EventArgs e)
        {
            AddData();
        }

        private void AddDataVisit_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}
