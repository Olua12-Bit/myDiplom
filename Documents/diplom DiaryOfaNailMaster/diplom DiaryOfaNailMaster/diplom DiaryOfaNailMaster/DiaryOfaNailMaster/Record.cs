using Dapper;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


//Реализовать удаление строки из БД на listView

namespace DiaryOfaNailMaster
{
    public partial class Record : Form
    {
        public Record()
        {
            
        InitializeComponent();
           
        }
        private OleDbConnection conn;
        
        public  OleDbCommand cmd;
        
       private void Reg_Client()
        {
            try
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();
                
                if (Cl_lstBox.SelectedIndex != -1 || Cl_lstBox.SelectedIndex>0)
                {
                    string str = Cl_lstBox.SelectedItem.ToString();
                    //разбить массив на строки через пробел
                    List<string> lines = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    //соединить строки индексов [3] [4] [5] в одну строку
                var line = new List<string>() { lines[3], lines[4], lines[5] };
                    string s = String.Join(" ", line);
                    //MessageBox.Show(s);

                    lines.Insert(3,s);

                    string sql2 = "INSERT INTO Client (cl_fname,cl_name,cl_phone) VALUES('" + lines[1] + "', '" + lines[2] + "', '" + lines[3] + "')";

                    //lines[0] == "1"
                    //lines[1] == "Кузнецова"
                    //lines[2] == "Саша"
                    //lines[3] == "78905675423"

                cmd = new OleDbCommand(sql2, conn);
                    cmd.ExecuteNonQuery();
                    GetClient();
                }
              else  if (Fname_txtBox.Text != "" || Fname_txtBox.Text != "" || Name_txtBox.Text != "" || Name_txtBox.Text != " "  || maskedTextBox1.Text!= "" || maskedTextBox1.Text != " ")
                {

                    string sql = "INSERT INTO Client (cl_fname,cl_name,cl_phone) VALUES ('" + Fname_txtBox.Text + "','" + Name_txtBox.Text + "','" + maskedTextBox1.Text + "')";
                cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    GetClient();
                }
                else
                {
                    MessageBox.Show("Вы ввели не все данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetClient()
        {
            dataGridView1.Columns.Clear();
            List<string> c = new List<string>() { "Номер клиента", "Фамилия", "Имя", "Телефон" };
            for (int i = 0; i < c.Count; i++)
            {
                dataGridView1.Columns.Add(Name, c[i]);
            }

            dataGridView1.Rows.Clear();

            try
            {
                conn = DBUtils.GetDBConnection();

                conn.Open();

                string sql = $"SELECT cl_id AS {nameof(Client.IdClient)}," +
                  $"cl_fname AS {nameof(Client.FnameClient)}," +
                  $"cl_name AS {nameof(Client.NameClient)}," +
                  $"cl_phone AS {nameof(Client.TelClient)} " +
                  $"FROM Client";
                
                var client = conn.Query<Client>(sql);
                foreach (Client cl in client)
                {
                    dataGridView1.Rows.Add(cl.IdClient, cl.FnameClient, cl.NameClient, cl.TelClient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetMaster()
        {
            dataGridView1.Columns.Clear();
            List<string> mast = new List<string>() { "Номер мастера", "Фамилия", "Имя", "Телефон", "Логин", "Пароль" };
            for (int i = 0; i < mast.Count; i++)
            {
                dataGridView1.Columns.Add(Name, mast[i]);
            }

            dataGridView1.Rows.Clear();
            
            try
            {
                conn = DBUtils.GetDBConnection();

                conn.Open();

                string sql = $"SELECT m_id AS {nameof(Master.IdMaster)}," +
                  $"m_fname AS {nameof(Master.FnameMaster)}," +
                  $"m_name AS {nameof(Master.NameMaster)}," +
                  $"m_phone AS {nameof(Master.TelMaster)} " +
                  $"FROM Master";
                var master = conn.Query<Master> (sql);

                foreach (Master m in master)
                {
                    dataGridView1.Rows.Add(m.IdMaster, m.FnameMaster, m.NameMaster, m.TelMaster,
                        m.LogMaster,m.PassMaster);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
        private void Record_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dataGridView1.Font = new Font("Times New Roman", 14, FontStyle.Regular);


            //GetClient();

            string[] data = { "Мастер маникюра","Клиент" };
            foreach (string d in data) { comboBox1.Items.Add(d); }


            //listView1.View = View.Details;
            //listView1.View = View.Details;
            //listView1.GridLines = true;
          
            //listView1.FullRowSelect = true;
            
         //Color myColor = Color.FromArgb(255, 249, 244);
         //   this.BackColor = myColor;

          
            Cl_lstBox.ScrollAlwaysVisible = true;

            //listView1.Scrollable= true;

            //CreateTableClient();

            textBox2.PasswordChar = '*';

            label5.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;


            //List<string> cl = new List<string>() { "Номер клиента","Фамилия", "Имя", "Телефон" };
            //for (int i = 0; i < cl.Count; i++)
            //{
            //    dataGridView1.Columns.Add(Name, cl[i]);
            //    //listView1.Columns.Add(cl[i]);
            //    //listView1.Columns[i].Width = 150;
            //    //listView1.Columns[i].TextAlign = HorizontalAlignment.Center;
            //}
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //DataVisit_dtGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
       
       
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void UpdClient()
        {
            try
            {
                string id = Cl_lstBox.SelectedItem.ToString().Remove(Cl_lstBox.SelectedItem.ToString().IndexOf(" "));
                string sql = $"UPDATE Client SET cl_fname='" + Fname_txtBox.Text + "',cl_name='"+Name_txtBox.Text+ "',cl_phone='"+maskedTextBox1.Text+"' " +
                    "WHERE cl_id=" + id + " ";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Cl_lstBox.SelectedIndex > 0)
            {
                UpdClient();
            }
            else if (Cl_lstBox.SelectedIndex < 0)
            {
                Reg_Client();
            }
            GetClient();

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            
        }

        

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            GetClient();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Клиент":
                    label5.Visible = false;
                    label8.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    break;
                case "Мастер маникюра":
                    label5.Visible = true;
                    label8.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    break;
            }
        }
    }
}
