using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class SelectMates
    {
        public static int[][] pairMates(List<int[]> population)
        {
            
            int mateOne;
            int mateTwo;
            int j = population.Count;
            int [][] mates = new int [j][];

            //select random parent one from population
            Random rnd = new Random();
            
            for (int i = 0; i < j; i+=2)
            {
                //velger tilfeldig mate 1 fra gjenstående populasjon, fjerner denne etterpå.
                mateOne = rnd.Next(0, population.Count);
                mates[i] = population[mateOne];
                population.RemoveAt(mateOne);

                //velger tildelig mate 2 fra gjenstående populasjon, fjerner denne etterpå.
                mateTwo = rnd.Next(0, population.Count);
                mates[i+1] = population[mateTwo];
                population.RemoveAt(mateTwo);
            }

            //return pairs of mates
            return mates;
        }
    }
}
