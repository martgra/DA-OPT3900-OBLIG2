using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class Average
    {
        public static double [] CalcualteAverage(int [,] input)
        {
            double [] average = new double[input.GetLength(1)];

            for (int i = 0; i < input.GetLength(1); i++)
            {
                for (int j = 0; j < input.GetLength(0); j++)
                {
                    average[i] = average[i] + input[j, i];
                }
                average[i] = average[i] / input.GetLength(0);
            }



            return average;
        } 
    }
}
