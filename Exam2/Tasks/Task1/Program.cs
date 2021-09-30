using System;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = Formatter((d) => $"%{d.Date.Day}%");
            Console.WriteLine(result);
        }

        public static string Formatter(Func<DateTime, string> converter)
        {
            return converter(DateTime.Now);
        }
    }
}
