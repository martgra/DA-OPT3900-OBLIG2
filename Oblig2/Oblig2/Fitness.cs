using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class Fitness
    {


        public static int [] fitness(int[,] nodeNet, int[][] color)
        {

            //nodeNet = array over node nettverket
            //color = array over verdien hver node har

            int [] score = new int[color.GetLength(0)]; //fitness verdien for nettverket
            for (int h = 0; h < color.Length; h++)
            {

                for (int i = 0; i < nodeNet.GetLength(0); i++)
                {
                    for (int j = 0; j < nodeNet.GetLength(1); j++)
                    {
                        if (nodeNet[i, j] != -1)
                        {
                            if (color[h][i] != color[h][nodeNet[i, j]]) //hvis verdien til noden er ulik verdien til noden den er koblet til
                                score[h]++;
                        }
                    }
                }
                score[h] = score[h] / 2;
            }

            //ettersom node x er koblet til y; er y koblet til x, så det vil telles dobbelt opp
            

            return score;
        }
    }
}
