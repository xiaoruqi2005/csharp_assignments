namespace assignment2._1
{
    internal class Program
    {
        static Stack<int> OutputPrimeFactors (int num)
        {
            Stack<int> output = new Stack<int>();
            double sqrtNum = Math.Sqrt(num);
            for (int i=2;i<=sqrtNum;i++)
            {
                if(num % i == 0)
                {
                    output.Push(i);
                    while(num % i == 0)
                        num = num / i;
                }
            }
            return output;
        }
        static void Main(string[] args)
        {
            int num;
            while (true) 
            {
                Console.WriteLine("请输入数据：");
                string input = Console.ReadLine();
                if (int.TryParse(input, out num)) break;
                Console.WriteLine("输入数据无效！");
            }
            Stack<int> output = OutputPrimeFactors(num);
            Console.WriteLine("所有素数因子为：");
            foreach (int item in output) Console.WriteLine(item);
        }
    }
}
