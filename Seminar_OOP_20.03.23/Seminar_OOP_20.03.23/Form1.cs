using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_OOP_20._03._23
{
    public partial class Form1 : Form
    {
        float x_up, y_up, x_down, y_down;
        int count_rect = 0;

        Graphics gr;

        Pen p;
        Brush brush;
        Font font;
        Point point;

        List<Figure> figure = new List<Figure>();

        Random rnd = new Random();



        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            figure.Clear();
            listBox1.Items.Clear();
            count_rect= 0;
        }


        public Form1()
        {
            InitializeComponent();

            p = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 3);
            brush= new SolidBrush(Color.Black);
            font = new Font("Comic", 16);
            gr = panel1.CreateGraphics();
        }

        string tip = "Rec";

        private void button2_Click(object sender, EventArgs e)
        {
            tip = "Rec";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tip = "Ell";
        }


        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            p.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            if (e.Button == MouseButtons.Right && tip == "Rec")
            {
                float x_center = e.X;
                float y_center = e.Y;



                float w = rnd.Next(10, 100);
                Rectangle r = new Rectangle(x_center, y_center, w);
                r.Draw(gr, p);

                count_rect++;
                listBox1.Items.Add(r.GetInfo(count_rect));
                figure.Add(r);


                r.DrowS(gr, count_rect, font, brush);
            }


            if (e.Button == MouseButtons.Left && tip == "Rec")
            {
                x_up = e.X;
                y_up = e.Y;

                float x_center = (x_down + x_up) / 2;
                float y_center = (y_down + y_up) / 2;
                float w = Math.Abs(x_down - x_up);
                float h = Math.Abs(y_down - y_up);
                Rectangle r = new Rectangle(x_center, y_center, w, h);
                r.Draw(gr, p);


                count_rect++;
                listBox1.Items.Add(r.GetInfo(count_rect));
                figure.Add(r);

                r.DrowS(gr, count_rect, font, brush);

                //---------Ellips
            }

            if (e.Button == MouseButtons.Right && tip == "Ell")
            {
                float x_center = e.X;
                float y_center = e.Y;

                float xy = rnd.Next(10, 100);

                float x_p = Math.Abs(10 - xy);
                float y_p = Math.Abs(10 - xy);
                double r = Math.Sqrt(x_p * x_p + y_p * y_p);

                Ellips el = new Ellips(x_center, y_center, r);

                el.Draw(gr, p);

                count_rect++;
                listBox1.Items.Add(el.GetInfo(count_rect));
                figure.Add(el);

                el.DrowS(gr, count_rect, font, brush);
            }

            if (e.Button == MouseButtons.Left && tip == "Ell")
            {
                float x_center = e.X;
                float y_center = e.Y;

                (x_center, x_down) = (x_down, x_center);
                (y_center, y_down) = (y_down, y_center);

                float x_p = Math.Abs(x_center - x_down);
                float y_p = Math.Abs(y_center - y_down);
                double r = Math.Sqrt(x_p * x_p + y_p * y_p);

                Ellips el = new Ellips(x_center, y_center, r);

                el.Draw(gr, p);

                count_rect++;
                listBox1.Items.Add(el.GetInfo(count_rect));
                figure.Add(el);

                el.DrowS(gr, count_rect, font, brush);
            }

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                x_down = e.X;
                y_down = e.Y;
            }
        }

        int index1;
        int index2;
        bool f = true;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f == true)
            {
                index1 = listBox1.SelectedIndex;
                f = false;
            }
            else
            {
                index2 = listBox1.SelectedIndex;
                MessageBox.Show(figure[index1].GetRasp(figure[index2], index1, index2));
                f = true;
            }

        }
    }
}
