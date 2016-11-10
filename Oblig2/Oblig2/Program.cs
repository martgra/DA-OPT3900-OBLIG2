﻿using System;
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
            int[][] pop = BirthPopulation.makeFirstPopulation(graph);
            List<int[]> newGeneration = CreateList.createLinkedList(pop);
            int[][] pairs;
            int[][] birthcontroll = new int [pop.Length*2][];
            int[] popFitness;
            int[][] tinker;
            bool done = false;
            int teller = 0;
            int currentResult;
            int previousResult = 0;

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

                if (currentResult == previousResult)
                    teller++;

                if (teller > 10)
                {
                    done = true;
                    break;
                }

                if (currentResult != previousResult)
                    teller = 0;

                previousResult = currentResult;
            }
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
