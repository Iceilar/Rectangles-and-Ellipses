using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_OOP_20._03._23
{
    abstract class Figure
    {
        protected float x;
        protected float y;

        public Figure(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void Draw(Graphics g, Pen p);

        public void DrowS(Graphics gr, int count, Font font, Brush brush)
        {
            Point point = new Point(Convert.ToInt32(x - 12), Convert.ToInt32(y - 12));

            gr.DrawString(Convert.ToString(count), font, brush, point);
        }

        public abstract string GetInfo(int index);

        public string GetRasp(Figure r, int nomer11, int nomer22)
        {
            if (this is Rectangle && r is Rectangle)
            {
                Rectangle rect = (Rectangle)this;

                float xu = x - rect.GetW() / 2;
                float yu = y - rect.GetH() / 2;
                float xd = x + rect.GetW() / 2;
                float yd = y + rect.GetH() / 2;

                int nomer1 = nomer11 + 1;
                int nomer2 = nomer22 + 1;

                float xu1 = r.GetX(1);
                float yu1 = r.GetY(1);
                float xd1 = r.GetX(-1);
                float yd1 = r.GetY(-1);

                if (xu == xu1 && yu == yu1 && xd == xd1 && yd == yd1)
                {
                    return "Выбран один и тот же Объект";
                }

                if ((xu < xu1 && yu < yu1) && (xd > xd1 && yd > yd1))
                {
                    return "Объект №" + nomer2 + " лежит внутри Объекта №" + nomer1;
                }

                if ((xu > xu1 && yu > yu1) && (xd < xd1 && yd < yd1))
                {
                    return "Объект №" + nomer1 + " лежит внутри Объекта №" + nomer2;
                }

                if ((xd < xu1) || (xu > xd1) || (yd < yu1) || (yu > yd1))
                {
                    return "Объекты №" + nomer1 + " и №" + nomer2 + " не пересекаются";
                }

                return "Объекты №" + nomer1 + " и №" + nomer2 + " пересекаются";
            }

            if (this is Ellips && r is Ellips)
            {
                Ellips el = (Ellips)this;

                float x = el.GetX(1);
                float y = el.GetY(1);
                float ra = el.GetR();

                float x1 = r.GetX(1);
                float y1 = r.GetY(1);
                float r1 = r.GetR();

                int nomer1 = nomer11 + 1;
                int nomer2 = nomer22 + 1;

                float x_p = Math.Abs(x - x1);
                float y_p = Math.Abs(y - y1);
                double dist = Math.Sqrt(x_p * x_p + y_p * y_p);

                if (x == x1 && y == y1 && ra == r1)
                {
                    return "Выбран один и тот же Объект";
                }

                if (ra > (dist + r1))
                {
                    return "Объект №" + nomer2 + " лежит внутри Объекта №" + nomer1;
                }

                if (r1 > (dist + ra))
                {
                    return "Объект №" + nomer1 + " лежит внутри Объекта №" + nomer2;
                }

                if (dist > (ra + r1))
                {
                    return "Объекты №" + nomer1 + " и №" + nomer2 + " не пересекаются";
                }
                return "Объекты №" + nomer1 + " и №" + nomer2 + " пересекаются";
            }

            if (this is Ellips && r is Rectangle || this is Rectangle && r is Ellips)
            {
                float xu;
                float yu;
                float xd;
                float yd;

                float xr;
                float yr;
                float ra;

                Rectangle rect;
                Ellips el;

                if (this is Rectangle)
                {
                    rect = (Rectangle)this;
                    el = (Ellips)r;

                    xu = rect.GetX(1);
                    yu = rect.GetY(1);
                    xd = rect.GetX(-1);
                    yd = rect.GetY(-1);

                    xr = el.GetX(1);
                    yr = el.GetY(1);
                    ra = el.GetR();
                }

                else
                {
                    el = (Ellips)this;
                    rect = (Rectangle)r;

                    xr = el.GetX(1);
                    yr = el.GetY(1);
                    ra = el.GetR();

                    xu = rect.GetX(1);
                    yu = rect.GetY(1);
                    xd = rect.GetX(-1);
                    yd = rect.GetY(-1);
                }
                float c_x = xu + (xd - xu) / 2;
                float c_y = yu + (yd - yu) / 2;

                xr = c_x + Math.Abs(xr - c_x);
                yr = c_y + Math.Abs(yr - c_y);

                int nomer1 = nomer11 + 1;
                int nomer2 = nomer22 + 1;

                if ((xu < xr - ra && yu < yr - ra) && (xd > xr + ra && yd > yr + ra))
                {
                    return "Круг лежит внутри Прямоугольника";
                }

                if ((Gipotenuza(xu, yu, xr, yr) < ra))
                {
                    return "Прямоугольник лежит внутри Круга";
                }

                if ((xd < xr - ra) || (yd < yr - ra) || ((Gipotenuza(xr, yr, c_x, c_y) > ra + Gipotenuza(c_x, c_y, xd, yd))))
                {
                    return "Объекты №" + nomer1 + " и №" + nomer2 + " не пересекаются";
                }

                return "Объекты №" + nomer1 + " и №" + nomer2 + " пересекаются";
            }

               
            return "Вы каким-то образом сломали программу";
        }

        public abstract float GetX(int k);
        public abstract float GetY(int k);
        public virtual float GetR()
        {
            return 0;
        }

        public float Gipotenuza(float x, float y, float x1, float y1) 
        {
            float x_p = Math.Abs(x - x1);
            float y_p = Math.Abs(y - y1);
            double dist = Math.Sqrt(x_p * x_p + y_p * y_p);

            return (float)dist;
        }
    }
}
