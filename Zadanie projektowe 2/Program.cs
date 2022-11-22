using System.Diagnostics;
using System.Numerics;

namespace Liczby_Pierwsze
{
    public class FirstAlgorithm
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





    public class SecondAlgorithm
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

            for (Int64 divisor = 3; divisor < Math.Sqrt(number); divisor += 2)
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
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        numbers[i], equalOperationCounter,
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






    public class BonusTask
    {
        public static ulong equalOperationCounter;

        static bool IsPrime(BigInteger number)
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

            for (Int64 divisor = 3; divisor < Math.Sqrt((double)number); divisor += 2)
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
            string positiveString = "18870929470561300001893";
            BigInteger posBigInt;
            posBigInt = BigInteger.Parse(positiveString);

            Console.WriteLine("Wykonuje obliczenia .... ");

            equalOperationCounter = 0;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            for (int i = 0; i < 1; i++)
            {
                long startingTime = Stopwatch.GetTimestamp();
                bool linearSearchResult = IsPrime(posBigInt);
                long endingTime = Stopwatch.GetTimestamp();
                long iterationElapsedTime = endingTime - startingTime;

                if (linearSearchResult)
                {
                    Console.WriteLine("{0} jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        posBigInt, equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{posBigInt} NIE jest liczbą pierwszą.");
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
            do
            {
                RunProgram();
                Console.WriteLine();
            }
            while (EndProgram());

            Console.ReadKey();
        }


        static void RunProgram()
        {
            FirstAlgorithm first = new FirstAlgorithm();
            SecondAlgorithm second = new SecondAlgorithm();
            BonusTask bonus = new BonusTask();

            Console.WriteLine("Zadanie projektowe 2 \n"
                + "\n Program sprawdza czy wprowadzone liczby są liczbami pierwszymi:"
                + "\n { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 } \n");

            Console.WriteLine("===========================================\n");

            Console.WriteLine("Jaki algorytm chcesz wybrać?" +
                "\n 1. Podstawowy algorytm sprawdzający każdą liczbę - wybierz 1." +
                "\n 2. Poprawiony algorytm sprawdzający pierwiastek kwadratowy z tej liczby - wybierz 2." +
                "\n 3. Sito Eratosenesa - wybierz 3." +
                "\n 4. Zadanie bonusowe - wybierz 4.");

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    first.CheckIsPrimeNumber();
                    break;
                case 2:
                    second.CheckIsPrimeNumber();
                    break;
                case 3:
                    // SitoEratostanesa();
                    Console.WriteLine("SitoEratostanesa");
                    break;
                case 4:
                    bonus.CheckIsPrimeNumber();
                    break;
            }
        }


        static bool EndProgram()
        {
            string end;
            Console.WriteLine("Czy chcesz zakończyć program? \n" +
                "Tak - naciśnij Enter dwa razy. \n" +
                "Nie - wpisz słowo 'nie'.");
            end = Console.ReadLine();
            Console.WriteLine();
            
            if (end == "nie")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}