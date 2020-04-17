namespace KinoSoft.FormsOrder
{
    partial class AddOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button6 = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.Data2 = new System.Windows.Forms.TextBox();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер заказа";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Информация о клиенте";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата оформления";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата окончания";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Фильмы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 449);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Цена";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить клиента";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(697, 101);
            this.dataGridView1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Редактирование клиента";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(539, 465);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(656, 465);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Принять";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(137, 300);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 31;
            this.monthCalendar1.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(137, 275);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(83, 23);
            this.button6.TabIndex = 30;
            this.button6.Text = "Выбор даты";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(226, 275);
            this.Data.Multiline = true;
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(151, 23);
            this.Data.TabIndex = 29;
            this.Data.Text = "дд/мм/гггг";
            this.Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(484, 275);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 23);
            this.button5.TabIndex = 33;
            this.button5.Text = "Выбор даты";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // Data2
            // 
            this.Data2.Location = new System.Drawing.Point(573, 275);
            this.Data2.Multiline = true;
            this.Data2.Name = "Data2";
            this.Data2.Size = new System.Drawing.Size(151, 23);
            this.Data2.TabIndex = 32;
            this.Data2.Text = "дд/мм/гггг";
            this.Data2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(484, 300);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 34;
            this.monthCalendar2.Visible = false;
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Data2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOrder";
            this.Text = "Добавление заказа";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox Data;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox Data2;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
    }
}