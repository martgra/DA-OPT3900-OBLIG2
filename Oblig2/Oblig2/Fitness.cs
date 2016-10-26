using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class Fitness
    {
        static void Main(string[] args)
        {
        }

        static int fitness(int[,] a, int[] b) //int[][] a hvis ararry av arrays
        {

            //a = array over node nettverket
            //b = array over verdien hver node har

            int score = 0; //fitness verdien for nettverket

            int i, j;

            for (i = 0; i < a.GetLength(0); i++) //a.Length;
            {
                for (j = 0; j < a.GetLength(1); j++) //a[0].Length;
                {
                    if (b[i] != b[a[i, j]]) //hvis verdien til noden er ulik verdien til noden den er koblet til
                        score++;
                }
            }

            //ettersom node x er koblet til y; er y koblet til x, så det vil telles dobbelt opp
            score = score / 2;

            return score;
        }

        static int[,] rankSort(int[,] a, int[] c) //static int[][] rankSort(int[][] a, int[] c)
        {
            //a = array over node nettverket
            //c = array over fitness

            int[,] ranked = a;
            //int[][] ranked = a;
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
                        //tmpArr = ranked[j + 1];

                        c[j + 1] = c[j];
                        //ranked[j + 1] = ranked[j];
                        c[j] = tmp;
                        //ranked[j] = tmpArr;
                    }
                }

            }

            return ranked;
        }
    }
