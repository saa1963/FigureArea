namespace FigureArea
{
    public struct Triangle : IFigureArea
    {
        private double a;
        private double b;
        private double c;
        private (double, double)? cathetus = null;
        public static Triangle Create(double a, double b, double c, double precision = 0.001)
        {
            if (a <= 0 || b <= 0 || c <= 0) throw new ArgumentException("Negative argument");
            if (a > b + c || b > a + c || c > a + b) throw new ArgumentException("Invalid triangle inequality");
            if (precision <= 0 || precision >= 1) throw new ArgumentException("Precision must be between 0 and 1");
            (double, double)? cathetus = null;
            if (a > b && a > c && (a * a - b * b - c * c) < precision) cathetus = (b, c);
            if (b > a && b > c && (b * b - a * a - c * c) < precision) cathetus = (a, c);
            if (c > a && c > b && (c * c - a * a - b * b) < precision) cathetus = (a, b);
            return new Triangle(a, b, c, cathetus);
        }
        private Triangle(double a, double b, double c, (double, double)? rightTriangle) 
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.cathetus = rightTriangle;
        }
        public double Calc()
        {
            if (!cathetus.HasValue)
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else
            {
                // for right triangle
                var (c1, c2) = cathetus.Value;
                return c1 * c2 / 2;
            }
        }
    }
}
