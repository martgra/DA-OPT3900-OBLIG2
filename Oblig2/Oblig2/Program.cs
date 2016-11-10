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
    
            int[,] graph = GenerateGraph.genGraph(500, 9);
            int[][] pop = BirthPopulation.makeFirstPopulation(100, graph);
            List<int[]> newGeneration = CreateList.createLinkedList(pop);
            int[][] pairs;
            int[][] birthcontroll = new int [pop.Length*2][];
            int[] popFitness;
            int[][] tinker;
            bool done = false;
            int itterations = 0;
            int teller = 0;
            int currentResult;
            List<int> results = new List<int>();
            int previousResult = 0;
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            while (!done)
            {

                pairs = SelectMates.pairMates(newGeneration);
                birthcontroll = CrossOver.TwoPointCrossover(pairs);
                tinker = Mengele.tinker(birthcontroll);
                popFitness = Fitness.fitness(graph, tinker);
                pop = RankPopulation.rankSort(birthcontroll, popFitness);
                newGeneration = Genocide.killOffWeaklings(pop);
                for (int z = 0; z < popFitness.Length; z++)
                {
                    Console.Write(popFitness[z] + " ");
                }
                Console.WriteLine();

                currentResult = popFitness[0];
                results.Add(popFitness[0]);

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(mydocpath + @"\test.txt", true))
                {
                    file.WriteLine(popFitness[0].ToString());
                }
                    if (currentResult == previousResult)
                    teller++;

                if (teller > 1000)
                {
                    done = true;
                    break;
                }

                if (currentResult != previousResult)
                    teller = 0;

                previousResult = currentResult;
                itterations++;
            }
            Console.WriteLine("Antall itterasjoner" + itterations);
            /*for (int i = 0; i < 20; i++)
     {
         pairs = SelectMates.pairMates(newGeneration);
         birthcontroll = CrossOver.TwoPointCrossover(pairs);
         tinker = Mengele.tinker(birthcontroll);
         popFitness = Fitness.fitness(graph, tinker);
         pop = RankPopulation.rankSort(birthcontroll, popFitness);
         newGeneration = Genocide.killOffWeaklings(pop);
         for (int z = 0; z < popFitness.Length; z++)
         {
             Console.Write(popFitness[z] + " ");
         }
         Console.WriteLine();

     }*/
            Console.ReadLine();

        }
    }
}
