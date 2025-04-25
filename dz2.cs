namespace dz2
{
    public class Program
    {

        public static void ex1() {
            float []arr = new float[5];
            float [,]arr2 = new float[3, 4];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string str = Console.ReadLine();
                if (str == null) break;
                arr[i] = float.Parse(str);
            }

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = (float)(new Random().NextDouble() * 10);
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write(arr2[i, j] + " ");
                }
                Console.WriteLine();
            }

            float max1 = arr[0];
            float min1 = arr[0];
            float sum1 = 0;
            float mult1 = 1;
            float sumEven1 = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i] > max1) max1 = arr[i];
                if (arr[i] < min1) min1 = arr[i];
                sum1 += arr[i];
                mult1 *= arr[i];
                if (arr[i] % 2 == 0) sumEven1 += arr[i];
            }

            float max2 = arr2[0, 0];
            float min2 = arr2[0, 0];
            float sum2 = 0;
            float mult2 = 1;
            float sumOdd2 = 0;

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    if (arr2[i, j] > max2) max2 = arr2[i, j];
                    if (arr2[i, j] < min2) min2 = arr2[i, j];
                    sum2 += arr2[i, j];
                    mult2 *= arr2[i, j];
                    if (arr2[i, j] % 2 != 0) sumOdd2 += arr2[i, j];
                }
            }

        }

        public static void ex2() {
            int n = 5;
            int m = 5;
            int[,] arr = new int[n, m];
            Random rand = new Random();
    
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int max = arr[0, 0];
            int min = arr[0, 0];
            int maxIndexI = 0;
            int maxIndexJ = 0;
            int minIndexI = 0;
            int minIndexJ = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        maxIndexI = i;
                        maxIndexJ = j;
                    }
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        minIndexI = i;
                        minIndexJ = j;
                    }
                }
            }

            int sumBetweenMaxMin = 0;
            if (Math.Abs(maxIndexI - minIndexI) <= 1 && Math.Abs(maxIndexJ - minIndexJ) <= 1)
            {
                Console.WriteLine("No elements between max and min.");
                return;
            }
            for (int i = Math.Min(maxIndexI, minIndexI); i <= Math.Max(maxIndexI, minIndexI); i++)
            {
                for (int j = Math.Min(maxIndexJ, minIndexJ); j <= Math.Max(maxIndexJ, minIndexJ); j++)
                {
                    sumBetweenMaxMin += arr[i, j];
                }
            }
            
            Console.WriteLine("Max: " + max + " at (" + maxIndexI + ", " + maxIndexJ + ")");
            Console.WriteLine("Min: " + min + " at (" + minIndexI + ", " + minIndexJ + ")");
            Console.WriteLine("Sum between max and min: " + sumBetweenMaxMin);
        }

        public static void ex3() {
            string str = Console.ReadLine();
            int key = 3;
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    char d = (char)(c + key);
                    if (char.IsUpper(c) && d > 'Z' || char.IsLower(c) && d > 'z')
                    {
                        d -= (char)26;
                    }
                    result += d;
                }
                else
                {
                    result += c;
                }
            }
            Console.WriteLine(result);
            // reverse 
            string decrypted = "";
            for (int i = 0; i < result.Length; i++)
            {
                char c = result[i];
                if (char.IsLetter(c))
                {
                    char d = (char)(c - key);
                    if (char.IsUpper(c) && d < 'A' || char.IsLower(c) && d < 'a')
                    {
                        d += (char)26;
                    }
                    decrypted += d;
                }
                else
                {
                    decrypted += c;
                }
            }
            Console.WriteLine(decrypted);
        }

        public static int[,] multiplyMatrixByNumber(int[,] matrix, int number) {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }
            return result;
        }

        public static int[,] multiplyMatrixByMatrix(int[,] matrix1, int[,] matrix2) {
            if (matrix1.GetLength(1) != matrix2.GetLength(0)) {
                Console.WriteLine("Invalid matrix sizes");
                return null;
            }

            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        public static int[,] addMatrix(int[,] matrix1, int[,] matrix2) {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1)) {
                Console.WriteLine("Invalid matrix sizes");
                return null;
            }

            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        public static void ex4() {
            while (true) {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Multiply matrix by number");
                Console.WriteLine("2. Multiply matrixes");
                Console.WriteLine("3. Add matrixes");

                Console.WriteLine("4. Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter matrix size (rows and columns): ");
                        int rows = int.Parse(Console.ReadLine());
                        int columns = int.Parse(Console.ReadLine());
                        int[,] matrix = new int[rows, columns];
                        Console.WriteLine("Enter matrix elements: ");
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                matrix[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("Enter number to multiply by: ");
                        int number = int.Parse(Console.ReadLine());
                        int[,] result1 = multiplyMatrixByNumber(matrix, number);

                        Console.WriteLine("Result: ");
                        for (int i = 0; i < result1.GetLength(0); i++)
                        {
                            for (int j = 0; j < result1.GetLength(1); j++)
                            {
                                Console.Write(result1[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter first matrix size (rows and columns): ");
                        int rows1 = int.Parse(Console.ReadLine());
                        int columns1 = int.Parse(Console.ReadLine());
                        int[,] matrix1 = new int[rows1, columns1];
                        Console.WriteLine("Enter first matrix elements: ");
                        for (int i = 0; i < rows1; i++)
                        {
                            for (int j = 0; j < columns1; j++)
                            {
                                matrix1[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("Enter second matrix size (rows and columns): ");
                        int rows2 = int.Parse(Console.ReadLine());
                        int columns2 = int.Parse(Console.ReadLine());
                        int[,] matrix2 = new int[rows2, columns2];
                        Console.WriteLine("Enter second matrix elements: ");
                        for (int i = 0; i < rows2; i++)
                        {
                            for (int j = 0; j < columns2; j++)
                            {
                                matrix2[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        int[,] result2 = multiplyMatrixByMatrix(matrix1, matrix2);

                        Console.WriteLine("Result: ");
                        for (int i = 0; i < result2.GetLength(0); i++)
                        {
                            for (int j = 0; j < result2.GetLength(1); j++)
                            {
                                Console.Write(result2[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter first matrix size (rows and columns): ");
                        int rows3 = int.Parse(Console.ReadLine());
                        int columns3 = int.Parse(Console.ReadLine());
                        int[,] matrix3 = new int[rows3, columns3];
                        Console.WriteLine("Enter first matrix elements: ");
                        for (int i = 0; i < rows3; i++)
                        {
                            for (int j = 0; j < columns3; j++)
                            {
                                matrix3[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("Enter second matrix size (rows and columns): ");
                        int rows4 = int.Parse(Console.ReadLine());
                        int columns4 = int.Parse(Console.ReadLine());
                        int[,] matrix4 = new int[rows4, columns4];
                        Console.WriteLine("Enter second matrix elements: ");
                        for (int i = 0; i < rows4; i++)
                        {
                            for (int j = 0; j < columns4; j++)
                            {
                                matrix4[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        int[,] result3 = addMatrix(matrix3, matrix4);

                        Console.WriteLine("Result: ");
                        for (int i = 0; i < result3.GetLength(0); i++)
                        {
                            for (int j = 0; j < result3.GetLength(1); j++)
                            {
                                Console.Write(result3[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        return;
                }
            }
        }

        public static void ex5() {
            string strProblem = Console.ReadLine();

            string n1 = "";
            string n2 = "";
            for (int i = 0; i < strProblem.Length; i++)
            {
                if (char.IsDigit(strProblem[i]))
                {
                    n1 += strProblem[i];
                }
                else
                {
                    break;
                }
            }
            for (int i = strProblem.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(strProblem[i]))
                {
                    n2 = strProblem[i] + n2;
                }
                else
                {
                    break;
                }
            }
            string operation = strProblem.Substring(n1.Length, strProblem.Length - n1.Length - n2.Length);
            int number1 = int.Parse(n1);
            int number2 = int.Parse(n2);
            int result = 0;
            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    return;
            }
            Console.WriteLine("Result: " + result);
        }

        public static void ex6() {
            string text = "today is a good day for walking. i will try to walk near the sea";
            string []sentences = text.Split('.');
            for (int i = 0; i < sentences.Length; i++)
            {
                sentences[i] = sentences[i].Trim();
                if (sentences[i].Length > 0)
                {
                    sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1); 
                }
            }
            string result = string.Join(". ", sentences);
            Console.WriteLine(result);
        }

        public static void ex7() {
            string forbiddenWord = "die";
            string text = "To be, or not to be, that is the question,\nWhether 'tis nobler in the mind to suffer\nThe slings and arrows of outrageous fortune,\nOr to take arms against a sea of troubles,\nAnd by opposing end them? To die: to sleep;\nNo more; and by a sleep to say we end\nThe heart-ache and the thousand natural shocks\nThat flesh is heir to, 'tis a consummation\nDevoutly to be wish'd. To die, to sleep";

            string []words = text.Split(new char[] { ' ', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].ToLower() == forbiddenWord.ToLower())
                {
                    words[i] = new string('*', forbiddenWord.Length);
                    count++;
                }
            }
            string result = string.Join(" ", words);
            Console.WriteLine(result);
            Console.WriteLine("Count of forbidden words: " + count);

        }

        public static void ex8() {
            while (true) {
                Console.WriteLine("Enter a string: ");
                string str = Console.ReadLine();
                Console.WriteLine("Enter a key: ");
                int key = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter action (1 - encrypt, 2 - decrypt, 3 - quit): ");

                int action = int.Parse(Console.ReadLine());
                string result = "";
                if (action == 1) {
                    for (int i = 0; i < str.Length; i++)
                    {
                        char c = str[i];
                        if (char.IsLetter(c))
                        {
                            char d = (char)(c + key);
                            if (char.IsUpper(c) && d > 'Z' || char.IsLower(c) && d > 'z')
                            {
                                d -= (char)26;
                            }
                            result += d;
                        }
                        else
                        {
                            result += c;
                        }
                    }
                } else if (action == 2) {
                    for (int i = 0; i < str.Length; i++)
                    {
                        char c = str[i];
                        if (char.IsLetter(c))
                        {
                            char d = (char)(c - key);
                            if (char.IsUpper(c) && d < 'A' || char.IsLower(c) && d < 'a')
                            {
                                d += (char)26;
                            }
                            result += d;
                        }
                        else
                        {
                            result += c;
                        }
                    }
                } 
                else if (action == 3) {
                    return;
                }
                else {
                    Console.WriteLine("Invalid action");
                    continue;
                }
                Console.WriteLine("Result: " + result);
            }
        }

        public static void ex9() {
            int n;
            int m;
            int k;
            Console.WriteLine("Enter matrix size (rows and columns) and k: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            n = int.Parse(parts[0]);
            m = int.Parse(parts[1]);
            k = int.Parse(parts[2]);

            int[,] matrix = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(1, 10);
                }
            }
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                    matrix[i, j] *= k;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Changed matrix: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            ex9();
        }
    }
}
