using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoProject
{
    internal class Lotto
    {
        public Lotto()
        {
            Console.WriteLine("Ein Lotto-Object wurde angelegt!");
        }
        public Lotto(int [] userZahlen)
        {
            Console.WriteLine("Ein Lotto-Object wurde angelegt!");
            Console.WriteLine("-------------------------------------------");

            for (int i = 1; i < 50; i++)
            {
                if (userZahlen.Contains(i))
                    {
                    Console.Write($"|>{i:00}< " );
                }
                else
                {
                    Console.Write($"| {i:00}  ");
                }
                if (i % 7 == 0)
                {
                    Console.WriteLine("|\n-------------------------------------------");
                    //Console.WriteLine("-------------------------------------------");

                }
            }
            Ziehen();
            Console.WriteLine($"Anzahl der Treffer ist {Treffer(userZahlen, gezogen)}");
            Console.WriteLine($"\n**********************************\n");

        }
        public int[] gezogen = new int[6];
        public int anzahlTreffer = 0;

        public void Ziehen()
        {
            Random maschine = new Random();
            Console.WriteLine("Gezogen wurden folgende Zahlen:");
            for (int i = 0; i < gezogen.Length; i++)
            {
                int zahl = maschine.Next(1, 50);
                while (gezogen.Contains(zahl))
                {
                    //Console.WriteLine($"Die Zahl {zahl} gibt es schon. Ich versuch es nochmal!");
                    zahl = maschine.Next(1, 50);
                }
                gezogen[i] = zahl;

                Console.Write($"| {zahl} ");
                //Console.WriteLine($"gezogen[{i}] wurde mit {gezogen[i]} belegt");
            }
            Console.WriteLine("|");
        }
        public int Treffer(int[] a, int[] b)
            {
            for (int i = 0; i < a.Length; i++)
            {
               if(b.Contains(a[i]))
                { anzahlTreffer++; }
            }
            return anzahlTreffer;
            }
    }
}
