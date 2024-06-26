using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DiaryOfaNailMaster
{
    public partial class MaterialCosts : Form
    {
        public MaterialCosts()
        {
            InitializeComponent();
        
        }

        private OleDbConnection conn;

        private OleDbCommand cmd;

        private void GetService()
        {
            listView1.Items.Clear();
            try
            {
                conn = DBUtils.GetDBConnection();

                //Ser_grpBox.Visible = true;

                //Cl_grpBox.Visible = false;

                conn.Open();

                List<string[]> s = new List<string[]>();
                cmd = new OleDbCommand("SELECT s_id,s_name,s_price FROM Service ORDER BY s_name, s_price", conn);
                OleDbDataReader r = cmd.ExecuteReader();
                ListViewItem item = null;

                while (r.Read())
                {
                    item = new ListViewItem();
                    //for (int i = 0; i < r.FieldCount; i++) { }
                    //for (int i = 0; i < s.Count; i++) { 
                    //item.Text=r[i].ToString();
                    //}
                    item.Text = r["s_id"].ToString();
                    item.SubItems.Add(r["s_name"].ToString());
                    item.SubItems.Add(r["s_price"].ToString());
                    listView1.Items.Add(item);
                    //Rcd_DataGrdView.Rows.Add(r[0], r[1], r[2]); }
                }
                r.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddService()
        {
            try
            {
                conn = DBUtils.GetDBConnection();

                conn.Open();

                if (nameSertxtBox.Text == " " || nameSertxtBox.Text == "" || priceSertxtBox.Text == " " || priceSertxtBox.Text == "")
                {
                   MessageBox.Show("Проверьте введенные данные");
                }
                else
                {
                    string sql = "INSERT INTO Service(s_name,s_price) VALUES('" + nameSertxtBox.Text + "'," + priceSertxtBox.Text + ")";
                    cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    GetService();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void UpdSer(int id)
        {
            try
            {
                string sql = $"UPDATE Service SET s_name='" + nameSertxtBox.Text + "',s_price='" + priceSertxtBox.Text + "' " +
                    "WHERE s_id="+id+"";
                MessageBox.Show(sql);
                cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int id;

        private void button1_Click_2(object sender, EventArgs e)
        {
          if (nameSertxtBox.Text == "" || nameSertxtBox.Text == " " ||
               priceSertxtBox.Text == "" || priceSertxtBox.Text == " ")
            {
                MessageBox.Show("Проверьте введенные данные");
            }

           else if (listView1.SelectedIndices[0]!=0)
            {
                int selIndex = listView1.SelectedIndices[0];

                if (selIndex != -1)
                {
                    string selected = listView1.SelectedItems[0].SubItems[0].Text;
                    id = Convert.ToInt32(selected);
                    UpdSer(id);
                }
            }

            else
            {
                AddService();
            }

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetService();

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void MaterialCosts_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            listView1.FullRowSelect = true;

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;


        }
    }
}
