using System;

namespace Task4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = BinaryToDecimal("11110101010101010101011");
            Console.WriteLine(result);
        }

        public static int BinaryToDecimal(string binaryNumber)
        {

            var l= binaryNumber.Length;
            var b = 1;
            var t= 0;


            for (int i = l- 1; i >= 0; i--)
            {
                var num = int.Parse(binaryNumber[i].ToString());
                var r = num * b;
                t += r;
                b = b * 2;
            }

            return t;
        }
    }
}

