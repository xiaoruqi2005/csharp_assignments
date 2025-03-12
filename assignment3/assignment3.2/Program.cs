namespace assignment3._2
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
    // 简单工厂类
    public static class ShapeFactory
    {
        private static Random random = new Random();

        public static ShapeOperation CreateRandomShape()
        {
            int shapeType = random.Next(3); // 0: 长方形, 1: 正方形, 2: 三角形

            switch (shapeType)
            {
                case 0: 
                    double width = random.Next(1, 11); 
                    double height = random.Next(1, 11);
                    return new Rectangle(width, height);
                case 1: 
                    double side = random.Next(1, 11);
                    return new Square(side);
                case 2: 
                    double a = random.Next(1, 11);
                    double b = random.Next(1, 11);
                    double c = random.Next(1, 11);
                    return new Triangle(a, b, c);
                default:
                    throw new ArgumentException("未知的形状类型");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<ShapeOperation> shapes = new List<ShapeOperation>();
            double totalArea = 0;

            for (int i = 0; i < 10; i++)
            {
                ShapeOperation shape = ShapeFactory.CreateRandomShape();
                Console.WriteLine($"形状 {i + 1}: {shape.GetType().Name}");
                switch (shape.GetType().Name)
                {
                    case "Rectangle":
                        Rectangle rec = (Rectangle)shape;
                        Console.WriteLine($"宽和高分别为：{rec.Width},{rec.Height}");
                        break;
                    case "Square":
                        Square squ=(Square)shape;
                        Console.WriteLine($"边长为：{squ.Width}");
                        break;
                    case "Triangle":
                        Triangle tri=(Triangle)shape;
                        Console.WriteLine($"三边长分别为：{tri.A},{tri.B},{tri.C}");
                        break;
                }
                if (shape.IsValid())
                {
                    shapes.Add(shape);
                    totalArea += shape.CalculateArea();
                    Console.WriteLine($"面积: {shape.CalculateArea():F2}");
                }
                else
                {
                    Console.WriteLine($"形状不合法.");
                }
            }

            Console.WriteLine($"\n有效总面积: {totalArea:F2}");
        }
    }
}
