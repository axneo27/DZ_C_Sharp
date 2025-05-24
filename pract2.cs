using System.Runtime.Intrinsics.X86;

namespace InterfacesSPR421
{
    public interface IPhone
    {
        public int MyProperty { get; set; }

        void Phone();
        void GetSMS();

    }
    public interface IClone
    {

    }
    class Person : IPhone, IClone
    {
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetSMS()
        {
            throw new NotImplementedException();
        }

        public void Phone()
        {
            throw new NotImplementedException();
        }
    }
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Name : {FirstName} Surname : {LastName} Date of birth {BirthDate.ToLongDateString()}";
        }
    }

    abstract class Employee : Human
    {
        public double Salary { get; set; }
        public string Position { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nPosition : {Position} Salary : {Salary}";
        }
    }
    interface IWorkable
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkable> listOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager
    {
        public List<IWorkable> listOfWorkers { get; set; }

        public void Control()
        {
            Console.WriteLine("Controling some work...");
        }

        public void MakeBudget()
        {
            Console.WriteLine("Making some budget....");
        }

        public void Organize()
        {
            Console.WriteLine("Organize some work...");
        }
    }
    class Seller : Employee, IWorkable
    {


        bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public string Work()
        {
            return "Selling some products";
        }
    }

    class Cashier : Employee, IWorkable
    {

        bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public string Work()
        {
            return "Getting pay for products";
        }
    }

    class StoreKeeper : Employee, IWorkable
    {
        private bool _IsWorking;
        public bool IsWorking => _IsWorking;

        public string Work()
        {
            return "Organize product store";
        }
    }
    class Administrator : Employee, IWorkable, IManager
    {
        public bool IsWorking { get; }

        public List<IWorkable> listOfWorkers { get; set; }

        public void Control()
        {
            Console.WriteLine("Amd controling work"); ;
        }

        public void MakeBudget()
        {
            Console.WriteLine("Adm making budget");
        }

        public void Organize()
        {
            Console.WriteLine("Adm organizing work"); ;
        }

        public string Work()
        {
            return "Adm make some work";
        }
    }

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

    public class AArray: IOutput, IMath, ISort {
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
    }

    public interface IShape {
        void CalculateArea();
        void CalculatePerimeter();
    }

    class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Area
        {
            get { return Math.PI * radius * radius; }
        }

        public double Perimeter {
            get { return Math.PI * 2 * radius; }
        }

        public void Print()
        {
            Console.WriteLine($"Circle: Radius = {radius}, Area = {Area}");
        }

        public void CalculateArea()
        {
            Console.WriteLine($"Area of circle: {Area}");
        }


        public void CalculatePerimeter() {
            Console.WriteLine($"Perimeter of circle: {Perimeter}");
        }
    }

    class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Area
        {
            get { return width * height; }
        }

        public double Perimeter {
            get { return width * 2 + height * 2; }
        }

        public void Print()
        {
            Console.WriteLine($"Rectangle: Width = {width}, Height = {height}, Area = {Area}");
        }

        public void CalculateArea()
        {
            Console.WriteLine($"Area of rectangle: {Area}");
        }

        public void CalculatePerimeter()
        {
            Console.WriteLine($"Perimeter of rectangle: {Perimeter}");
        }
    }

    class RightTriangle : IShape {
        private double baseLength;
        private double height;

        public RightTriangle(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public double Area
        {
            get { return 0.5 * baseLength * height; }
        }
        public double Perimeter
        {
            get { return baseLength + height + Math.Sqrt(Math.Pow(baseLength, 2) + Math.Pow(height, 2)); }
        }
        public void Print()
        {
            Console.WriteLine($"Right Triangle: Base = {baseLength}, Height = {height}, Area = {Area}");
        }

        public void CalculateArea()
        {
            Console.WriteLine($"Area of right triangle: {Area}");
        }

        public void CalculatePerimeter()
        {
            Console.WriteLine($"Perimeter of right triangle: {Perimeter}");
        }
    }

    public interface IDrivable {
        void StartEngine();
        void StopEngine();
        void Drive();
    }

    public class Auto : IDrivable
    {
        public void Drive()
        {
            Console.WriteLine("Driving");
        }

        public void StartEngine()
        {
            Console.WriteLine("Starting engine");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stopping engine");
        }
    }

    public class Bike : IDrivable {
        public void Drive()
        {
            Console.WriteLine("Driving");
        }

        public void StartEngine()
        {
            Console.WriteLine("Starting engine");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stopping engine");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = { 1,4,2,3,6};
            AArray array = new AArray(arr);
            array.Show();
            array.Show("Info");

            Console.WriteLine(array.Avg());
            Console.WriteLine(array.Max());
            Console.WriteLine(array.Min());
            Console.WriteLine(array.Search(2));

            array.SortAsc();
            array.Show();

            array.SortDesc();
            array.Show();

            RightTriangle t = new RightTriangle(3, 4);

            t.CalculateArea();
            t.CalculatePerimeter();

            //TestWork(new Cashier());

            //IManager director = new Director
            //{
            //    LastName = "Doe",
            //    FirstName = "John",
            //    BirthDate = new DateTime(1990, 12, 31),
            //    Position = "Director",
            //    Salary = 7000
            //};
            //IWorkable seller = new Seller
            //{
            //    LastName = "Bim",
            //    FirstName = "Jim",
            //    BirthDate = new DateTime(2000, 12, 31),
            //    Position = "Seller",
            //    Salary = 6000
            //};

            //Console.WriteLine(seller.Work());
            ////TestWork(seller);
            //if (seller is Employee)
            //    Console.WriteLine($"Seller salary : {(seller as Employee).Salary}");

            //director.listOfWorkers = new List<IWorkable>
            //{
            //    seller,
            //    new Cashier
            //    {
            //        LastName = "Casha",
            //        FirstName = "Cash",
            //        BirthDate = new DateTime(2005, 9, 30),
            //        Position = "Cashier",
            //        Salary = 8000
            //    },
            //    new StoreKeeper
            //    {
            //        LastName = "StoreKeep",
            //        FirstName = "Vasyl",
            //        BirthDate = new DateTime(1980, 11, 25),
            //        Position = "StoreKeeper",
            //        Salary = 10000
            //    }
            //};

            //foreach (IWorkable worker in director.listOfWorkers) {
            //    if (worker is Cashier) {
            //        Console.WriteLine("Cashier");
            //    } 
            //    Console.WriteLine(worker);
            //    if (worker.IsWorking)
            //    {
            //        Console.WriteLine(worker.Work());
            //    }
            //    Console.WriteLine("___________________________");
            //}
            //var admin = new Administrator();
            //IManager m = admin;
            //IWorkable w = admin;



        }
        static void TestWork(IWorkable worker)
        {
            if (worker.IsWorking)
            {
                Console.WriteLine(worker.Work());
            }
            else
            {
                Console.WriteLine("Not working...");
            }
        }
    }
}
