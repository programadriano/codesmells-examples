namespace CodeSmells.Exemplos.exemplo3
{
    class Circle
    {
        public double Radius { get; set; }

        public double CalculateArea()
        {
            double area = Math.PI * Math.Pow(Radius, 2);

            if (area < 0)
            {
                throw new InvalidOperationException("Area cannot be negative");
            }

            return area;
        }
    }

    class Square
    {
        public double SideLength { get; set; }

        public double CalculateArea()
        {
            double area = Math.Pow(SideLength, 2);

            if (area < 0)
            {
                throw new InvalidOperationException("Area cannot be negative");
            }

            return area;
        }
    }
}
