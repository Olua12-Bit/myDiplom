namespace DiaryOfaNailMaster
{
    partial class MaterialCosts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ser_grpBox = new System.Windows.Forms.GroupBox();
            this.priceSertxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nameSertxtBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ser_grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ser_grpBox
            // 
            this.Ser_grpBox.Controls.Add(this.priceSertxtBox);
            this.Ser_grpBox.Controls.Add(this.button1);
            this.Ser_grpBox.Controls.Add(this.label11);
            this.Ser_grpBox.Controls.Add(this.label13);
            this.Ser_grpBox.Controls.Add(this.nameSertxtBox);
            this.Ser_grpBox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ser_grpBox.Location = new System.Drawing.Point(12, 13);
            this.Ser_grpBox.Margin = new System.Windows.Forms.Padding(4);
            this.Ser_grpBox.Name = "Ser_grpBox";
            this.Ser_grpBox.Padding = new System.Windows.Forms.Padding(4);
            this.Ser_grpBox.Size = new System.Drawing.Size(630, 219);
            this.Ser_grpBox.TabIndex = 68;
            this.Ser_grpBox.TabStop = false;
            this.Ser_grpBox.Text = "Данные услуги";
            // 
            // priceSertxtBox
            // 
            this.priceSertxtBox.Location = new System.Drawing.Point(279, 106);
            this.priceSertxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.priceSertxtBox.Name = "priceSertxtBox";
            this.priceSertxtBox.Size = new System.Drawing.Size(156, 34);
            this.priceSertxtBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(389, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 42);
            this.button1.TabIndex = 70;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 109);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 26);
            this.label11.TabIndex = 4;
            this.label11.Text = "Стоимость услуги:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 49);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(229, 26);
            this.label13.TabIndex = 0;
            this.label13.Text = "Наименование услуги:";
            // 
            // nameSertxtBox
            // 
            this.nameSertxtBox.Location = new System.Drawing.Point(279, 53);
            this.nameSertxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameSertxtBox.Name = "nameSertxtBox";
            this.nameSertxtBox.Size = new System.Drawing.Size(308, 34);
            this.nameSertxtBox.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 26;
            this.listBox1.Location = new System.Drawing.Point(682, 176);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(126, 56);
            this.listBox1.TabIndex = 69;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 239);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(631, 323);
            this.listView1.TabIndex = 71;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Наименование";
            this.columnHeader1.Width = 210;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Стоимость";
            this.columnHeader2.Width = 150;
            // 
            // MaterialCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(885, 651);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Ser_grpBox);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MaterialCosts";
            this.ShowIcon = false;
            this.Text = "Формирование прайс-листа услуг";
            this.Load += new System.EventHandler(this.MaterialCosts_Load);
            this.Ser_grpBox.ResumeLayout(false);
            this.Ser_grpBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Ser_grpBox;
        private System.Windows.Forms.TextBox priceSertxtBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox nameSertxtBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}