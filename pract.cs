using System;

namespace Inheritance
{

    public class Person {
        protected string name;
        private readonly DateTime birthDate;

        private int age;

        public int Age
        {
            get {
                return (int)((DateTime.Now - birthDate).TotalDays / 365.25);
            }
        }

        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            if (birthDate > DateTime.Now)
            {
                throw new InvalidAgeException("Birth date cannot be in the future.");
            } 
            else if (birthDate < DateTime.Now.AddYears(-120))
            {
                throw new InvalidAgeException("Birth date cannot be more than 120 years in the past.");
            }
            else {
                this.birthDate = birthDate;
            }
        }

        public Person() : this("John Doe", DateTime.Now) {}

        public virtual void Print()
        {
            Console.WriteLine($"Name: {name}, BirthDate: {birthDate.ToShortDateString()}");
        }

        public override string ToString()
        {
            return $"Name: {name}, BirthDate: {birthDate.ToShortDateString()}";
        }
    }

    class Worker : Person
    {
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set {
                this.salary = value < 0 ? 0 : value;
            }
        }

        public Worker(string name, DateTime birthDate, decimal salary) : base(name, birthDate)
        {
            this.salary = salary;
        }

        public Worker() : this("John Doe", DateTime.Now, 0) {}
        public Worker(decimal s) : this("John Doe", DateTime.Now, s) {}

        public virtual void DoWork()
        {
            Console.WriteLine($"{name} is working.");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Salary: {salary}");
        }

    }

    class Programmer : Worker {
        public int linesOfCode {get; private set;}
        public Programmer(string name, DateTime birthDate, decimal salary, int loc) : base(name, birthDate, salary)
        {
            this.linesOfCode = loc;
        }

        public Programmer() : base() {
            this.linesOfCode = 0;
        }

        public override void DoWork()
        {
            Console.WriteLine($"{name} is programming.");
        }

        public void WriteLine() 
        {
            linesOfCode++;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Lines of code: {linesOfCode}");
        }
    }

    sealed class TechLead : Programmer {
        public int projectCount {get; private set;}
        public TechLead(string name, DateTime birthDate, decimal salary, int loc, int pc) : base(name, birthDate, salary, loc)
        {
            this.projectCount = pc;
        }
    }

    class Human {
        public int height;
        public int age;

        public Human(int height, int age)
        {
            this.height = height;
            this.age = age;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Height: {height}, Age: {age}");
        }

        public override string ToString()
        {
            return $"Height: {height}, Age: {age}";
        }

        public void Live()
        {
            Console.WriteLine("Living...");
        }
    }

    class Builder : Human {
        public int experience;

        public Builder(int height, int age, int experience) : base(height, age)
        {
            this.experience = experience;
        }

        public void Build()
        {
            Console.WriteLine("Building...");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Experience: {experience}");
        }
    }

    class Sailor : Human {
        public int rank;

        public Sailor(int height, int age, int rank) : base(height, age)
        {
            this.rank = rank;
        }

        public void Sail()
        {
            Console.WriteLine("Sailing...");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Rank: {rank}");
        }
    }

    class Pilot : Human {
        public int flightHours;

        public Pilot(int height, int age, int flightHours) : base(height, age)
        {
            this.flightHours = flightHours;
        }

        public void Fly()
        {
            Console.WriteLine("Flying...");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Flight hours: {flightHours}");
        }
    }

    class Passport {
        public string name;
        public string surname;
        public DateTime birthDate;

        public Passport(string name, string surname, DateTime birthDate)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
        }

        public override string ToString()
        {
            return $"Name: {name}, Surname: {surname}, BirthDate: {birthDate.ToShortDateString()}";
        }
    }

    class ForeignPassport : Passport {
        public string country;
        public string visaData;
        public string visaNumber;

        public ForeignPassport(string name, string surname, DateTime birthDate, string country, string vd, string vn) : base(name, surname, birthDate)
        {
            this.country = country;
            this.visaData = vd;
            this.visaNumber = vn;
        }

        public override string ToString()
        {
            return $"Name: {name}, Surname: {surname}, BirthDate: {birthDate.ToShortDateString()}, Country: {country}";
        }
    }

    class Animal {
        public string name;
        public int age;

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }

        public override string ToString()
        {
            return $"Name: {name}, Age: {age}";
        }
    }

    class Tiger : Animal {
        public string color;

        public Tiger(string name, int age, string color) : base(name, age)
        {
            this.color = color;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Color: {color}");
        }
    }

    class Crocodile : Animal {
        public string habitat;

        public Crocodile(string name, int age, string habitat) : base(name, age)
        {
            this.habitat = habitat;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Habitat: {habitat}");
        }
    }

    class Kangaroo : Animal {
        public string habitat;

        public Kangaroo(string name, int age, string habitat) : base(name, age)
        {
            this.habitat = habitat;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Habitat: {habitat}");
        }
    }

    abstract class Shape {
        public abstract double Area { get; }

        public abstract void Print();
        public abstract void calculateArea();
    }

    class Circle : Shape {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double Area
        {
            get { return Math.PI * radius * radius; }
        }

        public override void Print()
        {
            Console.WriteLine($"Circle: Radius = {radius}, Area = {Area}");
        }

        public override void calculateArea()
        {
            Console.WriteLine($"Area of circle: {Area}");
        }
    }

    class Rectangle : Shape {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area
        {
            get { return width * height; }
        }

        public override void Print()
        {
            Console.WriteLine($"Rectangle: Width = {width}, Height = {height}, Area = {Area}");
        }

        public override void calculateArea()
        {
            Console.WriteLine($"Area of rectangle: {Area}");
        }
    }

    class RightTriangle : Shape {
        private double baseLength;
        private double height;

        public RightTriangle(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public override double Area
        {
            get { return 0.5 * baseLength * height; }
        }
        public override void Print()
        {
            Console.WriteLine($"Right Triangle: Base = {baseLength}, Height = {height}, Area = {Area}");
        }

        public override void calculateArea()
        {
            Console.WriteLine($"Area of right triangle: {Area}");
        }
    }

    class Trapezium : Shape {
        private double base1;
        private double base2;
        private double height;

        public Trapezium(double base1, double base2, double height)
        {
            this.base1 = base1;
            this.base2 = base2;
            this.height = height;
        }

        public override double Area
        {
            get { return 0.5 * (base1 + base2) * height; }
        }

        public override void Print()
        {
            Console.WriteLine($"Trapezium: Base1 = {base1}, Base2 = {base2}, Height = {height}, Area = {Area}");
        }

        public override void calculateArea()
        {
            Console.WriteLine($"Area of trapezium: {Area}");
        }
    }

    class InvalidAgeException: ArgumentException
    {
        public InvalidAgeException(string message) : base(message) {}
    }

    abstract class Document {
        abstract public void Print();
    }

    class Report : Document {
        public string title;
        public string content;

        public Report(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public override void Print()
        {
            Console.WriteLine($"Report: {title}\n{content}");
        }
    }

    class Invoice : Document {
        public string invoiceNumber;
        public string details;

        public Invoice(string invoiceNumber, string details)
        {
            this.invoiceNumber = invoiceNumber;
            this.details = details;
        }

        public Invoice() : this("0000", "No details") {}

        public override void Print()
        {
            if (invoiceNumber == "0000")
            {
                throw new ArgumentException("Invoice number cannot be empty.");
            }
            Console.WriteLine($"Invoice: {invoiceNumber}\n{details}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Worker w = new Worker("Vitya", new DateTime(2005, 12, 25), 25000);
            Person[] people = new Person[] {
                new Person("Vanya", new DateTime(2005, 12, 25)),
                new Worker("Vitya", new DateTime(2005, 12, 25), 25000),
                new Programmer("Vanya", new DateTime(2005, 12, 25), 25000, 100),
                new TechLead("Vanya", new DateTime(2005, 12, 25), 25000, 100, 10)
            };

            foreach (var person in people)
            {
                person.Print();
                Console.WriteLine();
            }

            Shape[] shapes = new Shape[] {
                new Circle(5),
                new Rectangle(4, 5),
                new RightTriangle(3, 4),
                new Trapezium(3, 4, 5)
            };

            try {
                Rectangle r = (Rectangle)shapes[1];
            } catch {
                Console.WriteLine("Could not cast to the desired type.");
            }
            Person p = new Person("John", new DateTime(2000, 1, 1));
            try {
                Person p2 = new Person("John", new DateTime(1900, 1, 1));
            } catch (InvalidAgeException e) {
                Console.WriteLine(e.Message);
            }

            Document[] documents = new Document[] {
                new Report("Report Title", "Report Content"),
                new Invoice("12345", "Invoice Details"),
                new Invoice()
            };

            foreach (var doc in documents)
            {
                try {
                    doc.Print();
                } catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                }
            }
            
        }
    }

}
