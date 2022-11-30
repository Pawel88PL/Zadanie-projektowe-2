using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

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
                    Console.WriteLine("Liczba {0} jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]"
                        + "\n cały czas liczę ... ", numbers[i], equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Liczba {0} NIE jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]"
                        + "\n cały czas liczę ... ", numbers[i], equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
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
                    Console.WriteLine("Liczba {0} jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        numbers[i], equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Liczba {0} NIE jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        numbers[i], equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
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






    public class SitoEratostenesa
    {
        private static ulong equalOperationCounter;

        static bool LinearSearch(Int64[] vector, Int64 number)
        {
            for (Int64 i = 0; i < vector.Length; i++)
            {
                equalOperationCounter++;
                if (vector[i] == number)
                {
                    return true;
                }
            }
            return false;
        }


        public void CheckIsPrimeNumber()
        {
            Int64[] numbers = new Int64[] { 100913, 1009139, 10091401, 100914061 };
            Int64[] tab = new Int64[101000000];
            Int64 range = tab.Length - 1;
            Int64 sqrt = (int)Math.Floor(Math.Sqrt(range));

            for (Int64 i = 1; i <= range; i++)
            {
                tab[i] = i;
            }

            for (Int64 i = 2; i <= sqrt; i++)
            {
                if (tab[i] != 0)
                {
                    Int64 j = i + i;
                    while (j <= range)
                    {
                        tab[j] = 0;
                        j += i;
                    }
                }
            }


            equalOperationCounter = 0;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                long startingTime = Stopwatch.GetTimestamp();
                bool linearSearchResult = LinearSearch(tab, numbers[i]);
                long endingTime = Stopwatch.GetTimestamp();
                long iterationElapsedTime = endingTime - startingTime;

                if (linearSearchResult)
                {
                    Console.WriteLine("Liczba {0} jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        numbers[i], equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Liczba {0} NIE jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        numbers[i], equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
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



            Console.WriteLine("Czy chcesz wyświetlić tablicę liczb pierwszych? T / N");
            string choice = Console.ReadLine();

            if (choice == "t")
            {
                Console.WriteLine("Liczby pierwsze z zakresu od 1 do 10 000 to:");
                for (int i = 2; i <= 10000; i++)
                {
                    if (tab[i] != 0)
                    {
                        Console.Write(i + ", ");
                    }

                }
                Console.WriteLine();
            }
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

            Console.WriteLine("Zadanie bonusowe:" +
                "\n sprawdzenie liczby 18870929470561300001893 czy jest liczbą pierwszą." +
                "\n Wykonuje obliczenia, trochę to potrwa :) .... ");

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
                    Console.WriteLine("Liczba {0} jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        posBigInt, equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Liczba {0} NIE jest liczbą pierwszą."
                        + "\n Ilość wykonanych obliczeń sprawdzających: {1}"
                        + "\n Czas wykonania obliczeń: {2} [s]",
                        posBigInt, equalOperationCounter,
                        (iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F8"));
                    Console.WriteLine();
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
        }


        static void RunProgram()
        {
            FirstAlgorithm first = new FirstAlgorithm();
            SecondAlgorithm second = new SecondAlgorithm();
            SitoEratostenesa sito = new SitoEratostenesa();
            BonusTask bonus = new BonusTask();

            Console.WriteLine("Zadanie projektowe 2 \n"
                + "\n Program sprawdza czy wprowadzone liczby są liczbami pierwszymi:"
                + "\n { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 } \n");

            Console.WriteLine("===========================================\n");

            Console.WriteLine("Jaki algorytm chcesz wybrać?" +
                "\n 1. Podstawowy algorytm sprawdzający każdą liczbę - wybierz 1." +
                "\n 2. Szybki algorytm sprawdzający pierwiastek kwadratowy z tej liczby - wybierz 2." +
                "\n 3. Sito Eratostenesa - wybierz 3." +
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
                    sito.CheckIsPrimeNumber();
                    break;
                case 4:
                    bonus.CheckIsPrimeNumber();
                    break;
            }
            Console.WriteLine();
        }


        static bool EndProgram()
        {
            string end;
            Console.WriteLine("Czy chcesz zakończyć program? \n" +
                "Tak - naciśnij Enter. \n" +
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