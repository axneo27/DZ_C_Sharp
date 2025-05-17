using System;

namespace dz5
{

    public class RangeOfArray {
        public int max;
        public int min;

        public int[] array;
        public int range;

        public int Range
        {
            get
            {
                return max - min;
            }
        }
        public int this[int index]
        {
            get
            {
                if (index < min || index > max)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return array[index];
            }
            set
            {
                if (index < min || index > max)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                array[index] = value;
            }
        }
        public RangeOfArray(int max, int min, int[] array)
        {
            this.array = array;
            if (max < min || min < 0 || max < 0 || max >= array.Length || min >= array.Length)
            {
                this.max = array.Length - 1;
                this.min = 0;
            }
            else
            {
                this.min = min;
                this.max = max;
            }
        }

        public RangeOfArray()
        {
            max = 9;
            min = 0;
            array = new int[10];
        }

        public RangeOfArray(int max) : this(max, 0, new int[10]) {}

        public override string ToString()
        {
            return $"Max: {max}, Min: {min}, Range: {Range}";
        }

        public void PrintArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public void PrintRange()
        {
            Console.WriteLine($"Max: {max}, Min: {min}, Range: {Range}");
            for (int i = min; i <= max; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RangeOfArray r = new RangeOfArray(9, 5, new int[10]);
            Console.WriteLine(r.ToString());
            for (int i = r.min; i <= r.max; i++)
            {
                r[i] = i;
            }
            r.PrintArray();
            r.PrintRange();
        }
    }

}
