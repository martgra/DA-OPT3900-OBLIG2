using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class PrintGraph
    {
        static string print(int[,] graph)
        {
            int i, j;

            string tekst = "";

            for (i = 0; i < graph.GetLength(0); i++)
            {
                for (j = 0; j < graph.GetLength(1); j++)
                {
                    tekst += graph[i, j] + "\t";
                }

                tekst += "\n";
            }

            return tekst;

        }
    }
}
