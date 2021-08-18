using System;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = LargeSubtraction("100","1");
            Console.WriteLine(result);
        }

        public static string LargeSubtraction(string a, string b)
        {
            var aArray = new int[a.Length];
            var bArray = new int[b.Length];
            string result = string.Empty;
            string revResult = string.Empty;
            int limit = a.Length;
            int aLength = a.Length - 1;
            int bLength = b.Length - 1;
            for (int i = 0; i < a.Length; i++)
            {
                aArray[i]= Convert.ToInt32(a[i].ToString());
            }
            for (int i = 0; i < b.Length; i++)
            {
                bArray[i] = Convert.ToInt32(b[i].ToString());
            }

            for (int i = 0; i < limit; i++)
            {
                if(bLength<0)
                {
                    if(aArray[aLength]<0)
                    {
                        aArray[aLength - 1] -= 1;
                        aArray[aLength] += 10;
                    }
                    result += aArray[aLength];
                }

                else
                {
                    if(aArray[aLength]<bArray[bLength])
                    {
                        aArray[aLength - 1]-=1;
                        aArray[aLength] += 10;
                    }
                    result += aArray[aLength] - bArray[bLength];
                }
                aLength--;
                bLength--;
            }

            for (int i = result.Length-1; i>=0 ; i--)
            {
                revResult += result[i];
            }

            
            return revResult;
        }
    }
}
