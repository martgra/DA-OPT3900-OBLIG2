using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class CrossOver
    {
        public static int[][] TwoPointCrossover(int[][] mates)
        {
            int[][] children = new int [mates.Length*2][];
            Array.Copy(mates, children, mates.Length);

            for (int i = 0; i < mates.Length; i+=2)
            {
                children[i+10] = new int[mates[0].Length];
                children[i + 11] = new int[mates[0].Length];
                Array.Copy(mates[i], children[10 + i], mates[0].Length);
                Array.Copy(mates[i+1], children[11 + i], mates[0].Length);
                Random rnd = new Random();
                int firstPoint = rnd.Next(0, mates[0].Length);
                int secondPoint = rnd.Next(firstPoint, mates[0].Length);
                for (int j = firstPoint; j < secondPoint; j++)
                {
                    children[10 + i][j] = mates[i + 1][j];
                    children[11 + i][j] = mates[i][j];
                } 


            }

               

            return children;
        }
    }
}
