using System;

namespace dz8
{

    public delegate int[] ArrDelegate(int[] arr);
    public delegate void PrintDataDelegate(int[] arr);
    public delegate bool NumberHandler(int num);
    
    class Program
    {
        static int[] EvenNumbers(int[] arr)
        {
            int count = 0;
            foreach (var num in arr)
            {
                if (num % 2 == 0) count++;
            }

            int[] evenNumbers = new int[count];
            int index = 0;
            foreach (var num in arr)
            {
                if (num % 2 == 0)
                {
                    evenNumbers[index] = num;
                    index++;
                }
            }
            return evenNumbers;
        }

        static int[] OddNumbers(int[] arr)
        {
            int count = 0;
            foreach (var num in arr)
            {
                if (num % 2 != 0) count++;
            }

            int[] oddNumbers = new int[count];
            int index = 0;
            foreach (var num in arr)
            {
                if (num % 2 != 0)
                {
                    oddNumbers[index] = num;
                    index++;
                }
            }
            return oddNumbers;
        }

        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        static int[] PrimeNumbers(int[] arr)
        {
            int count = 0;
            foreach (var num in arr)
            {
                if (IsPrime(num)) count++;
            }

            int[] primeNumbers = new int[count];
            int index = 0;
            foreach (var num in arr)
            {
                if (IsPrime(num))
                {
                    primeNumbers[index] = num;
                    index++;
                }
            }
            return primeNumbers;
        }

        static bool IsFibonacci(int num)
        {
            if (num < 0) return false;
            int a = 0, b = 1, c = 0;
            while (c < num)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c == num;
        }

        static int[] GetFibonacciFromArray(int[] arr)
        {
            int count = 0;
            foreach (var num in arr)
            {
                if (IsFibonacci(num)) count++;
            }

            int[] fibonacciNumbers = new int[count];
            int index = 0;
            foreach (var num in arr)
            {
                if (IsFibonacci(num))
                {
                    fibonacciNumbers[index] = num;
                    index++;
                }
            }
            return fibonacciNumbers;
        }

        static void PrintTime() { 
            Console.WriteLine($"Current Time: {DateTime.Now.ToString("HH:mm:ss")}");
        }

        static void PrintDate() { 
            Console.WriteLine($"Current Date: {DateTime.Now.ToString("dd/MM/yyyy")}");
        }

        static void PrintDayOfWeek() { 
            Console.WriteLine($"Current Day of Week: {DateTime.Now.DayOfWeek}");
        }

        static void PrintTimeData(string dataType)
        {
            switch (dataType.ToLower())
            {
                case "time":
                    PrintTime();
                    break;
                case "date":
                    PrintDate();
                    break;
                case "dayofweek":
                    PrintDayOfWeek();
                    break;
                default:
                    Console.WriteLine("Invalid data type. Please use 'time', 'date', or 'dayofweek'.");
                    break;
            }
        }

        static double CalculateTriangleArea(double a, double b) // height and base
        {
            return 0.5 * a * b;
        }

        static double CalculateRectangleArea(double a, double b)
        {
            return a * b;
        }

        // Номер картки;
        // ПІБ власника;
        // Термін дії картки;
        // PIN;
        // Кредитний ліміт;
        // Сума грошей.

        // 3
        public class CreditCard { 
            public string CardNumber { get; set; }
            public string OwnerName { get; set; }
            public DateTime ExpiryDate { get; set; }
            public string Pin { get; set; }
            public double CreditLimit { get; set; }
            public double Balance { get; set; }

            public CreditCard(string cardNumber, string ownerName, DateTime expiryDate, string pin, double creditLimit, double balance)
            {
                CardNumber = cardNumber;
                OwnerName = ownerName;
                ExpiryDate = expiryDate;
                Pin = pin;
                CreditLimit = creditLimit;
                Balance = balance;
            }

            public override string ToString()
            {
                return $"Card Number: {CardNumber}, Owner: {OwnerName}, Expiry Date: {ExpiryDate.ToShortDateString()}, PIN: {Pin}, Credit Limit: {CreditLimit}, Balance: {Balance}";
            }

            public void AddToBalance(double amount)
            {
                if (amount < 0)
                {
                    Console.WriteLine("Cannot add a negative amount.");
                    return;
                }
                if (Balance + amount > CreditLimit)
                {
                    Console.WriteLine("Cannot exceed credit limit.");
                    return;
                }
                Balance += amount;
            }

            public void WithdrawFromBalance(double amount)
            {
                if (amount < 0)
                {
                    Console.WriteLine("Cannot withdraw a negative amount.");
                    return;
                }
                if (Balance - amount < 0)
                {
                    Console.WriteLine("Not enough balance.");
                    return;
                }
                Balance -= amount;
            }

            public void StartUsingCreditCard()
            {
                Console.WriteLine("Credit card is now in use.");
            }

            public void AddToReachBalance(double newBalance)
            {
                if (newBalance < 0)
                {
                    Console.WriteLine("Cannot set a negative balance.");
                    return;
                }
                if (newBalance > CreditLimit)
                {
                    Console.WriteLine("Cannot exceed credit limit.");
                    return;
                }
                Balance = newBalance;
            }

            public void ChangePin(string newPin)
            {
                if (string.IsNullOrEmpty(newPin) || newPin.Length < 4)
                {
                    Console.WriteLine("Invalid PIN. It must be at least 4 characters long.");
                    return;
                }
                Pin = newPin;
            }
        }

        static int CountVowels(string str)
        {
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char c in str.ToLower())
            {
                foreach (char vowel in vowels)
                {
                    if (c == vowel)
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        static int CountConsonants(string str)
        {
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char c in str.ToLower())
            {
                bool isVowel = false;
                foreach (char vowel in vowels)
                {
                    if (c == vowel)
                    {
                        isVowel = true;
                        break;
                    }
                }
                if (!isVowel && char.IsLetter(c))
                {
                    count++;
                }
            }
            return count;
        }

        static int GetStringLength(string str)
        {
            return str.Length;
        }  

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }   

        static void WriteToFile(string content)
        {
            string filePath = "f1.txt";
            try
            {
                File.WriteAllText(filePath, content);
                Console.WriteLine("Content written to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static bool IsPositive(int number)
        {
            return number > 0;
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        

        static void ex6() { 
            NumberHandler numberHandler = null;
            numberHandler = (int num) =>
            {
                bool isPositive = IsPositive(num);
                bool isEven = IsEven(num);
                Console.WriteLine("IsPositive: " + isPositive);
                Console.WriteLine("IsEven: " + isEven);
                return isPositive && isEven;
            };

            bool a = numberHandler(10); 
            bool b = numberHandler(-4); 

        }

        static void Main()
        {
            //1
            // ArrDelegate arrDelegate = null;
            // int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            // arrDelegate = EvenNumbers;
            // int[] evenNumbers = arrDelegate(arr);
            // Console.Write("Even Numbers: ");
            // foreach (var num in evenNumbers)
            // {
            //     Console.Write(num + " ");
            // }

            //2
            // Action<string> printDataAction = null;
            // printDataAction = (dataType) =>
            // {
            //     PrintTimeData(dataType);
            // };

            // printDataAction("time");
            // printDataAction("date");
            // printDataAction("dayofweek");

            // Func<double, double, double> areaDelegate = null;
            // double a = 5, b = 10;
            // areaDelegate = CalculateTriangleArea;
            // double triangleArea = areaDelegate(a, b);
            // Console.WriteLine(triangleArea);


            //4
            // Action<string> stringDelegate = null;
            // stringDelegate = (str) =>
            // {
            //     int vowelsCount = CountVowels(str);
            //     int consonantsCount = CountConsonants(str);
            //     int length = GetStringLength(str);
            //     Console.WriteLine($"String: {str}, Vowels: {vowelsCount}, Consonants: {consonantsCount}, Length: {length}");
            // };
            // stringDelegate("Hello World");

            //5
            // Action<string> multiAdressDelegate = null;
            // multiAdressDelegate = (message) =>
            // {
            //     PrintMessage(message);
            //     WriteToFile(message);
            // };

            // multiAdressDelegate("Test message");

            //6
            // ex6();
        }
    }

}
