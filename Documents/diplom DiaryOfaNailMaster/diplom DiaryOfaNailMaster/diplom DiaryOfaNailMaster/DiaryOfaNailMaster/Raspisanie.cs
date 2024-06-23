using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//1. напоминание о скором приходе клиента
//2. изменить интерфейс журнала записей?


//вот в этьой программе с оповещениями можно вообще выводить список клиентов на текущий день.
//    а вот за сколько напоминать наверно должен выбирать
//    пользователь и считаешь что время записи минус за сколько оповещать - вот и время

//id записи хранить; расчитанное когда нужно оповещение сделать
//сравнить текущее время с временем напоминания => message =>асихронный метод


namespace DiaryOfaNailMaster
{

    public partial class Raspisanie : Form
    {
        public string st_id;
        public Raspisanie()
        {
            InitializeComponent();
            //conn = new OleDbConnection(connString);
                      
        }
        private OleDbConnection conn;
        //public static string connString = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=ManicureDB.mdb;Jet OLEDB:Database Password=1W=p_+4bMfs5-q*";
       
        private void Raspisanie_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            string[] st = new string[] { "Услуга принята","Услуга оказана","Услуга отменена"};
            foreach (string s in st) { Status_comBox.Items.Add(s); }
          
            //this.MaximizeBox = false;
           
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            //menuStrip1.Font = new Font("Times New Roman", 14, FontStyle.Bold);

            DataVisit_dtGridView.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            DataVisit_dtGridView.EnableHeadersVisualStyles = false;
            DataVisit_dtGridView.ColumnHeadersDefaultCellStyle.Font = new Font(DataVisit_dtGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 9f, FontStyle.Bold); //жирный курсив
            DataVisit_dtGridView.ReadOnly = true;
            DataVisit_dtGridView.ColumnHeadersDefaultCellStyle.Font = new Font(DataVisit_dtGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12f, FontStyle.Bold);
        }

        private void Raspisanie_FormClosing(object sender, FormClosingEventArgs e)
        {
            //conn.Close();
        }

      private void Data(DateTime date)
        {
            DataVisit_dtGridView.Columns.Clear();
            DataVisit_dtGridView.Rows.Clear();

            List<string> clm = new List<string>() { "Дата", "Время", "Мастер", "Клиент", "Услуга", "Статус посещения" };
            for (int i = 0; i < clm.Count; i++)
            {
                DataVisit_dtGridView.Columns.Add(Name, clm[i]);
            }
            try
            {
                conn = DBUtils.GetDBConnection();
                //запрос на объединение нескольких таблиц

                conn.Open();

                string sql = $"SELECT v.v_date,v.v_time,m.m_fname,m.m_name,cl.cl_fname,cl.cl_name,s.s_name,v.v_status " +
                   $"FROM Service s " +
                   $"INNER JOIN(Master m INNER JOIN(Client cl INNER JOIN Visit v ON cl.cl_id = v.cl_id) ON m.m_id = v.m_id) ON s.s_id = v.s_id " +
                   $"WHERE v.v_date=@DT " +
                   $"GROUP BY v.v_date,v.v_time,m.m_fname,m.m_name,cl.cl_fname,cl.cl_name,s.s_name,v.v_status";

                OleDbCommand cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.Add(new OleDbParameter("@DT", date.ToShortDateString()));

                List<string[]> data = new List<string[]>();

                OleDbDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    string[] d = new string[8];

                    for (int i = 0; i < d.Length; i++)
                    {
                        d[i] = r[i].ToString();
                    }
                    //удаление времени после даты
                    d[0] = r[0].ToString().Remove(10);

                    //удаление даты перед временем
                    d[1] = r[1].ToString().Remove(0, 11).Remove(4, 3);

                    data.Add(d);
                }
                r.Close();

                foreach (string[] s in data)
                {

                    DataVisit_dtGridView.Rows.Add(
                        s[0], s[1], s[2] + " " + s[3], s[4] + " " + s[5], s[6], s[7]);
   
                }
                DataVisit_dtGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                conn = DBUtils.GetDBConnection();
                conn.Open();
                string sql = $"UPDATE Visit SET st_id='" + Status_comBox.SelectedItem + "' WHERE v_id=" + DataVisit_dtGridView.CurrentRow.Cells[0].Value + ")";
                using (var cmd = new OleDbCommand(sql, conn)){
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Статус изменен");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
         
        }

        async void Remand(TimeSpan ch)
        {
            try
            {
                conn = DBUtils.GetDBConnection();
                //listBox1.Items.Clear();

                List<string[]> data = new List<string[]>();

                var time = new List<DateTime>() { };

                var date = new List<DateTime>() { };

                DateTime dtNow = DateTime.Now;

                string sql = $"SELECT v.v_date,v.v_time,c.cl_fname,c.cl_name " +
                    $"FROM Visit v " +
                    $"INNER JOIN Client c ON v.cl_id=c.cl_id;";
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    date.Add(Convert.ToDateTime(r[0]));
                    time.Add(Convert.ToDateTime(r[1]));
                }

                time.Sort();
                date.Sort();

                MessageBox.Show(ch.ToString());

                if (time[0] >= dtNow)
                {
                    //listBox1.Items.Clear();
                    time.RemoveAt(0);
                    date.RemoveAt(0);

                    for (int i = 0; i < date.Count && i < time.Count; i++)
                    {
                        groupBox2.Text = "Список клиентов на текущий день: " + dtNow.ToShortDateString().ToString();
                    }
                }
                if (dtNow >= Convert.ToDateTime(time[0]))
                {
                    //MessageBox.Show("Оповещение сработает через : " + rem.ToString().Remove(0, 10).Remove(4, 3) + " ч");

                    MessageBox.Show("Оповещение сработает через: " + ch);

                    time.RemoveAt(0);
                    date.RemoveAt(0);

                    await Task.Run(async delegate
                    {
                        await Task.Delay(ch);
                        MessageBox.Show("Клиент придет " + date[0] + " " + time[0]);

                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { conn.Close(); }

        }


        private void создатьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDataVisit a = new AddDataVisit();
            a.ShowDialog();
        }

        private void регистрацияКлиентовИУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Record r = new Record();
            this.Hide();
            r.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromMinutes(15);
            int ch = Convert.ToInt32(textBox1.Text);

            switch (comboBox2.SelectedItem)
            {
                case "сутки":
                    t = TimeSpan.FromDays(ch);
                    break;

                case "минута":
                    t = TimeSpan.FromMinutes(ch);
                    break;

                case "час":
                    t = TimeSpan.FromHours(ch);
                    break;

                case "секунда":
                    t = TimeSpan.FromSeconds(ch);
                    break;
            }
                Remand(t);
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            Data(monthCalendar1.SelectionStart.Date);
        }

        private void формированиеПрайслистаУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialCosts m =new MaterialCosts();
            m.ShowDialog();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
