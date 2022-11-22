using System.Diagnostics;

namespace Liczby_Pierwsze
{
    public class PrimeNumber
    {
        public static ulong equalOperationCounter;

        static bool IsPrime(Int64 number)
        {
            if (number < 2)
            {
                return false;
            }
            if (number < 4)
            {
                return true;
            }
            if (number % 2 == 0)
            {
                return false;
            }

            for (Int64 divisor = 3; divisor < number / 2; divisor += 2)
            {
                equalOperationCounter++;
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void CheckIsPrimeNumber()
        {
            Int64[] numbers = new Int64[] { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };


            equalOperationCounter = 0;
            int iterationsNumber = numbers.Length;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                long startingTime = Stopwatch.GetTimestamp();
                bool linearSearchResult = IsPrime(numbers[i]);
                long endingTime = Stopwatch.GetTimestamp();
                long iterationElapsedTime = endingTime - startingTime;

                if (linearSearchResult)
                {
                    Console.WriteLine("{0} jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]"
                        + "\n cały czas liczę ... ", numbers[i], equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{numbers[i]} NIE jest liczbą pierwszą.");
                }
                elapsedTime += iterationElapsedTime;
                if (iterationElapsedTime < minTime)
                {
                    minTime = iterationElapsedTime;
                }
                if (iterationElapsedTime > maxTime)
                {
                    maxTime = iterationElapsedTime;
                }
            }
            Console.WriteLine();
        }
    }


    public class Program
    {

        static void Main(string[] args)
        {
            RunProgram();

            EndProgram();

            Console.ReadKey();
        }




        static void RunProgram()
        {
            PrimeNumber number = new PrimeNumber();

            Console.WriteLine("Zadanie projektowe 2 \n"
                + "\n Program sprawdza czy wprowadzone liczby są liczbami pierwszymi:"
                + "\n { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 } \n");

            Console.WriteLine("===========================================\n");

            Console.WriteLine("Jaki algorytm chcesz wybrać?" +
                "\n 1. Zwykły, prosty algorytm - wybierz 1." +
                "\n 2. Sito Eratosenesa - wybierz 2.\n");

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    number.CheckIsPrimeNumber();
                    break;
                case 2:
                    // SitoEratostanesa();
                    Console.WriteLine("SitoEratostanesa");
                    break;
            }

        }


        static void EndProgram()
        {
            Console.WriteLine("=============================" +
                "\n Koniec działania progamu." +
                "\n Naciśnij dowolny klawisz, aby zamknąć okno ...");
        }
    }
}