using System;
using System.Linq;

namespace Task5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = CountVowels("Hellow World");
            Console.WriteLine(result);
        }

        public static int CountVowels(string aText)
        {
            char[] vowels = new char[] {'a','e','i','o','u'};
            aText = aText.ToLower();
            int count = 0;

            for (int i = 0; i < aText.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if(aText[i]==vowels[j])
                    {
                        count++;
                        
                    }

                }

            }
            return count;
        }
    }
}
