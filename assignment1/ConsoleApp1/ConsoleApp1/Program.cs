namespace ConsoleApp1
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            string s = "";
            double x, y = 0;
            double result = 0;
            while (true)
            {
                Console.WriteLine("请输入第一个运算数：");
                s = Console.ReadLine();
                if (double.TryParse(s, out x)) break;
                else Console.WriteLine("输入的数字无效！");
            }
            while (true)
            {
                Console.WriteLine("请输入第二个运算数：");
                s = Console.ReadLine();
                if (double.TryParse(s, out y)) break;
                else Console.WriteLine("输入数字无效！");
            }
            while(true)
            {
                Console.WriteLine("请输入运算符：");
                s= Console.ReadLine();
                if ((s == "*") || (s == "/") || (s == "+") || (s == "-")) break;
                else Console.WriteLine("输入的运算符无效！");
            }
            switch (s)
            {
                case "+":result = x + y;break;
                case "-":result = x - y;break;
                case "*":result = x * y;break;
                case "/":
                    if (y == 0)
                    {
                        Console.WriteLine("除数不能为0！");
                        return;
                    }
                    else result = x / y;break;  
            }
            Console.WriteLine("结果为："+result);
        }
    }
}
