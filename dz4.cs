using System;
//1
namespace EvenOddNumbers
{
    class CreateEvenNumbers
    {
        public static int[] CreateNumbers(int n)
        {
            int[] evenNumbers = new int[n / 2];
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers[i / 2] = i;
                }
            }
            return evenNumbers;
        }
    }

    class CreateOddNumbers
    {
        public static int[] CreateNumbers(int n)
        {
            int[] oddNumbers = new int[n / 2];
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 != 0)
                {
                    oddNumbers[i / 2] = i;
                }
            }
            return oddNumbers;
        }
    }
}

namespace PrimeFibonacci 
{
    class CreatePrimeNumbers
    {
        public static int[] CreateNumbers(int n)
        {
            int[] primeNumbers = new int[n];
            int count = 0;
            for (int i = 2; count < n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers[count] = i;
                    count++;
                }
            }
            return primeNumbers;
        }
    }

    class CreateFibonacciNumbers
    {
        public static int[] CreateNumbers(int n)
        {
            int[] fibonacciNumbers = new int[n];
            fibonacciNumbers[0] = 0;
            fibonacciNumbers[1] = 1;
            for (int i = 2; i < n; i++)
            {
                fibonacciNumbers[i] = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
            }
            return fibonacciNumbers;
        }
    }
}
//2
namespace shapes {
    class Triangle
    {
        public double a { get; set; }
        public Triangle(double a)
        {
            this.a = a;
        }
        
        public void DrawTriangle()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < 2*i + 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }

    class Rectangle
    {
        public double a { get; set; }
        public double b { get; set; }
        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        
        public void DrawRectangle()
        {
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }

    class Square: Rectangle
    {
        public Square(double a) : base(a, a)
        {
        }
        
        public void DrawSquare()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
//3
namespace compGame 
{
    class GuessTheNumber
    {
        public int number;
        public int diapazone;

        public GuessTheNumber(int number, int diapazone)
        {
            this.number = number;
            this.diapazone = diapazone;
            if (number < 0 || number > diapazone)
            {
                number = 0;
            }
        }

        public void StartGame()
        {
            int guess = 0;
            int currentMinDiapazone = 0;
            int currentMaxDiapazone = diapazone;
            while (guess != number)
            {
                int mid = (currentMinDiapazone + currentMaxDiapazone) / 2;
                Console.WriteLine($"Is your number {mid}? (y/n)");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    guess = mid;
                    Console.WriteLine($"I guessed your number {guess}!");
                }
                else
                {
                    Console.WriteLine("Is your number higher or lower? (h/l)");
                    answer = Console.ReadLine();
                    if (answer == "h")
                    {
                        currentMinDiapazone = mid + 1;
                    }
                    else if (answer == "l")
                    {
                        currentMaxDiapazone = mid - 1;
                    }
                }
            }
        }
    }
}
//4
namespace pseudoText 
{
    class PseudoTextGenerator
    {
        public static string GeneratePseudoText(int vowelsCount, int consonantsCount, int maxWordLength, int wordsCount)
        {
            Random random = new Random();
            string vowels = "aeiou";
            string consonants = "bcdfghjklmnpqrstvwxyz";
            string pseudoText = "";
            for (int i = 0; i < wordsCount; i++)
            {
                string word = "";
                for (int j = 0; j < maxWordLength; j++)
                {
                    if (j % 2 == 0)
                    {
                        word += vowels[random.Next(vowels.Length)];
                    }
                    else
                    {
                        word += consonants[random.Next(consonants.Length)];
                    }
                }
                pseudoText += word + " ";
            }
            return pseudoText;
        }
    }
}

namespace dz4
{
    class Program
    {
        static void Main()
        {
            
        }
    }
}
