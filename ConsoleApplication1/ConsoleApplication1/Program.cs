using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = genGraph(10, 9);




            Console.WriteLine(print(graph));


            int[][] pop = makeFirstPopulation(graph);

            int[] popFitness = new int[10];

            for (int i = 0; i < popFitness.Length; i++)
            {
                popFitness[i] = fitness(graph, pop[i]);
            }

            pop = rankSort(pop, popFitness);

            for (int i = 0; i < popFitness.Length; i++)
            {
                Console.Write(popFitness[i] + " ");
            }

            Console.ReadLine();

        }

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

        static int[,] genGraph(int size, int mN)
        {
            int[,] nodes = new int[size, mN]; //node-nettet, size er antall noder, mN er maks naboer

            bool[,] filled = new bool[size, mN]; //representerer hvilke koblinger som er fylt

            int i, j, k;

            int teller = 0; //for antall ganger det skal prøves ny node om det ikke fungerer

            int tom; //variabel som blir random'a, bestemmer om det blir -1 eller koblet til en node

            bool fine = false; //fine og set er kriterier for while løkker
            bool set = false;

            Random rnd = new Random();

            for (i = 0; i < size; i++)
            {
                for (j = 0; j < mN; j++)
                {
                    filled[i, j] = false; //fyller 2d array slik at ingen nabo-koblinger er satt som fylt
                }
            }


            for (i = 0; i < size; i++) //overarching; en gang for hver node
            {
                for (j = 0; j < mN; j++) // en gang per kobling per node
                {
                    if (filled[i, j] == false) //hvis koblingen ikke er fylt
                    {
                        while (!set) //til set blir sann
                        {
                            if (j == 0) //hvis det er den første koblingen til en node (forsikrer at alle er koblet til minst en)
                            {
                                nodes[i, j] = rnd.Next(0, size); //velger en tilfeldig node å koble til

                                if (nodes[i, j] == i) //hvis noden kobles til seg selv
                                    continue; //gå til neste iterasjon av løkken while(!set)
                            }

                            else
                            {
                                tom = rnd.Next(0, 5); //tom for en verdi fra og med 0 til og med 4 

                                if (tom < 3) //hvis tom ble 0,1,2
                                {
                                    while (!fine) //til fine blir sann
                                    {
                                        nodes[i, j] = rnd.Next(0, size); //velger en tilfeldig node å koble til

                                        for (k = 0; k <= j; k++) //sjekker at node i ikke har blitt koblet til den valgte noden fra før
                                        {                        //for fra 0 til j fordi en node har ikke satt flere koblinger en opp til j

                                            if (k == j) //hvis for løkken har nådd enden betyr det at ingen av koblingene er like
                                                fine = true; //kriteriet til løkka blir nådd

                                            if (nodes[i, k] == nodes[i, j]) //hvis den nye koblingen er lik en gammel
                                                break; //bryt forløkka og start neste iterasjon av while(!fine)
                                        }
                                    }

                                    fine = false; //setter fine false for neste gang while(!fine) skal kjøre

                                    if (nodes[i, j] == i) //hvis noden kobles til seg selv
                                        continue; //gå til neste iterasjon av løkken while(!set)
                                }

                                else
                                {
                                    nodes[i, j] = -1; //koblingen har blitt bestemt tom (ingen kobling)

                                    set = true; //kriteriet for løkken while(!set) er møtt (koblingen er satt (tom)) 
                                    continue; //gå til neste iterasjon av løkken while(!set) (som nå er ferdig)
                                    //merk at koblingen ikke blir satt som fylt, som tillater for at senere noder kan kobles bakover i en viss grad
                                    //dette øker sjansen for at tidligere koblinger blir mer fylt enn senere noder
                                    //siden alt fremdeles er tilfeldig er ikke dette et problem, men nettverket blir ikke helt balensert
                                    //å sette koblingen til fylt kan ha liknenes effekt andre veien i stedet

                                    //filled[i,j] = true;
                                }
                            }

                            if (filled[nodes[i, j], (mN - 1)] == false) //hvis en kobling er valgt må det forsikres at den har en ufylt kobling
                            {
                                for (k = 0; k < mN; k++)
                                {
                                    if (filled[nodes[i, j], k] == false) //første ufylt kobling er funnet
                                    {
                                        nodes[nodes[i, j], k] = i;
                                        filled[nodes[i, j], k] = true; //koblingen til noden som blir koblet til er satt som fylt
                                        filled[i, j] = true; //koblingn til noed som blir koblet fra er satt som fylt
                                        set = true; //kriteriet for while(!set) er nådd
                                        break; //bryt ut av for-løkka
                                    }
                                }
                            }

                            teller++; //hvis denne blir nådd, har ikke det blitt satt en gyldig kobling

                            if (teller > 100) //antall ganger det skal forsøker å sette en kobling
                            {
                                set = true;
                                nodes[i, j] = -1; //koblingen har blitt bestemt tom (ingen kobling)
                                //filled[i, j] = true;
                            }

                        }

                        set = false; //setter set false for neste gang while(!set) skal kjøre
                        teller = 0; //setter teller til 0 slik at nye forsøk kan gjøres for neste node
                    }
                }
            }

            return nodes;
        }

        static int fitness(int[,] nodeNet, int[] color)
        {

            //nodeNet = array over node nettverket
            //color = array over verdien hver node har

            int score = 0; //fitness verdien for nettverket

            int i, j;

            for (i = 0; i < nodeNet.GetLength(0); i++)
            {
                for (j = 0; j < nodeNet.GetLength(1); j++)
                {
                    if (nodeNet[i, j] != -1)
                    {
                        if (color[i] != color[nodeNet[i, j]]) //hvis verdien til noden er ulik verdien til noden den er koblet til
                            score++;
                    }
                }
            }

            //ettersom node x er koblet til y; er y koblet til x, så det vil telles dobbelt opp
            score = score / 2;

            return score;
        }


        static int[][] rankSort(int[][] a, int[] c)
        {
            //a = array over node nettverket
            //c = array over fitness

            int[][] ranked = a;
            int[] tmpArr; //for å holde på variabler midlertidig
            int tmp;
            int i, j;

            //klassisk bubblesort
            for (i = 0; i < c.Length; i++)
            {
                //- (i + 1) fordi minste synker alltid til bunn så trengs ikke å bli sjekket mot lenger)
                for (j = 0; j < (c.Length - (i + 1)); j++)
                {
                    if (c[j] < c[j + 1]) //hvis neste i arrayet er større
                    {
                        tmp = c[j + 1];
                        tmpArr = ranked[j + 1];

                        c[j + 1] = c[j];
                        ranked[j + 1] = ranked[j];
                        c[j] = tmp;
                        ranked[j] = tmpArr;
                    }
                }

            }

            return ranked;
        }


        static int[][] makeFirstPopulation(int[,] nodeNet)
        {
            int initialPopSize = 10;
            int nodeAmount = nodeNet.GetLength(0); //minst 500 som krav fra oppgaven
            int[][] population = new int[initialPopSize * 2][]; //*2 for å sikkre partall
            int i, j;

            Random color = new Random();

            for (i = 0; i < initialPopSize * 2; i++)
            {
                population[i] = new int[nodeAmount];

                for (j = 0; j < nodeAmount; j++)
                {
                    if (i < initialPopSize) //for de 10 første
                    {
                        population[i][j] = color.Next(0, 3); //0 = svart, 1 = hvit, 2 = rød
                    }
                }
            }

            return population;
        }
    }
}
