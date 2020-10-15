using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics canvas;
        SolidBrush brush;
        Pen pen;
        int x, y;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int thickness = trackBar1.Value;
            if (radioButton1.Checked)
            { 
                if (e.Button == MouseButtons.Left)
                {
                    brush.Color = colorDialog1.Color;
                    canvas.FillEllipse(brush, e.X - thickness / 2, e.Y - thickness / 2, thickness, thickness);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    brush.Color = colorDialog2.Color;
                    canvas.FillEllipse(brush, e.X - thickness / 2, e.Y - thickness / 2, thickness, thickness);
                }
            }
            else if (radioButton5.Checked&&e.Button==MouseButtons.Left)
            {
                Random random = new Random();
                for(int i = 0; i < 10; i++)
                {
                    canvas.FillEllipse(brush, e.X +random.Next(-thickness/2,thickness/2), e.Y + random.Next(-thickness / 2, thickness / 2), 2, 2);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = 0; y = 0;
            brush = new SolidBrush(colorDialog1.Color);
            pen = new Pen(colorDialog1.Color, trackBar1.Value);
            canvas = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton2.Checked)
            {
                pen.Color = colorDialog1.Color;
                pen.Width = trackBar1.Value;
                canvas.DrawLine(pen, x, y, e.X, e.Y);
            }
            else if (radioButton3.Checked)
            {
                pen.Color = colorDialog1.Color;
                pen.Width = trackBar1.Value;
                canvas.DrawEllipse(pen, x, y, e.X-x, e.Y-y);
            }
            else if (radioButton4.Checked)
            {
                int Xfin, Yfin;
                if (e.X - x > 0)
                    Xfin = e.X;
                else
                {
                    Xfin = x;
                    x = e.X;
                }
                if (e.Y - y > 0)
                    Yfin = e.Y;
                else
                {
                    Yfin = y;
                    y = e.Y;
                }
                pen.Color = colorDialog1.Color;
                pen.Width = trackBar1.Value;
                canvas.DrawRectangle(pen, x, y, Xfin-x,Yfin-y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            if (radioButton6.Checked)
            {
                canvas.DrawString(textBox1.Text, fontDialog1.Font, brush, x, y);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton6.Checked)
                fontDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            button2.BackColor = colorDialog2.Color;
        }
    }
}
