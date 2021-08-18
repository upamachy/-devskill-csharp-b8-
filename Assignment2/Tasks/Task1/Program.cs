using System;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = IsPrime(19);
            Console.WriteLine(result);
        }

        public static bool IsPrime(int number)
        {
            bool a=true;

            for (int i = 2; i < number; i++)
            {
                if(number%i==0)
                {
                    a= false;
                    break;
                }
                    
            }
            if (number < 2)
            {
                 return false;
            }
            else
                return a;
            
               
            
               


            
        }
    }
}
