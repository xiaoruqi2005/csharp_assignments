namespace assignment4._1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            for (Node<T> node = head; node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            // int
            GenericList<int> intList = new GenericList<int>();
            for (int x = 1; x <= 10; x++)
            {
                intList.Add(x);
            }

            Console.WriteLine("打印整数链表元素:");
            intList.ForEach(x => Console.WriteLine(x));

            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;

            intList.ForEach(x => {
                if (x > max) max = x;
                if (x < min) min = x;
                sum += x;
            });

            Console.WriteLine($"最大值: {max}");
            Console.WriteLine($"最小值: {min}");
            Console.WriteLine($"总和: {sum}");

            // string
            GenericList<string> strList = new GenericList<string>();
            for (int x = 1; x <= 10; x++)
            {
                string str = "str" + x;
                strList.Add(str);
            }

            Console.WriteLine("打印字符串链表元素:");
            strList.ForEach(s => Console.WriteLine(s));
        }
    }
 
}
