using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DiaryOfaNailMaster
{
    public partial class MaterialCosts : Form
    {
        public MaterialCosts()
        {
            InitializeComponent();
        
        }
        //private void  GetService()
        //{
        //    try
        //    {
        //       //Ser_grpBox.Visible = true;

        //        Cl_grpBox.Visible = false;

        //        List<string[]> s = new List<string[]>();
        //     cmd = new OleDbCommand("SELECT s_id,s_name,s_price FROM Service ORDER BY s_name, s_price", conn);
        //        OleDbDataReader r = cmd.ExecuteReader();
        //        ListViewItem item= null;

        //        while (r.Read())
        //        {
        //                 item = new ListViewItem();
        //            //for (int i = 0; i < r.FieldCount; i++) { }
        //            //for (int i = 0; i < s.Count; i++) { 
        //            //item.Text=r[i].ToString();
        //            //}
        //            item.Text = r["s_id"].ToString();
        //            item.SubItems.Add(r["s_name"].ToString());
        //            item.SubItems.Add(r["s_price"].ToString());
        //            listView1.Items.Add(item);
        //            //Rcd_DataGrdView.Rows.Add(r[0], r[1], r[2]); }
        //        }
        //        r.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        Mess(ex.ToString());
        //    }
        //}

        //private void InsService()
        //{
        //    try
        //    {
        //        if (nameSertxtBox.Text == " " || nameSertxtBox.Text == "" || priceSertxtBox.Text == " " || priceSertxtBox.Text == "")
        //        {
        //            Mess("Вы ввели не все данные");
        //        }
        //        else
        //        {
        //            string sql = "INSERT INTO Service(s_name,s_price) VALUES('" + nameSertxtBox.Text + "'," + priceSertxtBox.Text + ")";
        //         cmd = new OleDbCommand(sql, conn);
        //            cmd.ExecuteNonQuery();
        //            GetService();
        //        }
        //    }
        //    catch (Exception er)
        //    {
        //        Mess(er.ToString());
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MaterialCosts_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // Создаем массив строк
            string[] items = { "Укрепление ногтей", "1500"};
            // Добавляем значения в ListView
            this.listView1.Items.Add(new ListViewItem(items));
            // Модифицируем массив
            items[0] = "Укрепление ногтей";
            items[1] = "1500";
          
            // И снова добавляем элементы
            this.listView1.Items.Add(new ListViewItem(items));
        }
    }
}
