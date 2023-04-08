namespace CodeSmells.Exemplos.exemplo3
{
    public abstract class Shape
    {
        protected void ValidateArea(double area)
        {
            if (area < 0)
            {
                throw new InvalidOperationException("Area cannot be negative");
            }
        }
    }

    class Circle2 : Shape
    {
        public double Radius { get; set; }

        public double CalculateArea()
        {
            double area = Math.PI * Math.Pow(Radius, 2);

            ValidateArea(area);

            return area;
        }
    }

    class Square2 : Shape
    {
        public double SideLength { get; set; }

        public double CalculateArea()
        {
            double area = Math.Pow(SideLength, 2);

            ValidateArea(area);

            return area;
        }
    }
}
