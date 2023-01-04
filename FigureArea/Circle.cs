using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    public struct Circle : IFigureArea
    {
        private double r;
        public static IFigureArea Create(double r)
        {
            if (r <= 0) throw new ArgumentException("r <= 0");
            return new Circle(r);
        }
        private Circle(double r)
        {
            this.r = r;
        }
        public double Calc()
        {
            return Math.PI * r * r; 
        }
    }
}
