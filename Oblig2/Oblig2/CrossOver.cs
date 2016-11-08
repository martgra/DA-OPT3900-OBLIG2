using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class CrossOver
    {
        public static int[][] TwoPointCrossover(int [][] pairs)
        {
            int [][] newGeneration = new int [pairs.Length*2][];

            for (int k = 0; k < pairs.Length; k++)
            {
                newGeneration[k] = new int[pairs[0].Length];
                newGeneration[k + pairs.Length] = new int[pairs[0].Length];
                for (int j = 0; j < pairs[1].Length; j++)
                {
                    
                    newGeneration[k][j] = pairs[k][j];
                    newGeneration[k + pairs.Length][j] = pairs[k][j];
                }
            }
            

            Random rnd = new Random();

            for (int i = pairs.Length; i < newGeneration.Length - 1; i += 2)
            {

                int firstPoint = rnd.Next(0, pairs[0].Length - 1);
                int secondPoint = rnd.Next(firstPoint, pairs[0].Length - 1);
                for (int j = firstPoint; j <= secondPoint; j++)
                {
                    newGeneration[i][j] = newGeneration[(i+1)-pairs.Length][j];
                    newGeneration[i + 1][j] = newGeneration[i-pairs.Length][j];
                }



            }

            return newGeneration;
        }
    }
}
