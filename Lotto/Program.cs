// using System;

// namespace Lotto
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             int[] lottoNumbers = InitializeLottoNumbers();
//             DisplayArray("Lotto numbers initialized:", lottoNumbers);

//             int[] computerNumbers = GenerateComputerNumbers();
//             // DisplayArray("\nComputer's lotto numbers are:", computerNumbers);

//             int[] userNumbers = GetUserNumbers();
//             DisplayArray("\nYour lotto numbers are:", userNumbers);

//             VerifyNumbers(userNumbers, computerNumbers);

//             DisplayArray("\nComputer's lotto numbers were:", computerNumbers);
//         }

//         static int[] InitializeLottoNumbers()
//         {
//             int[] lottoNumbers = new int[49];
//             for (int i = 0; i < lottoNumbers.Length; i++)
//             {
//                 lottoNumbers[i] = i + 1;
//             }
//             return lottoNumbers;
//         }

//         static int[] GenerateComputerNumbers()
//         {
//             Random rand = new Random();
//             int[] computerNumbers = new int[6];
//             for (int i = 0; i < computerNumbers.Length; i++)
//             {
//                 int randomNumber;
//                 do
//                 {
//                     randomNumber = rand.Next(1, 50);
//                 } while (Array.IndexOf(computerNumbers, randomNumber) != -1);
//                 computerNumbers[i] = randomNumber;
//             }
//             return computerNumbers;
//         }

//         static int[] GetUserNumbers()
//         {
//             int[] userNumbers = new int[6];
//             int count = 0;

//             Console.WriteLine("\nPlease enter your 6 lotto numbers:");
//             while (count < 6)
//             {
//                 Console.WriteLine($"Enter number {count+1} (between 1 and 49):");
//                 int userInput;
//                 if (int.TryParse(Console.ReadLine(), out userInput) && userInput >= 1 && userInput <= 49 && Array.IndexOf(userNumbers, userInput) == -1)
//                 {
//                     userNumbers[count] = userInput;
//                     count++;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid input or duplicate number. Please try again.");
//                 }
//             }
//             return userNumbers;
//         }

//         static void DisplayArray(string message, int[] array)
//         {
//             Console.WriteLine(message);
//             foreach (var number in array)
//             {
//                 Console.Write(number + " ");
//             }
//             Console.WriteLine();
//         }

//         static void VerifyNumbers(int[] userNumbers, int[] computerNumbers)
//         {
//             Console.WriteLine("\nMatching numbers:");
//             int matchCount = 0;

//             foreach (var number in userNumbers)
//             {
//                 if (Array.IndexOf(computerNumbers, number) != -1)
//                 {
//                     Console.Write(number + " ");
//                     matchCount++;
//                 }
//             }

//             if (matchCount == 0)
//             {
//                 Console.WriteLine("No matches found.");
//             }
//             else
//             {
//                 Console.WriteLine($"\nYou have {matchCount} matching number(s)!");

//                 string result = matchCount switch
//                 {
//                     6 => "Jackpot! Congratulations!",
//                     5 => "Great result! Very close to jackpot!",
//                     4 => "Good job! You won a prize!",
//                     3 => "Not bad!",
//                     _ => "Better luck next time!"
//                 };

//                 Console.WriteLine(result);
//             }
//         }
//     }
// }


// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         int [] LottoSchein = new int[49];
//         for (int i = 0; i < LottoSchein.Length; i++)
//         {
//             LottoSchein[i] = i + 1;
//         }
//     }
// }

using System;
using System.Diagnostics;

namespace LottoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Hello, World!");
            int[] meineZahlen = { 1, 12, 34, 45, 7, 11 };

            //Lotto meinlotto = new Lotto(meineZahlen);
            //meinlotto.Ziehen();
            //meinlotto.Treffer(meineZahlen, meinlotto.gezogen);
            int[] meineTreffer = new int[7];
            int meinGeld = 2000;
            stopwatch.Start();
            Random userRandom = new Random();
            for (int i = 0; i < 1000; i++)
            {

                for (int j = 0; j < meineZahlen.Length; j++)
                {
                    int meineZahl = userRandom.Next(1, 50);
                    while (meineZahlen.Contains(meineZahl))
                    {
                        meineZahl = userRandom.Next(1, 50);
                    }
                    meineZahlen[j] = meineZahl;
                }

                Lotto meinlotto = new Lotto(meineZahlen);
                meinGeld = meinGeld - 5;
                switch (meinlotto.anzahlTreffer)
                {
                    case 6:
                        meinGeld = meinGeld + 100000000;
                        break;
                    case 5:
                        meinGeld = meinGeld + 20000;
                        break;
                    case 4:
                        meinGeld = meinGeld + 400;
                        break;
                    case 3:
                        meinGeld = meinGeld + 20;
                        break;
                    default:
                        meinGeld = meinGeld - 5;
                        break;
                }
                meineTreffer[meinlotto.anzahlTreffer]++;

            }
            for (int i = 0; i < meineTreffer.Length; i++)
            {
                Console.WriteLine($"{i:00} Treffer: {meineTreffer[i]} Mal");
            }
            Console.WriteLine($"Der Kontostand ist: {meinGeld}");
            stopwatch.Stop();
            Console.WriteLine($"Zeit: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
