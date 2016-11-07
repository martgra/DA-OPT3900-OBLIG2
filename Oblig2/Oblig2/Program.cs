using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oblig2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        */
            int[,] graph = GenerateGraph.genGraph(10, 9);

            //Console.WriteLine(PrintGraph.print(graph));


            int[][] pop = BirthPopulation.makeFirstPopulation(graph);

            int[] popFitness = new int[20];

            for (int i = 0; i < popFitness.Length; i++)
            {
                popFitness[i] = Fitness.fitness(graph, pop[i]);
            }

            pop = RankPopulation.rankSort(pop, popFitness);

            /*for (int i = 0; i < popFitness.Length; i++)
            {
                Console.Write(popFitness[i] + " ");
            }*/


            List<int[]> newGeneration = Genocide.killOffWeaklings(pop);
            int[][] pairs = SelectMates.pairMates(newGeneration);
            int[][] birthcontroll = CrossOver.TwoPointCrossover(pairs);
            for (int i = 0; i < popFitness.Length; i++)
            {
                popFitness[i] = Fitness.fitness(graph, birthcontroll[i]);
            }

            pop = RankPopulation.rankSort(pop, popFitness);

            for (int i = 0; i < popFitness.Length; i++)
            {
               Console.Write(popFitness[i] + " ");
            }

            newGeneration = Genocide.killOffWeaklings(pop);





            /* for(int i = 0; i < birthcontroll.Length; i++)
             {
                 for(int j = 0; j < birthcontroll[0].Length; j++)
                 {
                     Console.Write(birthcontroll[i][j]);
                 }
                 Console.WriteLine();
             }*/




            Console.ReadLine();

        }
    }
}
