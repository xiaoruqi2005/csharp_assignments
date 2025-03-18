using System;
using System.Threading;
namespace assignment4._2
{
    class Clock
    {
        public event Action Tick;
        public event Action Alarm;

        private int alarmTime; 

        public Clock(int time)
        {
            alarmTime = time;
        }

        public void AlarmStart()
        {
            int currentTime = 0;
            while (currentTime <= alarmTime)
            {
                Thread.Sleep(1000); 
                Tick?.Invoke(); 
                currentTime++;
                if (currentTime == alarmTime)
                {
                    Alarm?.Invoke();
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------开始-------------");
            //5s示例
            Clock clock = new Clock(5);
            clock.Tick += () => Console.WriteLine("滴嗒");
            clock.Alarm += () => Console.WriteLine("闹钟响了！");
            clock.AlarmStart();
        }
    }
}
