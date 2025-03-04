namespace assignment2._3
{
    internal class Program
    {
        static List<int> allPrime(int n)
        {
            List<int> result = new List<int>();
            List<bool> isPrime = Enumerable.Repeat(true, n+1).ToList();  //易错：List<bool> isPrime= new List<bool>(n+1);

            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = 2; j * i <= n; j++)
                        isPrime[j * i] = false;
                    result.Add(i);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("2-100以内的素数有：");
            List<int> result = allPrime(100);
            foreach(int i in result)
                Console.WriteLine(i);
        }
    }
}
