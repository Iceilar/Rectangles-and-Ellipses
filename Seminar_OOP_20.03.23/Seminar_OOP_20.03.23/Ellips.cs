using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_OOP_20._03._23
{
    internal class Ellips:Figure
    {
        float r;

        public Ellips(float x, float y, double r):base(x, y)
        {
            this.r = (float)r;
        }

        public override void Draw(Graphics gr, Pen p)
        {
            gr.DrawEllipse(p, x - r, y - r, 2 * r, 2 * r);
        }

        public override string GetInfo(int index)
        {
            return index.ToString() + ") (К)  x = " + x + " / y = " + y + " | r = " + r;
        }

        public override float GetX(int k)
        {
            return x;
        }

        public override float GetY(int k)
        {
            return y;
        }

        public override float GetR()
        {
            return r;
        }
    }
}
