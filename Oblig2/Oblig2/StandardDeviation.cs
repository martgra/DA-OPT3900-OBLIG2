using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class StandardDeviation
    {
        public static double[] SD(double[] average, int[,] input)
        {
            double[] sd = new double[average.Length];

            for (int i = 0; i < input.GetLength(1); i++)
            {
                for (int j = 0; j < input.GetLength(0); j++)
                {
                    sd[i] = (input[j, i] - average[i])*(input[j, i] - average[i]);
                }
                sd[i] = Math.Sqrt(sd[i]/input.GetLength(0));
            }



            return sd;
        }
    }
}
