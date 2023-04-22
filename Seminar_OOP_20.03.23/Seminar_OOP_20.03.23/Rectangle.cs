using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_OOP_20._03._23
{
    internal class Rectangle:Figure
    {
        float width;
        float height;

        public Rectangle(float x, float y, float shir, float vis):base(x, y)
        {
            this.width = shir;
            this.height = vis;
        }

        public Rectangle(float x, float y, float shir) : base(x, y)
        {
            this.width = shir;
            this.height = shir;
        }
    

        public override void Draw(Graphics gr, Pen p)
        {
            gr.DrawRectangle(p, x - width / 2, y - height / 2, width, height);
        }

        

        public override string GetInfo(int index)
        {
            return index.ToString() + ") (П)  x = " + x + " / y = " + y + " | width = " + width + " / height" + height;
        }

        public override float GetX(int k)
        {
            return x - width / 2 * k;
        }

        public override float GetY(int k)
        {
            return y - height / 2 * k;
        }

        public float GetW()
        {
            return width;
        }
        public float GetH()
        {
            return height;
        }
    }
}
