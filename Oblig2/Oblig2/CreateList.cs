using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class CreateList
    {
        public static List<int[]> createLinkedList(int[][] sortedGenomes)
        {
            List<int[]> newGeneration = new List<int[]>();

            for (int i = 0; i < sortedGenomes.GetLength(0); i++)
            {
                newGeneration.Add(sortedGenomes[i]);
            }

            return newGeneration;
        }
    }
}
