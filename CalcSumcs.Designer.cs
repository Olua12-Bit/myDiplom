
namespace DiaryOfaNailMaster
{
    partial class CalcSums
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Mounth_comBox = new System.Windows.Forms.ComboBox();
            this.culcBtn = new System.Windows.Forms.Button();
            this.Year_numUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Year_numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.Mounth_comBox);
            this.panel1.Controls.Add(this.culcBtn);
            this.panel1.Controls.Add(this.Year_numUpDown);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 198);
            this.panel1.TabIndex = 43;
            // 
            // Mounth_comBox
            // 
            this.Mounth_comBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Mounth_comBox.FormattingEnabled = true;
            this.Mounth_comBox.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.Mounth_comBox.Location = new System.Drawing.Point(223, 27);
            this.Mounth_comBox.Margin = new System.Windows.Forms.Padding(4);
            this.Mounth_comBox.Name = "Mounth_comBox";
            this.Mounth_comBox.Size = new System.Drawing.Size(267, 34);
            this.Mounth_comBox.TabIndex = 44;
            // 
            // culcBtn
            // 
            this.culcBtn.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.culcBtn.Location = new System.Drawing.Point(301, 139);
            this.culcBtn.Margin = new System.Windows.Forms.Padding(4);
            this.culcBtn.Name = "culcBtn";
            this.culcBtn.Size = new System.Drawing.Size(189, 43);
            this.culcBtn.TabIndex = 43;
            this.culcBtn.Text = "Посчитать";
            this.culcBtn.UseVisualStyleBackColor = true;
            this.culcBtn.Click += new System.EventHandler(this.culcBtn_Click);
            // 
            // Year_numUpDown
            // 
            this.Year_numUpDown.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Year_numUpDown.Location = new System.Drawing.Point(223, 81);
            this.Year_numUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.Year_numUpDown.Maximum = new decimal(new int[] {
            9998,
            0,
            0,
            0});
            this.Year_numUpDown.Minimum = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.Year_numUpDown.Name = "Year_numUpDown";
            this.Year_numUpDown.Size = new System.Drawing.Size(160, 34);
            this.Year_numUpDown.TabIndex = 45;
            this.Year_numUpDown.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 27);
            this.label1.TabIndex = 42;
            this.label1.Text = "Выбрать  месяц:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label5.Location = new System.Drawing.Point(60, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 27);
            this.label5.TabIndex = 46;
            this.label5.Text = "Выбрать год:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Snow;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 198);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(513, 336);
            this.richTextBox1.TabIndex = 44;
            this.richTextBox1.Text = "";
            // 
            // CalcSums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 534);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CalcSums";
            this.ShowIcon = false;
            this.Text = "Расчет заработной суммы";
            this.Load += new System.EventHandler(this.CalcSums_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Year_numUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Mounth_comBox;
        private System.Windows.Forms.Button culcBtn;
        private System.Windows.Forms.NumericUpDown Year_numUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}