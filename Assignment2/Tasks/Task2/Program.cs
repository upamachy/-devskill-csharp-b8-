using System;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = StringValue("Hello World");
            Console.WriteLine(result);
            
        }

        public static int StringValue(string aText)
        {
            int value = 0;
            for (int i = 0; i < aText.Length; i++)
            {
              value += (int)aText[i];
            }
            return value;
        }
    }
}
