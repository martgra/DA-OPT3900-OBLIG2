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
    int itterasjoner = 4000;
    int[,] graph = GenerateGraph.genGraph(500, 9);
    int[][] pop1 = BirthPopulation.makeFirstPopulation(10, graph);
    int[][] pop2 = CopyArray.CopyArrayLinq(pop1);
    int[][] pop3 = CopyArray.CopyArrayLinq(pop1);
    int[][] pop4 = CopyArray.CopyArrayLinq(pop1);
    int[][] pop5 = CopyArray.CopyArrayLinq(pop1);

            List<int[]> newGeneration1 = CreateList.createLinkedList(pop1);
    List<int[]> newGeneration2 = CreateList.createLinkedList(pop2);
    List<int[]> newGeneration3 = CreateList.createLinkedList(pop3);
    List<int[]> newGeneration4 = CreateList.createLinkedList(pop2);
    List<int[]> newGeneration5 = CreateList.createLinkedList(pop3);

    int[][] pairs1;
    int[][] pairs2;
    int[][] pairs3;
    int[][] pairs4;
    int[][] pairs5;

    int[][] birthcontroll1 = new int [pop1.Length*2][];
    int[][] birthcontroll2 = new int[pop2.Length * 2][];
    int[][] birthcontroll3 = new int[pop3.Length * 2][];
    int[][] birthcontroll4 = new int[pop4.Length * 2][];
    int[][] birthcontroll5 = new int[pop5.Length * 2][];

    int[] popFitness1;
    int[] popFitness2;
    int[] popFitness3;
    int[] popFitness4;
    int[] popFitness5;

    int[][] tinker1;
    int[][] tinker2;
    int[][] tinker3;
    int[][] tinker4;
    int[][] tinker5;

    int result1 = 0;
    int result2 = 0;
    int result3 = 0;
    int result4 = 0;
    int result5 = 0;

            // nr 1
    using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(mydocpath + @"\test1.txt", true))
    {
        file.WriteLine("Antall i populasjon: 10");
        file.WriteLine("Nodenett: 500");
        file.WriteLine("Koblinger: 9");
        file.WriteLine("Sjanse for mutasjoner: 40");
        file.WriteLine("Sjanse for endring av gener: 40");
                file.WriteLine(Fitness.fitness(graph, RankPopulation.rankSort(pop1, Fitness.fitness(graph, pop1)))[0]);

            }
    
    for (int i = 0; i < itterasjoner; i++)
    {
        pairs1 = SelectMates.pairMates(newGeneration1);
        birthcontroll1 = CrossOver.TwoPointCrossover(pairs1);
        tinker1 = Mengele.tinker(60,60, birthcontroll1);
        popFitness1 = Fitness.fitness(graph, tinker1);
        pop1 = RankPopulation.rankSort(birthcontroll1, popFitness1);
        newGeneration1 = Genocide.killOffWeaklings(pop1);
        result1 = result1 + popFitness1[0];



        using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(mydocpath + @"\test1.txt", true))
        {
            file.WriteLine(popFitness1[0].ToString());
        }

    }
    // nr 2
    using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(mydocpath + @"\test2.txt", true))
    {
        file.WriteLine("Antall i populasjon: 10");
        file.WriteLine("Nodenett: 500");
        file.WriteLine("Koblinger: 9");
        file.WriteLine("Sjanse for mutasjoner: 30");
        file.WriteLine("Sjanse for endring av gener: 30");
                file.WriteLine(Fitness.fitness(graph, RankPopulation.rankSort(pop2, Fitness.fitness(graph, pop2)))[0]);

            }

    for (int i = 0; i < itterasjoner; i++)
    {
        pairs2 = SelectMates.pairMates(newGeneration2);
        birthcontroll2 = CrossOver.TwoPointCrossover(pairs2);
        tinker2 = Mengele.tinker(70, 70, birthcontroll2);
        popFitness2 = Fitness.fitness(graph, tinker2);
        pop2 = RankPopulation.rankSort(birthcontroll2, popFitness2);
        newGeneration2 = Genocide.killOffWeaklings(pop2);
        result2 = result2 + popFitness2[0];

        using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(mydocpath + @"\test2.txt", true))
        {
            file.WriteLine(popFitness2[0].ToString());
        }

    }


    //nr3
    using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(mydocpath + @"\test3.txt", true))
    {
        file.WriteLine("Antall i populasjon: 10");
        file.WriteLine("Nodenett: 500");
        file.WriteLine("Koblinger: 9");
        file.WriteLine("Sjanse for mutasjoner: 20");
        file.WriteLine("Sjanse for endring av gener: 20");
                file.WriteLine(Fitness.fitness(graph, RankPopulation.rankSort(pop3, Fitness.fitness(graph, pop3)))[0]);
            }

    for (int i = 0; i < itterasjoner; i++)
    {
        pairs3 = SelectMates.pairMates(newGeneration3);
        birthcontroll3 = CrossOver.TwoPointCrossover(pairs3);
        tinker3 = Mengele.tinker(80, 80, birthcontroll3);
        popFitness3 = Fitness.fitness(graph, tinker3);
        pop3 = RankPopulation.rankSort(birthcontroll3, popFitness3);
        newGeneration3 = Genocide.killOffWeaklings(pop3);
        result3 = result3 + popFitness3[0];

        using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(mydocpath + @"\test3.txt", true))
        {
            file.WriteLine(popFitness3[0].ToString());
        }
    }

    //nr4
    using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(mydocpath + @"\test4.txt", true))
    {
        file.WriteLine("Antall i populasjon: 10");
        file.WriteLine("Nodenett: 500");
        file.WriteLine("Koblinger: 9");
        file.WriteLine("Sjanse for mutasjoner: 10");
        file.WriteLine("Sjanse for endring av gener: 10");
        file.WriteLine(Fitness.fitness(graph, RankPopulation.rankSort(pop4, Fitness.fitness(graph, pop4)))[0]);
    }

    for (int i = 0; i < itterasjoner; i++)
    {
        pairs4 = SelectMates.pairMates(newGeneration4);
        birthcontroll4 = CrossOver.TwoPointCrossover(pairs4);
        tinker4 = Mengele.tinker(90, 90, birthcontroll4);
        popFitness4 = Fitness.fitness(graph, tinker4);
        pop4 = RankPopulation.rankSort(birthcontroll4, popFitness4);
        newGeneration4 = Genocide.killOffWeaklings(pop4);
        result4 = result4 + popFitness4[0];

                using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(mydocpath + @"\test4.txt", true))
        {
            file.WriteLine(popFitness4[0].ToString());
        }
    }


    //nr5
    using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(mydocpath + @"\test5.txt", true))
    {
        file.WriteLine("Antall i populasjon: 10");
        file.WriteLine("Nodenett: 500");
        file.WriteLine("Koblinger: 9");
        file.WriteLine("Sjanse for mutasjoner: 0");
        file.WriteLine("Sjanse for endring av gener: 0");
                file.WriteLine(Fitness.fitness(graph, RankPopulation.rankSort(pop5, Fitness.fitness(graph, pop5)))[0]);

            }

    for (int i = 0; i < itterasjoner; i++)
    {
        pairs5 = SelectMates.pairMates(newGeneration5);
        birthcontroll5 = CrossOver.TwoPointCrossover(pairs5);
        tinker5 = Mengele.tinker(100, 100, birthcontroll5);
        popFitness5 = Fitness.fitness(graph, tinker5);
        pop5 = RankPopulation.rankSort(birthcontroll5, popFitness5);
        newGeneration5 = Genocide.killOffWeaklings(pop5);
        result5 = result5 + popFitness5[0];

                using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(mydocpath + @"\test5.txt", true))
        {
            file.WriteLine(popFitness5[0].ToString());
        }
    }

    /*using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(mydocpath + @"\deskriptiva.txt", true))
    {
                file.WriteLine("gjennomsnitt 1: " + result1/);
                file.WriteLine("gjennomsnitt 2: " + result2/);
                file.WriteLine("gjennomsnitt 3: " + result3/);
                file.WriteLine("gjennomsnitt 4: " + result4/);
                file.WriteLine("gjennomsnitt 5: " + result5/);
    }*/


            Console.ReadLine();

}
}
}
