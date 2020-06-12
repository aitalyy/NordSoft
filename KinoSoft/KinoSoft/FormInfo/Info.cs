using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.FormInfo
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        float step = 0;
        int i = 0;
        Color currentColor = Color.DarkGreen;
        Color targetColor = Color.LightBlue;
        Random rnd = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 1000)
            {
                label1.Visible = true;
                progressBar1.Value = 1000;
                timer1.Stop();
            }
            else
            {
                label2.Text = (i/10).ToString() + "%";
                i++;
                progressBar1.Value += 1;
            }

            if (step >= 1f)
            {
                step = 0;

                int R = rnd.Next(0, 255);
                int G = rnd.Next(0, 255);
                int B = rnd.Next(0, 255);
                currentColor = targetColor;
                targetColor = Color.FromArgb(R, G, B);
            }
            int mixR = (int)(currentColor.R * (1f - step) + targetColor.R * step);
            int mixG = (int)(currentColor.G * (1f - step) + targetColor.G * step);
            int mixB = (int)(currentColor.B * (1f - step) + targetColor.B * step);
            this.BackColor = Color.FromArgb(mixR, mixG, mixB);
            this.button1.BackColor = Color.FromArgb(mixR, mixG, mixB);
            step += 0.01f;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
