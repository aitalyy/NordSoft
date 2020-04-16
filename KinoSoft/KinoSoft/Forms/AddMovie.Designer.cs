namespace KinoSoft.Forms
{
    partial class AddMovie
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
            this.MovieName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Actors = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Country = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Producer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Opisanie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Genre = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название фильма";
            // 
            // MovieName
            // 
            this.MovieName.Location = new System.Drawing.Point(131, 12);
            this.MovieName.Multiline = true;
            this.MovieName.Name = "MovieName";
            this.MovieName.Size = new System.Drawing.Size(321, 25);
            this.MovieName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 448);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(301, 121);
            this.Data.Multiline = true;
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(151, 23);
            this.Data.TabIndex = 5;
            this.Data.Text = "дд/мм/гггг";
            this.Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // Actors
            // 
            this.Actors.Location = new System.Drawing.Point(131, 248);
            this.Actors.Multiline = true;
            this.Actors.Name = "Actors";
            this.Actors.Size = new System.Drawing.Size(321, 25);
            this.Actors.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Жанр";
            // 
            // Country
            // 
            this.Country.Location = new System.Drawing.Point(131, 186);
            this.Country.Multiline = true;
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(321, 25);
            this.Country.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Описание";
            // 
            // Producer
            // 
            this.Producer.Location = new System.Drawing.Point(131, 217);
            this.Producer.Multiline = true;
            this.Producer.Name = "Producer";
            this.Producer.Size = new System.Drawing.Size(321, 25);
            this.Producer.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Год выпуска";
            // 
            // Opisanie
            // 
            this.Opisanie.Location = new System.Drawing.Point(131, 279);
            this.Opisanie.Multiline = true;
            this.Opisanie.Name = "Opisanie";
            this.Opisanie.Size = new System.Drawing.Size(321, 155);
            this.Opisanie.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Возрастная категория";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Страна";
            // 
            // Genre
            // 
            this.Genre.FormattingEnabled = true;
            this.Genre.Location = new System.Drawing.Point(131, 49);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(321, 64);
            this.Genre.TabIndex = 22;
            this.Genre.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Актёрский состав";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Режиссер";
            // 
            // Category
            // 
            this.Category.FormattingEnabled = true;
            this.Category.Items.AddRange(new object[] {
            "0+",
            "6+",
            "12+",
            "16+",
            "18+",
            "21+"});
            this.Category.Location = new System.Drawing.Point(131, 154);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(321, 21);
            this.Category.TabIndex = 26;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(131, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Выбор даты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(131, 146);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 28;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 448);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 38);
            this.button4.TabIndex = 29;
            this.button4.Text = "Изменить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 25);
            this.button5.TabIndex = 30;
            this.button5.Text = "Добавить Жанр";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // AddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 498);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Genre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Opisanie);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Producer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Actors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MovieName);
            this.Controls.Add(this.label1);
            this.Name = "AddMovie";
            this.Text = "Добавление фильма";
            this.Load += new System.EventHandler(this.AddMovie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MovieName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Actors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Country;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Producer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Opisanie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox Genre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Category;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}
