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

        public string rol="";

        public string str="";

        private void RegPolz()
        {
            try
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();

                //if (listBox1.SelectedIndex != -1 || listBox1.SelectedIndex>0)

                //if (listBox1.SelectedItem != null)
                //{
                //    string str = listBox1.SelectedItem.ToString();
                //    //разбить массив на строки через пробел
                //    List<string> lines = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                //    //соединить строки индексов [3] [4] [5] в одну строку
                //    var line = new List<string>() { lines[3], lines[4], lines[5] };
                //    string s = String.Join(" ", line);
                //    //MessageBox.Show(s);

                //    lines.Insert(3, s);

                //    string sql2 = $"INSERT INTO {rol} ({str}) VALUES('" + lines[1] + "', '" + lines[2] + "', '" + lines[3] + "')";
                //    MessageBox.Show(sql2);

                //    //lines[0] == "1"
                //    //lines[1] == "Кузнецова"
                //    //lines[2] == "Саша"
                //    //lines[3] == "78905675423"

                //    cmd = new OleDbCommand(sql2, conn);
                //    cmd.ExecuteNonQuery();
                //    //GetClient();
                //}


              if (textBox1.Text != " " || textBox1.Text != "" || Fname_txtBox.Text != "" || Fname_txtBox.Text != "" ||
                      Name_txtBox.Text != "" || Name_txtBox.Text != " " ||
                      maskedTextBox1.Text != "" || maskedTextBox1.Text != " " ||
                      textBox2.Text != "" || textBox2.Text != " ")
                {

                    string sql = $"INSERT INTO {rol} ({str}) " +
                        $"VALUES ('" + Fname_txtBox.Text + "','" + Name_txtBox.Text + "','" + maskedTextBox1.Text + "'," +
                        "'" + textBox1.Text + "','" + textBox2.Text + "')";

                    //MessageBox.Show(sql);

                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    GetClient();
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetClient()
        {
            List<string> c = new List<string>() { "Номер клиента", "Фамилия", "Имя", "Телефон" };
            for (int i = 0; i < c.Count; i++)
            {
                dataGridView1.Columns.Add(Name, c[i]);
            }
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
                    listBox1.Items.Add(cl.IdClient+" "+ cl.FnameClient+" "+ cl.NameClient+" "+ cl.TelClient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetMaster()
        {
            List<string> mast = new List<string>() { "Номер мастера", "Фамилия", "Имя", "Телефон", "Логин", "Пароль" };
            for (int i = 0; i < mast.Count; i++)
            {
                dataGridView1.Columns.Add(Name, mast[i]);
            }
            try
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();
                string sql = $"SELECT m_id AS {nameof(Master.IdMaster)}," +
                  $"m_fname AS {nameof(Master.FnameMaster)}," +
                  $"m_name AS {nameof(Master.NameMaster)}," +
                  $"m_phone AS {nameof(Master.TelMaster)}," +
                  $"m_login AS {nameof(Master.LogMaster)}," +
                  $"m_pass AS {nameof(Master.PassMaster)} " +
                  $"FROM Master";
                var master = conn.Query<Master> (sql);
                foreach (Master m in master)
                {
                    dataGridView1.Rows.Add(m.IdMaster, m.FnameMaster, m.NameMaster, m.TelMaster,
                        m.LogMaster,m.PassMaster);
                    listBox1.Items.Add(m.IdMaster+" "+ m.FnameMaster+" "+m.NameMaster+" "+ m.TelMaster+" "+
                        m.LogMaster+" "+ m.PassMaster);
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

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            string[] data = { "Мастер маникюра","Клиент" };
            foreach (string d in data) { comboBox1.Items.Add(d); }

            listBox1.ScrollAlwaysVisible = true;
            textBox2.PasswordChar = '*';
            label5.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }
       
        private void Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn = DBUtils.GetDBConnection();
            conn.Close();
        }

        private void UpdMaster()
        {
            try
            {
                string id = listBox1.SelectedItem.ToString().Remove(listBox1.SelectedItem.ToString().IndexOf(" "));
                string sql = $"UPDATE Master SET m_fname='" + Fname_txtBox.Text + "',m_name='"+Name_txtBox.Text+ "',m_phone='"+maskedTextBox1.Text+"' " +
                    "WHERE m_id=" + id + " ";
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdClient()
        {
            try
            {
                string id = listBox1.SelectedItem.ToString().Remove(listBox1.SelectedItem.ToString().IndexOf(" "));
                string sql = $"UPDATE Client SET cl_fname='" + Fname_txtBox.Text + "',cl_name='" + Name_txtBox.Text + "',cl_phone='" + maskedTextBox1.Text + "' " +
                    "WHERE cl_id=" + id + " ";
                 cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            listBox1.Items.Clear();

            switch (comboBox1.SelectedItem)
            {
                case "Клиент":
                    GetClient();
                    break;

                case "Мастер маникюра":
                    GetMaster();
                    break;

                default:
                    MessageBox.Show("Выберете статус в списке");
                    break;
            }

          dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            Fname_txtBox.Clear();
            Name_txtBox.Clear();
            maskedTextBox1.Clear();

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " " || textBox2.Text == "" || textBox2.Text == " " ||
                Fname_txtBox.Text == " " || Fname_txtBox.Text == "" || Name_txtBox.Text == "" || Name_txtBox.Text == " " ||
                maskedTextBox1.Text == "" || maskedTextBox1.Text == " ")
            {
                MessageBox.Show("Проверьте введенные данные");
            }


         else if (listBox1.SelectedItem!=null)
            {
                switch (comboBox1.SelectedItem)
                {
                    case "Клиент":
                        UpdClient();
                        break;

                    case "Мастер маникюра":
                        UpdMaster();
                        break;
                }
            }

            else
            {
                switch (comboBox1.SelectedItem)
                {
                    case "Клиент":
                        rol = "Client";
                        str = "cl_fname,cl_name,cl_phone";
                        break;

                    case "Мастер маникюра":
                        rol = "Master";
                        str = "m_fname,m_name,m_phone,m_login,m_pass";
                        break;

                    default:
                        MessageBox.Show("Проверьте введенные данные");
                        break;
                }
               
            }
            RegPolz();

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
    }
}
