using System;

namespace DataTypeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray= new int[5];
            double[] doubleArray = new double[5];
            float[] floatArray = new float[5];
            string[] stringArray = new string[5];
            DateTime[] dateTimeArray = new DateTime[5];
            decimal[] decimalArray = new decimal[5];
            long[] longArray = new long[5];
            bool[] boolArray = new bool[5];

            //Let's take the elements for each array

            Console.WriteLine("Enter integer types element for the intArray: ");

            for (int i = 0; i <intArray.Length; i++)
            {
                Console.Write("element - {0} : ", i);
                intArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter Double types element for the doubleArray: ");
            for (int i = 0; i < doubleArray.Length; i++)
            {
                Console.Write("element - {0} : ", i);
                doubleArray[i] = Convert.ToDouble(Console.ReadLine());

            }

            Console.WriteLine("Enter Float types element for the floatArray: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("element - {0} : ", i);
                string input = Console.ReadLine();
                floatArray[i] = float.Parse(input);
                
            }

            Console.WriteLine("Enter String types element for the stringArray: ");
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.Write("element - {0} : ", i);
                stringArray[i] =(Console.ReadLine());

            }

            Console.WriteLine("Enter datetime types element for the dateTimeArray: ");
            for (int i = 0; i < dateTimeArray.Length; i++)
            {
                Console.Write("element - {0} : ", i);
                dateTimeArray[i] = Convert.ToDateTime(Console.ReadLine());

            }

            Console.WriteLine("Enter Decimal types element for the decimalArray: ");
            for (int i = 0; i < decimalArray.Length; i++)
            {
                Console.Write("element - {0} : ", i);
                decimalArray[i] = Convert.ToDecimal(Console.ReadLine());

            }

            Console.WriteLine("Enter long types element for the longArray: ");
            for (int i = 0; i < longArray.Length; i++)
            {
                Console.Write("element - {0} : ", i);
                longArray[i] = Convert.ToInt64(Console.ReadLine());

            }

            Console.WriteLine("Enter boolean types element for the boolArray: ");
            for (int i = 0; i < boolArray.Length; i++)
            {
                Console.Write("element - {0} : ", i);
                boolArray[i] = Convert.ToBoolean(Console.ReadLine());

            }

        }
    }
}
