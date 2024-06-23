using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Drawing.Imaging;
using System.CodeDom.Compiler;
using Org.BouncyCastle.Asn1.X509;
using System.Reflection;
using Google.Protobuf.Collections;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Threading;
using Tutorial.SqlConn;
using TextBox = System.Windows.Forms.TextBox;


namespace DiaryOfaNailMaster
{
    public partial class Authorization : Form
    {
        public string m_id, ct_id, p_id;

        public string ctg;
        public Authorization()
        {
            InitializeComponent();
            
        }

       private OleDbConnection conn;
        OleDbCommand cmd;
        private void Autho()
        {
                conn = DBUtils.GetDBConnection();
            try
            {
                if (PasstxtBox.Text == "" || LogtxtBox.Text == "" || PasstxtBox.Text == " " || LogtxtBox.Text == " ")
                {
                    PasstxtBox.ForeColor = Color.Red;
                    LogtxtBox.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;

                    label5.Text = "Вы ввели не все данные";
                }
                else
                {
                    conn.Open();
                    string sql = "SELECT m_id, m_login, m_pass FROM Master " +
                        $"WHERE (m_login = '" + LogtxtBox.Text + "' AND " +
                        $"m_pass = '" + PasstxtBox.Text + "')";

                    cmd = new OleDbCommand(sql, conn);
                    string log = "", pass = "";
                    object id = cmd.ExecuteScalar();
                    if (id != null)
                    {
                        OleDbDataReader r = cmd.ExecuteReader();//чтение данных
                        while (r.Read())
                        {
                            m_id = r[0].ToString();
                            log = r[1].ToString();
                            pass = r[2].ToString();
                            //извлекаем и читаем строку из БД
                        }
                        r.Close();

                        if (log == LogtxtBox.Text && pass == PasstxtBox.Text)
                        {
                            this.Text = "Портфолио работ";
                            this.Size = new Size(700, 538);
                            menuStrip1.Visible=true;
                            groupBox1.Visible = false;
                            button1.Visible = true;

                            foreach (Panel p in this.Controls.OfType<Panel>())
                            {
                                p.Visible = true;
                            }
                            for (int i = 0; i < menuStrip1.Items.Count; i++)
                            {
                                menuStrip1.Items[i].Visible = true;
                                
                            }
                            входToolStripMenuItem.Visible=false;
                        }
                    }
                    else {
                        
                        PasstxtBox.ForeColor = Color.Red;
                        LogtxtBox.ForeColor = Color.Red;

                        label5.ForeColor = Color.Red;
                        label5.Text = "Проверьте введенные данные";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { conn.Close(); }
            
        }

        public string sim="";
        
    private void GetImage(string sim,string p_name,ListViewItem item)
        {
            conn = DBUtils.GetDBConnection();
            try
            {
               
                string ctg = GetCtgId(ct_id);

                if (ctg != null)
                {
                    listView2.Items.Clear();
                    ImageList myImgList = new ImageList
                    {
                        ImageSize = new Size(190, 220),
                        ColorDepth = ColorDepth.Depth32Bit
                    };
                    myImgList.Dispose();

                    conn.Open();
                    cmd = new OleDbCommand("SELECT p_id, p_name, p_path FROM Picture WHERE ct_id=" + ctg + "", conn);

                    OleDbDataReader r = cmd.ExecuteReader();

                    List<string> name = new List<string>();

                    ListViewItem lvi = new ListViewItem();

                    while (r.Read())
                    {
                        lvi.SubItems.Add(r.GetString(1));
                        name.Add(r.GetString(1));//получить наименование изображения
                        myImgList.Images.Add(Bitmap.FromFile(r.GetString(2))); //получение изображения по пути
                        p_id = r[0].ToString();
                    }

                    listView2.View = View.LargeIcon;
                    listView2.LargeImageList = myImgList;

                    for (int i = 0; i < myImgList.Images.Count && i < name.Count; i++)
                    {
                        ListViewItem itm = new ListViewItem();

                        itm.ImageIndex = i;

                        itm.Text = sim + name[i];

                        listView2.Items.Add(itm);

                    }

                }
            }
            catch (Exception ex)
            {
                Mess(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private string Mess(string mess)
        {
            MessageBox.Show(mess);
            return mess;
        }


        private void GetCtg()
        {
            Ctg_cmBox.Items.Clear();

            try
            {
                conn = DBUtils.GetDBConnection();

                conn.Open();
                cmd = new OleDbCommand("SELECT ct_id, ct_name FROM Category", conn);
                OleDbDataReader r = cmd.ExecuteReader();
                while (r.Read())
                { 
                    Ctg_cmBox.Items.Add(r[0] + " " + r[1]); 
                }
                r.Close();
            }
            catch (Exception ex)
            {
                Mess(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private string GetCtgId(string ct_id)
        {
            if (Ctg_cmBox.SelectedIndex != -1)
            {
                ct_id = Ctg_cmBox.SelectedItem.ToString().Remove(Ctg_cmBox.SelectedItem.ToString().IndexOf(" "));
            }
            else
            {
                return null;
            }

            return ct_id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                this.CenterToScreen();

            this.Size = new Size(700, 480);

            PasstxtBox.PasswordChar = '*';

            foreach (Panel p in this.Controls.OfType<Panel>())
            {
                p.Dock = DockStyle.Top;
            }
            groupBox1.Visible=false;
            panel1.Visible=false;
            button1.Visible=false;

            for(int i = 0;i<menuStrip1.Items.Count-2;i++)
            {
                menuStrip1.Items[i].Visible=false;
            }

        }

        //private void DelImg()
        //{
        //    try
        //    {
        //        for (int i = 0; i < listView2.SelectedIndices.Count; i++)
        //        {
        //            string nameImg = listView2.Items[i].Text;

        //            listView2.Items.Remove(listView2.Items[i]);

        //            string sql = "DELETE FROM Picture WHERE p_name= '" + nameImg + "'";

        //            cmd = new OleDbCommand(sql, conn);
        //            cmd.ExecuteNonQuery();

        //            //string path = @"files\\" + nameImg;
        //            //FileInfo fileInf = new FileInfo(path);
        //            //if (fileInf.Exists)
        //            //{
        //            //    fileInf.Delete();
        //            //    MessageBox.Show(path);
        //            //}

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        private void DelCtg()
        {
            try
            {
                conn = DBUtils.GetDBConnection();
                ctg = GetCtgId(ct_id);

                //Просто ещё один запрос на удаление всех при условии что категория та, которую ты выбрала
                conn.Open();
                string sql = "DELETE FROM Category WHERE ct_id=" + ctg + "";
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                DialogResult res = MessageBox.Show("В данной категории есть изображения, удалить?",
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    sql = "DELETE FROM Picture WHERE ct_id=" + ctg + "";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
           
                //проверка существует ли строка в таблице по условию выбранного индекса категории
                //если да, то выведет сообщение с оповещением
                //если нет сообщение не выведет
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
        }

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void InsCtg()
        {
            conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
            if (textBox1.Text == "" || textBox1.Text == " " || textBox1.Text == null)
                {
                    Mess("Вы не ввели наименование категории");
                }
                else
                {
                   string sql = "INSERT INTO Category(ct_name,m_id) VALUES('" + textBox1.Text + "'," + m_id + ")";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }

        }

        private void InsImage(string im_name, string im_path, string ct_id)
        {
            try
            {
                conn = DBUtils.GetDBConnection();
                ctg = GetCtgId(ct_id);

                ct_id = Ctg_cmBox.SelectedItem.ToString().Remove(Ctg_cmBox.SelectedItem.ToString().IndexOf(" "));

                if (ctg != null)
                {
                    conn.Open();
                    string sql = "INSERT INTO Picture (p_name, p_path, ct_id) VALUES ('" + im_name + "', '" + im_path + "', " + ct_id + ")";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (Ctg_cmBox.SelectedIndex == -1 || Ctg_cmBox.SelectedIndex < 0)
                {
                    Mess("Выберете категорию в списке");
                }
            }
            catch (Exception ex) {
                Mess(ex.ToString());
            }
            finally { conn.Close(); }
        }

        private void UpdLog()
        {
            conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                InputBtn.Text = "Сохранить";
                label5.Text = "Восстановление данных";
                string sql = "UPDATE Master SET m_login='" + LogtxtBox.Text + "',m_pass= '" + PasstxtBox.Text + "' WHERE m_id = 1";
                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные изменены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {  
            if(InputBtn.Text == "Войти")
                {
                    Autho();
                }
                else                                                                              
                {
                    InputBtn.Text = "Войти";
                    label5.Text = "Вход";
                    UpdLog();
                    Autho();
                } 
        }

        private void входToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Text = "Авторизация";
            this.Size = new Size(535 + 40, 382);
            groupBox1.Location = new Point(12, 12);

            foreach (Panel p in this.Controls.OfType<Panel>())
            {
                p.Visible = false;
            }
            menuStrip1.Visible = false;

            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Visible = true;

        }

        private void формированиеЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raspisanie r = new Raspisanie();
            this.Visible = false;
            r.ShowDialog();
            this.Visible = true;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelCtg();
          
        }

        public string p_name;
        public ListViewItem item;

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sim = " ";
            GetImage(sim,p_name,item);
            GetCtg();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InputBtn.Text = "Сохранить";
            label5.Text = "Восстановление данных";
            linkLabel1.Visible = false;
            PasstxtBox.Clear();
            LogtxtBox.Clear();
            InputBtn.Location = new Point(210, 240);
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            InsCtg();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Images";
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";

            // Фильтр для отображения только изображений
            file.Multiselect = true;

            if (Ctg_cmBox.SelectedIndex == -1 || Ctg_cmBox.SelectedIndex < 0)
            {
                Mess("Выберите категорию в списке");
            }
            else if (Ctg_cmBox.SelectedIndex != -1 || Ctg_cmBox.SelectedIndex > 0)
            {
                DialogResult ans = file.ShowDialog();
                if (ans == DialogResult.OK)
                {
                    FileInfo f = new FileInfo(file.FileName);
                    //создание экземпляра файла с наименованием

                    string end = file.FileName.Remove(0, file.FileName.LastIndexOf("."));
                    //Удаление расширения файла из строки

                    string getName = Path.GetFileNameWithoutExtension(file.ToString());
                    //получить имя картинки из диалогового окна
                    try
                    {
                        f.CopyTo("files/" + getName + end);
                        //файл копируется в папку files
                    }
                    catch (Exception ex)
                    {
                        Mess(ex.ToString());
                    }
                    InsImage(getName + end, "files\\" + getName + end, ctg);
                }

                sim += " * ";
                GetImage(sim, p_name, item);
            }
        }

        private void расчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalcSums cs = new CalcSums();
            this.Hide();
            cs.ShowDialog();
            this.Visible = true;
        }

    }
}
