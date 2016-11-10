using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class BirthPopulation
    {
        public static int[][] makeFirstPopulation(int[,] nodeNet)
        {
            int initialPopSize = 10;
            int nodeAmount = nodeNet.GetLength(0); //minst 500 som krav fra oppgaven
            int[][] population = new int[initialPopSize][]; //*2 for å sikkre partall
            int i, j;

            Random color = new Random();

            for (i = 0; i < initialPopSize; i++)
            {
                population[i] = new int[nodeAmount];

                for (j = 0; j < nodeAmount; j++)
                {
                    if (i < initialPopSize/2) //for de 10 første
                    {
                        population[i][j] = color.Next(0, 3); //0 = svart, 1 = hvit, 2 = rød
                    }
                }
            }

            return population;
        }
    }
}