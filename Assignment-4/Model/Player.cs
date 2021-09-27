using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Model
{
    public class PlayerModel
    {
        public PlayerModel()
        {            
            for(int i=0; i<4; i++)
            {
                this.Pices[i] = 73;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] Pices { get; set; } = new int[4];

    }
}
