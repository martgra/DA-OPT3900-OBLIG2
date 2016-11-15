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



            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            int itterasjoner = 20000;
            int repetisjoner = 200;
            /*int[,] descriptives1 = new int[repetisjoner, itterasjoner+1];
            int[,] descriptives2 = new int[repetisjoner, itterasjoner+1];
            int[,] descriptives3 = new int[repetisjoner, itterasjoner+1];
            int[,] descriptives4 = new int[repetisjoner, itterasjoner+1];
            int[,] descriptives5 = new int[repetisjoner, itterasjoner+1];*/
            int[,] descriptives6 = new int[repetisjoner, itterasjoner + 1];

            for (int x = 0; x < repetisjoner; x++)
            {
                int[,] graph = GenerateGraph.genGraph(500, 9);
                int[][] pop1 = BirthPopulation.makeFirstPopulation(10, graph);
               /* int[][] pop2 = CopyArray.CopyArrayLinq(pop1);
                int[][] pop3 = CopyArray.CopyArrayLinq(pop1);
                int[][] pop4 = CopyArray.CopyArrayLinq(pop1);
                int[][] pop5 = CopyArray.CopyArrayLinq(pop1);*/
                int[][] pop6 = CopyArray.CopyArrayLinq(pop1);
/*
                List<int[]> newGeneration1 = CreateList.createLinkedList(pop1);
                List<int[]> newGeneration2 = CreateList.createLinkedList(pop2);
                List<int[]> newGeneration3 = CreateList.createLinkedList(pop3);
                List<int[]> newGeneration4 = CreateList.createLinkedList(pop4);
                List<int[]> newGeneration5 = CreateList.createLinkedList(pop5);
               

                int[][] pairs1;
                int[][] pairs2;
                int[][] pairs3;
                int[][] pairs4;
                int[][] pairs5;
               

                int[][] birthcontroll1 = new int[pop1.Length * 2][];
                int[][] birthcontroll2 = new int[pop2.Length * 2][];
                int[][] birthcontroll3 = new int[pop3.Length * 2][];
                int[][] birthcontroll4 = new int[pop4.Length * 2][];
                int[][] birthcontroll5 = new int[pop5.Length * 2][];
               

                int[] popFitness1;
                int[] popFitness2;
                int[] popFitness3;
                int[] popFitness4;
                int[] popFitness5;*/
                int[] popFitness6;

                /*
                int[][] tinker1;
                int[][] tinker2;
                int[][] tinker3;
                int[][] tinker4;
                int[][] tinker5;
            

                int result1 = 0;
                int result2 = 0;
                int result3 = 0;
                int result4 = 0;
                int result5 = 0;*/



               /*

                // nr 1
                descriptives1[x, 0] = Fitness.fitness(graph, RankPopulation.rankSort(pop1, Fitness.fitness(graph, pop1)))[0];
                for (int i = 0; i < itterasjoner; i++)
                {
                    pairs1 = SelectMates.pairMates(newGeneration1);
                    birthcontroll1 = CrossOver.TwoPointCrossover(pairs1);
                    tinker1 = Mengele.tinker(60, 60, birthcontroll1);
                    popFitness1 = Fitness.fitness(graph, tinker1);
                    pop1 = RankPopulation.rankSort(birthcontroll1, popFitness1);
                    newGeneration1 = Genocide.killOffWeaklings(pop1);
                    result1 = result1 + popFitness1[0];
                    descriptives1[x, i+1] = popFitness1[0];
            
                }

                // nr 2
          
                descriptives2[x, 0] = Fitness.fitness(graph, RankPopulation.rankSort(pop2, Fitness.fitness(graph, pop2)))[0];
                for (int i = 0; i < itterasjoner; i++)
                {
                    pairs2 = SelectMates.pairMates(newGeneration2);
                    birthcontroll2 = CrossOver.TwoPointCrossover(pairs2);
                    tinker2 = Mengele.tinker(70, 70, birthcontroll2);
                    popFitness2 = Fitness.fitness(graph, tinker2);
                    pop2 = RankPopulation.rankSort(birthcontroll2, popFitness2);
                    newGeneration2 = Genocide.killOffWeaklings(pop2);
                    result2 = result2 + popFitness2[0];
                    descriptives2[x, i+1] = popFitness2[0];

                }


                //nr3
       
                descriptives3[x, 0] = Fitness.fitness(graph, RankPopulation.rankSort(pop3, Fitness.fitness(graph, pop3)))[0];
                for (int i = 0; i < itterasjoner; i++)
                {
                    pairs3 = SelectMates.pairMates(newGeneration3);
                    birthcontroll3 = CrossOver.TwoPointCrossover(pairs3);
                    tinker3 = Mengele.tinker(80, 80, birthcontroll3);
                    popFitness3 = Fitness.fitness(graph, tinker3);
                    pop3 = RankPopulation.rankSort(birthcontroll3, popFitness3);
                    newGeneration3 = Genocide.killOffWeaklings(pop3);
                    result3 = result3 + popFitness3[0];
                    descriptives3[x, i+1] = popFitness3[0];

            
                }

                //nr4 
     
                descriptives4[x, 0] = Fitness.fitness(graph, RankPopulation.rankSort(pop4, Fitness.fitness(graph, pop4)))[0];
                for (int i = 0; i < itterasjoner; i++)
                {
                    pairs4 = SelectMates.pairMates(newGeneration4);
                    birthcontroll4 = CrossOver.TwoPointCrossover(pairs4);
                    tinker4 = Mengele.tinker(90, 90, birthcontroll4);
                    popFitness4 = Fitness.fitness(graph, tinker4);
                    pop4 = RankPopulation.rankSort(birthcontroll4, popFitness4);
                    newGeneration4 = Genocide.killOffWeaklings(pop4);
                    result4 = result4 + popFitness4[0];
                    descriptives4[x, i+1] = popFitness4[0];

                }


                //nr5
         
                descriptives5[x, 0] = Fitness.fitness(graph, RankPopulation.rankSort(pop5, Fitness.fitness(graph, pop5)))[0];
                for (int i = 0; i < itterasjoner; i++)
                {
                    pairs5 = SelectMates.pairMates(newGeneration5);
                    birthcontroll5 = CrossOver.TwoPointCrossover(pairs5);
                    tinker5 = Mengele.tinker(100, 100, birthcontroll5);
                    popFitness5 = Fitness.fitness(graph, tinker5);
                    pop5 = RankPopulation.rankSort(birthcontroll5, popFitness5);
                    newGeneration5 = Genocide.killOffWeaklings(pop5);
                    result5 = result5 + popFitness5[0];
                    descriptives5[x, i+1] = popFitness5[0];

               
                }*/

                //nr 6 random
                descriptives6[x, 0] = Fitness.fitness(graph, RankPopulation.rankSort(pop6, Fitness.fitness(graph, pop6)))[0];
                for (int i = 0; i < itterasjoner; i++)
                {
                    pop6 = BirthPopulation.makeFirstPopulation(10, graph);
                    popFitness6 = Fitness.fitness(graph, pop6);
                    pop6 = RankPopulation.rankSort(pop6, popFitness6);
                    popFitness6 = Fitness.fitness(graph, pop6);
                    if (descriptives6[x, i] < popFitness6[0])
                    {
                        descriptives6[x, i + 1] = popFitness6[0];
                    }
                    else
                    {
                        descriptives6[x, i + 1] = descriptives6[x, i];
                    }

                }
            }



            /*double[] average1 = Average.CalcualteAverage(descriptives1);
            double[] average2 = Average.CalcualteAverage(descriptives2);
            double[] average3 = Average.CalcualteAverage(descriptives3);
            double[] average4 = Average.CalcualteAverage(descriptives4);
            double[] average5 = Average.CalcualteAverage(descriptives5);

            double[] sd1 = StandardDeviation.SD(average1, descriptives1);
            double[] sd2 = StandardDeviation.SD(average2, descriptives2);
            double[] sd3 = StandardDeviation.SD(average3, descriptives3);
            double[] sd4 = StandardDeviation.SD(average4, descriptives4);
            double[] sd5 = StandardDeviation.SD(average5, descriptives5);*/

            double[] average6 = Average.CalcualteAverage(descriptives6);
            double[] sd6 = StandardDeviation.SD(average6, descriptives6);

            for (int z = 0; z < average6.Length; z++)
            {/*
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\average1.txt", true))
            {
                file.WriteLine(average1[z]);
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\sd1.txt", true))
            {
                file.WriteLine(sd1[z]);
            }

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\average2.txt", true))
            {
                file.WriteLine(average2[z]);
            }

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\sd2.txt", true))
            {
                 file.WriteLine(sd2[z]);
            }
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\average3.txt", true))
            {
                file.WriteLine(average3[z]);
            }

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\sd3.txt", true))
                {
                    file.WriteLine(sd3[z]);
                }
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\average4.txt", true))
            {
                file.WriteLine(average4[z]);
            }

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\sd4.txt", true))
                {
                    file.WriteLine(sd4[z]);
                }
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\average5.txt", true))
            {
                file.WriteLine(average5[z]);
            }
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(mydocpath + @"\sd5.txt", true))
                {
                    file.WriteLine(sd5[z]);
                }

                */
                using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(mydocpath + @"\average6.txt", true))
                {
                    file.WriteLine(average6[z]);
                }
                using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(mydocpath + @"\sd6.txt", true))
                {
                    file.WriteLine(sd6[z]);
                }

            }
            

            Console.ReadLine();

        }
    }
}
