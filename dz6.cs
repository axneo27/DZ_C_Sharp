using System;

namespace dz6
{

    public class Money {
        public int dollars;
        public int cents;

        public Money(int dollars, int cents)
        {
            this.dollars = dollars;
            this.cents = cents;
        }

        override public string ToString()
        {
            return $"{dollars}.{cents:D2}";
        }

        public static Money operator +(Money a, Money b)
        {
            int totalCents = a.dollars * 100 + a.cents + b.dollars * 100 + b.cents;
            return new Money(totalCents / 100, totalCents % 100);
        }

        public static Money operator -(Money a, Money b)
        {
            int totalCents = a.dollars * 100 + a.cents - (b.dollars * 100 + b.cents);
            return new Money(totalCents / 100, totalCents % 100);
        }
    }

    public class Product: Money {
        public string name;

        public double Price
        {
            get { return dollars + cents / 100.0; }
        }
        public Product(string name, int dollars, int cents) : base(dollars, cents)
        {
            this.name = name;
        }

        override public string ToString()
        {
            return $"{name} {base.ToString()}";
        }

        public void DecreasePrice(int dollars, int cents)
        {
            Money decrease = new Money(dollars, cents);
            double decreasePrice = decrease.dollars + decrease.cents / 100.0;
            if (Price - decreasePrice < 0)
            {
                throw new InvalidOperationException("Price cannot be negative");
            }
            this.dollars -= decrease.dollars;
            this.cents -= decrease.cents;
            if (this.cents < 0)
            {
                this.dollars--;
                this.cents += 100;
            }
        }

        public void IncreasePrice(int dollars, int cents)
        {
            this.dollars += dollars;
            this.cents += cents;
            if (this.cents >= 100)
            {
                this.dollars++;
                this.cents -= 100;
            }
        }
    }

    public class Device {
        public virtual void Sound()
        {
            Console.WriteLine("Beep!");
        }

        public virtual void Show()
        {
            Console.WriteLine("Device is showing something.");
        }

        public virtual void Desc() {
            Console.WriteLine("This is a device.");
        }
    }

    public class Kettle : Device {
        public override void Sound()
        {
            Console.WriteLine("Kettle is boiling!");
        }

        public override void Show()
        {
            Console.WriteLine("Kettle is showing its status.");
        }

        public override void Desc() {
            Console.WriteLine("This is a kettle.");
        }
    }

    public class Microwave : Device {
        public override void Sound()
        {
            Console.WriteLine("Microwave is beeping!");
        }

        public override void Show()
        {
            Console.WriteLine("Microwave is showing its status.");
        }

        public override void Desc() {
            Console.WriteLine("This is a microwave.");
        }
    }

    public class Car: Device {
        public override void Sound()
        {
            Console.WriteLine("Car is honking!");
        }

        public override void Show()
        {
            Console.WriteLine("Car is showing its status.");
        }

        public override void Desc() {
            Console.WriteLine("This is a car.");
        }
    }

    public class Steamer: Device {
        public override void Sound()
        {
            Console.WriteLine("Steamer is steaming!");
        }

        public override void Show()
        {
            Console.WriteLine("Steamer is showing its status.");
        }

        public override void Desc() {
            Console.WriteLine("This is a steamer.");
        }
    }

    public class MusicalInstrument: Device {
        public override void Sound()
        {
            Console.WriteLine("Musical instrument is playing");
        }

        public override void Show()
        {
            Console.WriteLine("Musical instrument is being shown.");
        }

        public override void Desc() {
            Console.WriteLine("This is a musical instrument.");
        }

        public virtual void History()
        {
            Console.WriteLine("This musical instrument has a rich history.");
        }

    }

    public class Violin: MusicalInstrument {
        public override void Sound()
        {
            Console.WriteLine("Violin is playing");
        }
        public override void Show()
        {
            Console.WriteLine("Violin is being shown.");
        }
        public override void Desc() {
            Console.WriteLine("This is a violin.");
        }
        public override void History()
        {
            Console.WriteLine("");
        }
    }

    public class Trombone: MusicalInstrument {
        public override void Sound()
        {
            Console.WriteLine("Trombone is playing");
        }

        public override void Show()
        {
            Console.WriteLine("Trombone is being shown.");
        }

        public override void Desc() {
            Console.WriteLine("This is a trombone.");
        }

        public override void History()
        {
            Console.WriteLine("Trombone has a rich history.");
        }
    }

    public class Ukulele: MusicalInstrument {
        public override void Sound()
        {
            Console.WriteLine("Ukulele is playing");
        }
        public override void Show()
        {
            Console.WriteLine("Ukulele is being shown.");
        }

        public override void Desc() {
            Console.WriteLine("This is a ukulele.");
        }

        public override void History()
        {
            Console.WriteLine("Ukulele has a rich history.");
        }
    }

    public class ViolonCello: MusicalInstrument {
        public override void Sound()
        {
            Console.WriteLine("ViolonCello is playing");
        }

        public override void Show()
        {
            Console.WriteLine("ViolonCello is being shown.");
        }

        public override void Desc() {
            Console.WriteLine("This is a ViolonCello.");
        }

        public override void History()
        {
            Console.WriteLine("ViolonCello has a rich history.");
        }

    }

    public abstract class Worker {
        public virtual void Print()
        {
            Console.WriteLine("Worker is working.");
        }
    }

    public class President: Worker {
        public override void Print()
        {
            Console.WriteLine("President is leading the country.");
        }
    }

    public class Security: Worker {
        public override void Print()
        {
            Console.WriteLine("Security is ensuring safety.");
        }
    }

    public class Manager: Worker {
        public override void Print()
        {
            Console.WriteLine("Manager is managing the team.");
        }
    }

    public class Engineer: Worker {
        public override void Print()
        {
            Console.WriteLine("Engineer is designing solutions.");
        }
    }

    public class Course {
        public string Name { get; set; }
        public int Duration { get; set; }

        public Course(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"Course: {Name}, Duration: {Duration} hours";
        }
    }

    public class OnlineCourse : Course {
        public string Platform { get; set; }
        public OnlineCourse(string name, int duration, string platform) : base(name, duration)
        {
            Platform = platform;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Platform: {Platform}";
        }
    }

    public abstract class Product2 {
        public string Name { get; set; }
        public Money Price { get; set; }

        public Product2(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }

        public abstract void CalculateDiscount(int percentage);
    }

    public class Electronics : Product2 {
        public Electronics(string name, Money price) : base(name, price) { }

        public override void CalculateDiscount(int percentage)
        {
            int discountDollars = (Price.dollars * percentage) / 100;
            int discountCents = (Price.cents * percentage) / 100;
            Money discount = new Money(discountDollars*2, discountCents*2);
            Price -= discount;
        }
        public override string ToString()
        {
            return $"Electronics: {base.ToString()}";
        }
    }

    public class Furniture : Product2 {
        public Furniture(string name, Money price) : base(name, price) { }

        public override void CalculateDiscount(int percentage)
        {
            int discountDollars = (Price.dollars * percentage) / 100;
            int discountCents = (Price.cents * percentage) / 100;
            Money discount = new Money(discountDollars, discountCents);
            Price -= discount;
        }

        public override string ToString()
        {
            return $"Furniture: {base.ToString()}";
        }

    }

        class Program
    {
        static void Main(string[] args)
        {
            // Course course = new Course("Programming Basics", 40);
            // OnlineCourse onlineCourse = new OnlineCourse("Advanced Programming", 60, "Coursera");
            // Console.WriteLine(course);
            // Console.WriteLine(onlineCourse);

            Product2[] products = new Product2[]
            {
                new Electronics("Laptop", new Money(1000, 99)),
                new Furniture("Chair", new Money(150, 50))
            };

            foreach (var product in products)
            {
                Console.WriteLine(product);
                product.CalculateDiscount(10);
                Console.WriteLine("After discount: " + product);
            }
        }
    }

}
