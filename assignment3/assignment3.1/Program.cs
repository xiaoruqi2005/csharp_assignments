namespace assignment3._1
{
    public interface ShapeOperation
    {
        double CalculateArea();
        bool IsValid();
    }
    public abstract class Shape : ShapeOperation
    {
        public abstract double CalculateArea();
        public abstract bool IsValid();
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return IsValid() ? Width * Height : 0;
        }

        public override bool IsValid()
        {
            return Width > 0 && Height > 0;
        }
    }
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
    }
    public class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        public override double CalculateArea()
        {
            double num = (A + B + C) / 2;
            return IsValid() ? Math.Sqrt(num * (num - A) * (num - B) * (num - C)) : 0;
        }

        public override bool IsValid()
        {
            return A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Rectangle rectangle = new Rectangle(3, 4);
            Console.WriteLine($"合法性：{rectangle.IsValid()}, 面积：{rectangle.CalculateArea()}");

            Square square = new Square(5);
            Console.WriteLine($"合法性：{square.IsValid()}, 面积：{square.CalculateArea()}");

            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine($"合法性：{triangle.IsValid()}, 面积：{triangle.CalculateArea()}");
        }
    }
}
