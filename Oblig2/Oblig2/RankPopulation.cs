using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class RankPopulation
    {
        static int[][] rankSort(int[][] a, int[] c)
        {
            //a = array over node nettverket
            //c = array over fitness

            int[][] ranked = a;
            int[] tmpArr; //for å holde på variabler midlertidig
            int tmp;
            int i, j;

            //klassisk bubblesort
            for (i = 0; i < c.Length; i++)
            {
                //- (i + 1) fordi minste synker alltid til bunn så trengs ikke å bli sjekket mot lenger)
                for (j = 0; j < (c.Length - (i + 1)); j++)
                {
                    if (c[j] < c[j + 1]) //hvis neste i arrayet er større
                    {
                        tmp = c[j + 1];
                        tmpArr = ranked[j + 1];

                        c[j + 1] = c[j];
                        ranked[j + 1] = ranked[j];
                        c[j] = tmp;
                        ranked[j] = tmpArr;
                    }
                }

            }

            return ranked;
        }
    }
}
