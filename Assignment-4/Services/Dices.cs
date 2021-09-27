using Assignment_4.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Services
{
    public class Dices : IDice
    {
        public int start { get; set; }
        public int end { get; set; }

        

        public int GetDiceNumber()
        {
            Random random = new Random();
            int n = random.Next(1, 7);
            return n;
        }
    }
}
