using System;

namespace dz7
{
    public interface IOutput {
        void Show();
        void Show(string info);
    }

    public interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);

    }

    public interface ISort {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }

    public interface ICalc {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);
    }

    public interface IOutput2 {
        void ShowEven();
        void ShowOdd();
    }

    public interface ICalc2 {
        int CountDistinct();
        int EqualToValue(int valueToCompare);
    }

    public class AArray: IOutput, IMath, ISort, ICalc, IOutput2, ICalc2 {
        public int[] arr;

        public AArray() { 
            arr = new int[0];
        }

        public AArray(int[] arr)
        {
            this.arr = arr;
        }

        public float Avg()
        {

            float s = 0;
            foreach (int i in arr) {
                s += i;
            }
            return (float)s/arr.Length;
        }

        public int Max()
        {
            if (arr.Length == 0) return 0;
            int m = arr[0];
            foreach (int i in arr) {
                if (i > m) { m = i; }
            }
            return m;
        }

        public int Min()
        {
            if (arr.Length == 0) return 0;
            int m = arr[0];
            foreach (int i in arr)
            {
                if (i < m) { m = i; }
            }
            return m;
        }

        public bool Search(int valueToSearch)
        {
            foreach (int i in arr) {
                if (i == valueToSearch) return true;
            }
            return false;
        }

        public void Show() {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public void Show(string info) {
            Console.WriteLine(info);
            this.Show();
        }

        public void SortAsc()
        {
            Array.Sort(arr);
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else {
                SortDesc();
            }
        }

        public void SortDesc()
        {
            Array.Sort(arr);
            Array.Reverse(arr);
        }

        public int Less(int valueToCompare)
        {
            int count = 0;
            foreach (int i in arr) {
                if (i < valueToCompare) count++;
            }
            return count;
        }

        public int Greater(int valueToCompare)
        {
            int count = 0;
            foreach (int i in arr)
            {
                if (i > valueToCompare) count++;
            }
            return count;
        }

        public void ShowEven()
        {
            Console.Write("Even: ");
            foreach (int i in arr)
            {
                if (i % 2 == 0) Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void ShowOdd()
        {
            Console.Write("Odd: ");
            foreach (int i in arr)
            {
                if (i % 2 != 0) Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public int EqualToValue(int valueToCompare)
        {
            int count = 0;
            foreach (int i in arr)
            {
                if (i == valueToCompare) count++;
            }
            return count;
        }

        public int CountDistinct() {
            int c = 0;
            for (int i = 0; i < arr.Length; i++) {
                bool d = true;
                for (int j = 0; j < arr.Length; j++) {
                    if (i==j) continue;
                    else if (arr[i] == arr[j]) {
                        d = false;
                        break;
                    }
                }
                if (d) c++;
            }
        
            return c;
        }
    }

    public interface IRemoteControl {
        void TurnOn();
        void TurnOff();
        void SetChannel(int channel);
    }

    public class TV: IRemoteControl {
        private bool isOn;
        private int channel;

        public void TurnOn() {
            isOn = true;
            Console.WriteLine("TV is turned on.");
        }

        public void TurnOff() {
            isOn = false;
            Console.WriteLine("TV is turned off.");
        }

        public void SetChannel(int channel) {
            if (isOn) {
                this.channel = channel;
                Console.WriteLine($"Channel set to {channel}.");
            } else {
                Console.WriteLine("TV is off. Please turn it on first.");
            }
        }

    }

    public class Radio {
        private bool isOn;
        private int channel;

        public void TurnOn() {
            isOn = true;
            Console.WriteLine("Radio is turned on.");
        }

        public void TurnOff() {
            isOn = false;
            Console.WriteLine("Radio is turned off.");
        }

        public void SetChannel(int channel) {
            if (isOn) {
                this.channel = channel;
                Console.WriteLine($"Channel set to {channel}.");
            } else {
                Console.WriteLine("Radio is off. Please turn it on first.");
            }
        }
    }

    public interface IValidator {
        bool Validate();
    }

    public class User: IValidator {
        private string name;
        private string email;
        private string password;

        public User(string name, string email) {
            this.name = name;
            this.email = email;
        }

        public bool Validate() {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email)) {
                Console.WriteLine("Validation failed: Name and email cannot be empty.");
                return false;
            }
            if (!email.Contains("@")) {
                Console.WriteLine("Validation failed: Email must contain '@'.");
                return false;
            }
            if (password.Length < 6) {
                Console.WriteLine("Validation failed: Password must be at least 6 characters long.");
                return false;
            }
            Console.WriteLine("Validation successful.");
            return true;
        }
    }

    internal class Program
    {
        static void Main()
        {

            AArray a = new AArray(new int[] { 1, 2, 3, 3, 5, 6, 7, 8, 9, 9 });
            
            a.ShowEven();
            a.ShowOdd();

            Console.WriteLine(a.Greater(5));
            Console.WriteLine(a.Less(5));

            Console.WriteLine(a.CountDistinct());
            Console.WriteLine(a.EqualToValue(3));
        }
    }

}


