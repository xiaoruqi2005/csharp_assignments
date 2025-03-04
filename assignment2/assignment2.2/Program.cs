namespace assignment2._2
{
    internal class Program
    {
        static double[] CalculateValues(List<int> nums)
        {
            int maxNum = nums[0], minNum = nums[0],sum = nums[0];
            for(int i = 1; i < nums.Count; i++)
            {
                sum += nums[i];
                if (maxNum < nums[i])
                    maxNum = nums[i];
                if(minNum > nums[i])
                    minNum = nums[i];
            }
            double averageValue = sum / nums.Count;
            double []values = { maxNum, minNum, averageValue, sum };
            return values;
        }
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //int intNum;
            //while (true)
            //{
            //    Console.WriteLine("请输入数组元素个数：");
            //    if (int.TryParse(input, out intNum)) break;
            //    Console.WriteLine("输入无效!");
            //}
            //int[] nums = new int[intNum];
            //for(int i = 0;)
            List<int> nums = new List<int>();
            Console.WriteLine("请输入一行数字，用空格分隔：");
            string input=Console.ReadLine();
            string[] inputs = input.Split(' ');
            foreach (string s in inputs)
            {
                if (!int.TryParse(s, out int val))
                {
                    Console.WriteLine("输入错误！");
                    return;
                }
                else nums.Add(val);
            }
           double[] results=CalculateValues(nums);
            Console.WriteLine("最大值：" + results[0]);
            Console.WriteLine("最小值：" + results[1]);
            Console.WriteLine("平均值：" + results[2]);
            Console.WriteLine("和：" + results[3]);

        }
    }
}
