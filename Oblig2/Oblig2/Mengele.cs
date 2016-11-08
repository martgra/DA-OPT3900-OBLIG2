using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class Mengele
    {
        public static int [][] tinker(int[][] tinker)
        {
            Random rnd = new Random();

            for(int i = tinker.Length/2; i < tinker.Length; i++)
            {
                if (rnd.Next(0,100) > 80)
                {
                    for (int j = 0; j < tinker[0].Length; j++)
                    {
                        if(rnd.Next(0, 100) > 80)
                        {
                            tinker[i][j] = rnd.Next(0, 3);
                        }
                    }
                }
            }
             


            return tinker;
        }

    }
}
