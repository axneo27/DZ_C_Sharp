using System;

namespace ProgramNamespace
{
  class Program
  {
    static void ex1() {
        Console.WriteLine("Input number from 1 to 100");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 1 || n > 100)
        {
            Console.WriteLine("Number is out of range");
            return;
        }
        if (n % 3 == 0 && n % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (n % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (n % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(n);
        }
    }

    static void ex2() {
        Console.Write("Input number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input percent: ");
        int p = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Result: " + (n * p / 100));
        
    }

    static void ex3() {
        int res = 0;
        for (int i = 3; i >= 0; i--) {
            Console.Write("Input number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            res += Convert.ToInt32(n*Math.Pow(10, i));
        }
        Console.WriteLine("Result: " + res);
    }

    static void ex4() {
        Console.Write("Input 6-digit number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 100000 || n > 999999)
        {
            Console.WriteLine("Number is out of range");
            return;
        }
        Console.WriteLine("Input 1st digit: ");
        int d1 = Convert.ToInt32(Console.ReadLine());
        if (d1 < 1 || d1 > 6)
        {
            Console.WriteLine("Digit is out of range");
            return;
        }
        Console.WriteLine("Input 2nd digit: ");
        int d2 = Convert.ToInt32(Console.ReadLine());
        if (d2 < 1 || d2 > 6)
        {
            Console.WriteLine("Digit is out of range");
            return;
        }
        
        string s = n.ToString();
        char temp = s[d1 - 1];

        char[] chars = s.ToCharArray();
        chars[d1 - 1] = s[d2 - 1]; 
        chars[d2 - 1] = temp;
        s = new string(chars);
        Console.WriteLine("Result: " + Convert.ToInt32(s));
    }

    static void ex5() {
        Console.Write("Input date (dd.mm.yyyy): ");
        string date = Console.ReadLine();
        DateTime dt = DateTime.ParseExact(date, "dd.MM.yyyy", null);
        string season = "";
        if (dt.Month == 12 || dt.Month == 1 || dt.Month == 2)
        {
            season = "Winter";
        }
        else if (dt.Month == 3 || dt.Month == 4 || dt.Month == 5)
        {
            season = "Spring";
        }
        else if (dt.Month == 6 || dt.Month == 7 || dt.Month == 8)
        {
            season = "Summer";
        }
        else
        {
            season = "Autumn";
        }
        string dayOfWeek = dt.DayOfWeek.ToString();
        Console.WriteLine(season + " " + dayOfWeek);
    }

    static void ex6() {
        //farenheit to celsius and celsius to farenheit
        Console.Write("Input temperature: ");
        double t = Convert.ToDouble(Console.ReadLine());
        Console.Write("1 - F -> C, 2 - C -> F: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("Result: " + ((t - 32) * 5 / 9));
        }
        else if (choice == 2)
        {
            Console.WriteLine("Result: " + (t * 9 / 5 + 32));
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }

    static void ex7() {
        Console.Write("Input number 1: ");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input number 2: ");
        int n2 = Convert.ToInt32(Console.ReadLine());
        if (n1 > n2) {
            int temp = n1;
            n1 = n2;
            n2 = temp;
        }

        for (int i = n1; i <= n2; i++) {
            if (i % 2 == 0)
            {
                Console.Write(i + " ");
            }
        }
    }

    static void ex8() {
        Console.Write("Input number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int l = n.ToString().Length;

        int res = 0;
        for (int d = 10; d <= Math.Pow(10, l); d*= 10) {
            int digit = n % d;
            digit /= (int)(d / 10);
            res += (int)Math.Pow(digit, l);
        }
        if (res == n)
        {
            Console.WriteLine("Armstrong number");
        }
        else
        {
            Console.WriteLine("Not Armstrong number");
        }
    }

    static void ex9() {
        Console.Write("Input number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int res = 0;
        for (int i = 1; i < n; i++) {
            if (n % i == 0)
            {
                res += i;
            }
        }
        if (res == n)
        {
            Console.WriteLine("Perfect number");
        }
        else
        {
            Console.WriteLine("Not perfect number");
        }
    }

    static void Main(string[] args)
    {
        ex9();
    }
  }
}
