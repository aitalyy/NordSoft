﻿namespace KinoSoft.FormsOrder
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.CostOrder = new System.Windows.Forms.TextBox();
            this.textDatagrid = new System.Windows.Forms.Label();
            this.buttonDisk = new System.Windows.Forms.Button();
            this.buttonListDisk = new System.Windows.Forms.Button();
            this.RemDiskBut = new System.Windows.Forms.Button();
            this.ClientSelect = new System.Windows.Forms.Button();
            this.textButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер заказа";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Информация о клиенте";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата оформления";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата окончания";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 517);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Цена";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 62);
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
            this.dataGridView1.Location = new System.Drawing.Point(34, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(697, 154);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Редактирование клиента";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(570, 512);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(651, 512);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Принять";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(139, 333);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 31;
            this.monthCalendar1.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(139, 308);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(83, 23);
            this.button6.TabIndex = 30;
            this.button6.Text = "Выбор даты";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(228, 308);
            this.Data.Multiline = true;
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(151, 23);
            this.Data.TabIndex = 29;
            this.Data.Text = "дд/мм/гггг";
            this.Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(486, 308);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 23);
            this.button5.TabIndex = 33;
            this.button5.Text = "Выбор даты";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // Data2
            // 
            this.Data2.Location = new System.Drawing.Point(575, 308);
            this.Data2.Multiline = true;
            this.Data2.Name = "Data2";
            this.Data2.Size = new System.Drawing.Size(151, 23);
            this.Data2.TabIndex = 32;
            this.Data2.Text = "дд/мм/гггг";
            this.Data2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(486, 333);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 34;
            this.monthCalendar2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 35;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(619, 62);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 23);
            this.button7.TabIndex = 36;
            this.button7.Text = "Список заказов";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // CostOrder
            // 
            this.CostOrder.Location = new System.Drawing.Point(139, 514);
            this.CostOrder.Name = "CostOrder";
            this.CostOrder.Size = new System.Drawing.Size(83, 20);
            this.CostOrder.TabIndex = 37;
            // 
            // textDatagrid
            // 
            this.textDatagrid.AutoSize = true;
            this.textDatagrid.Location = new System.Drawing.Point(33, 102);
            this.textDatagrid.Name = "textDatagrid";
            this.textDatagrid.Size = new System.Drawing.Size(0, 13);
            this.textDatagrid.TabIndex = 38;
            // 
            // buttonDisk
            // 
            this.buttonDisk.Location = new System.Drawing.Point(656, 279);
            this.buttonDisk.Name = "buttonDisk";
            this.buttonDisk.Size = new System.Drawing.Size(75, 23);
            this.buttonDisk.TabIndex = 39;
            this.buttonDisk.Text = "Выбрать";
            this.buttonDisk.UseVisualStyleBackColor = true;
            this.buttonDisk.Click += new System.EventHandler(this.button8_Click);
            // 
            // buttonListDisk
            // 
            this.buttonListDisk.Location = new System.Drawing.Point(501, 62);
            this.buttonListDisk.Name = "buttonListDisk";
            this.buttonListDisk.Size = new System.Drawing.Size(112, 23);
            this.buttonListDisk.TabIndex = 40;
            this.buttonListDisk.Text = "Список дисков";
            this.buttonListDisk.UseVisualStyleBackColor = true;
            this.buttonListDisk.Click += new System.EventHandler(this.buttonListDisk_Click);
            // 
            // RemDiskBut
            // 
            this.RemDiskBut.Location = new System.Drawing.Point(524, 279);
            this.RemDiskBut.Name = "RemDiskBut";
            this.RemDiskBut.Size = new System.Drawing.Size(126, 23);
            this.RemDiskBut.TabIndex = 41;
            this.RemDiskBut.Text = "Удалить из списка";
            this.RemDiskBut.UseVisualStyleBackColor = true;
            this.RemDiskBut.Click += new System.EventHandler(this.RemDiskBut_Click);
            // 
            // ClientSelect
            // 
            this.ClientSelect.Location = new System.Drawing.Point(382, 62);
            this.ClientSelect.Name = "ClientSelect";
            this.ClientSelect.Size = new System.Drawing.Size(113, 23);
            this.ClientSelect.TabIndex = 42;
            this.ClientSelect.Text = "Список клиентов";
            this.ClientSelect.UseVisualStyleBackColor = true;
            this.ClientSelect.Click += new System.EventHandler(this.ClientSelect_Click);
            // 
            // textButton
            // 
            this.textButton.Location = new System.Drawing.Point(713, 12);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(75, 23);
            this.textButton.TabIndex = 43;
            this.textButton.Text = "test_button";
            this.textButton.UseVisualStyleBackColor = true;
            this.textButton.Click += new System.EventHandler(this.textButton_Click);
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 586);
            this.Controls.Add(this.textButton);
            this.Controls.Add(this.ClientSelect);
            this.Controls.Add(this.RemDiskBut);
            this.Controls.Add(this.buttonListDisk);
            this.Controls.Add(this.buttonDisk);
            this.Controls.Add(this.textDatagrid);
            this.Controls.Add(this.CostOrder);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox1);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddOrder";
            this.Text = "Добавление заказа";
            this.Activated += new System.EventHandler(this.AddOrder_Activated);
            this.Load += new System.EventHandler(this.AddOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox CostOrder;
        private System.Windows.Forms.Label textDatagrid;
        private System.Windows.Forms.Button buttonDisk;
        private System.Windows.Forms.Button buttonListDisk;
        private System.Windows.Forms.Button RemDiskBut;
        private System.Windows.Forms.Button ClientSelect;
        private System.Windows.Forms.Button textButton;
    }
}