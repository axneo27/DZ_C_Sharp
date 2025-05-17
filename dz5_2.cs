using System;

namespace dz5_2
{

    class Magazine {
        public string name {private set; get; }
        public int foundationYear {private set; get; }
        public string description {private set; get; }
        public string phoneNumber {private set; get; }
        public string email {private set; get; }
        private int workersCount;

        public int WorkersCount
        {
            get { return workersCount; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Workers count cannot be negative.");
                }
                else
                {
                    workersCount = value;
                }
            }
        }

        public Magazine(string name, int foundationYear, string description, string phoneNumber, string email, int wc)
        {
            this.name = name;
            this.foundationYear = foundationYear;
            this.description = description;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.workersCount = wc;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public static Magazine operator +(Magazine magazine, int wc)
        {
            magazine.WorkersCount += wc;
            return magazine;
        }

        public static Magazine operator -(Magazine magazine, int wc)
        {
            if (magazine.WorkersCount - wc < 0)
            {
                Console.WriteLine("Cannot remove more workers than available.");
                return magazine;
            }
            magazine.WorkersCount -= wc;
            return magazine;
        }

        public static bool operator ==(Magazine magazine1, Magazine magazine2)
        {
            return magazine1.workersCount == magazine2.workersCount;
        }

        public static bool operator !=(Magazine magazine1, Magazine magazine2)
        {
            return magazine1.workersCount != magazine2.workersCount;
        }

        public override bool Equals(object obj)
        {
            if (obj is Magazine magazine)
            {
                return this == magazine;
            }
            return false;
        }

        public static bool operator >(Magazine magazine1, Magazine magazine2)
        {
            return magazine1.workersCount > magazine2.workersCount;
        }

        public static bool operator <(Magazine magazine1, Magazine magazine2)
        {
            return magazine1.workersCount < magazine2.workersCount;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Magazine Name: {name}");
            Console.WriteLine($"Foundation Year: {foundationYear}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Workers Count: {workersCount}");
        }

    }

    class Shop {
        public string name {private set; get; }
        public string address {private set; get; }
        public string description {private set; get; }
        public string phoneNumber {private set; get; }
        public string email {private set; get; }

        private int area;
        public int Area
        {
            get { return area; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Area cannot be negative.");
                }
                else
                {
                    area = value;
                }
            }
        }

        public Shop(string name, string address, string description, string phoneNumber, string email)
        {
            this.name = name;
            this.address = address;
            this.description = description;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public static Shop operator +(Shop shop, int area)
        {
            shop.Area += area;
            return shop;
        }

        public static Shop operator -(Shop shop, int area)
        {
            if (shop.Area - area < 0)
            {
                Console.WriteLine("Area cannot be negative.");
                return shop;
            }
            shop.Area -= area;
            return shop;
        }

        public static bool operator ==(Shop shop1, Shop shop2)
        {
            return shop1.area == shop2.area;
        }

        public static bool operator !=(Shop shop1, Shop shop2)
        {
            return shop1.area != shop2.area;
        }

        public override bool Equals(object obj)
        {
            if (obj is Shop shop)
            {
                return this == shop;
            }
            return false;
        }

        public static bool operator >(Shop shop1, Shop shop2)
        {
            return shop1.area > shop2.area;
        }

        public static bool operator <(Shop shop1, Shop shop2)
        {
            return shop1.area < shop2.area;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Shop Name: {name}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Area: {area}");
        }

    }

    public class Book
    {
        public string name {private set; get; }
        public string author {private set; get; }
        public int year {private set; get; }
        public string description {private set; get; }
        public Book(string name, string author, int year, string description)
        {
            this.name = name;
            this.author = author;
            this.year = year;
            this.description = description;
        }

        public Book() : this("Unknown", "Unknown", 0, "No description") {}

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Book Name: {name}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"Description: {description}");
        }

    }

    public class BookList
    {
        private Book[] books;
        public int count { private set; get; }

        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine("Invalid index.");
                    return new Book();
                }
                return books[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine("Invalid index.");
                    return;
                }
                books[index] = value;
            }
        }
       
        public BookList()
        {
            count = 0;
        }

        private void AddBook(Book book)
        {
            if (books == null)
            {
                books = new Book[1];
                books[0] = book;
            }
            else
            {
                Book[] newBooks = new Book[books.Length + 1];
                for (int i = 0; i < books.Length; i++)
                {
                    newBooks[i] = books[i];
                }
                newBooks[books.Length] = book;
                books = newBooks;
            }
            count++;
        }

        public static BookList operator +(BookList bookList, Book book)
        {
            bookList.AddBook(book);
            return bookList;
        }

        public void RemoveBook(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }
            Book[] newBooks = new Book[books.Length - 1];
            for (int i = 0, j = 0; i < books.Length; i++)
            {
                if (i != index)
                {
                    newBooks[j++] = books[i];
                }
            }
            books = newBooks;
            count--;
        }

        public int findBookByName(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i].name == name)
                {
                    books[i].PrintInfo();
                    return i;
                }
            }
            return -1;
        }

        public void PrintBooks()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Book {i + 1}:");
                books[i].PrintInfo();
                Console.WriteLine();
            }
        }
    }

    class TemperatureArray {
        private double[] temperatures = new double[7];

        public TemperatureArray() {}

        public double this[int index] {
            get {
                if (index < 0 || index >= temperatures.Length) {
                    Console.WriteLine("Invalid index.");
                    return 0;
                }
                return temperatures[index];
            }
            set {
                if (index < 0 || index >= temperatures.Length) {
                    Console.WriteLine("Invalid index.");
                    return;
                }
                temperatures[index] = value;
            }
        }

        public double AverageTemperature() {
            double sum = 0;
            for (int i = 0; i < temperatures.Length; i++) {
                sum += temperatures[i];
            }
            return sum / temperatures.Length;
        }
    }

    public class Fraction {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Denominator cannot be zero.");
                }
                else
                {
                    denominator = value;
                }
            }
        }

        public Fraction(int numerator, int denominator) {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static int findCommonDivisor(int a, int b) {
            while (b != 0) {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public void Reduce() {
            int commonDivisor = findCommonDivisor(numerator, denominator);
            numerator /= commonDivisor;
            denominator /= commonDivisor;
        }

        public static Fraction operator +(Fraction f1, Fraction f2) {
            Fraction newFraction =  new Fraction(f1.numerator * f2.denominator + f2.numerator * f1.denominator, f1.denominator * f2.denominator);
            newFraction.Reduce();
            return newFraction;
        }

        public static Fraction operator -(Fraction f1, Fraction f2) {
            Fraction newFraction = new Fraction(f1.numerator * f2.denominator - f2.numerator * f1.denominator, f1.denominator * f2.denominator);
            newFraction.Reduce();
            return newFraction;
        }

        public static Fraction operator *(Fraction f1, Fraction f2) {
            Fraction newFraction = new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator);
            newFraction.Reduce();
            return newFraction;
        }

        public static Fraction operator /(Fraction f1, Fraction f2) {
            Fraction newFraction = new Fraction(f1.numerator * f2.denominator, f1.denominator * f2.numerator);
            newFraction.Reduce();
            return newFraction;
        }

        public static bool operator ==(Fraction f1, Fraction f2) {
            return f1.numerator * f2.denominator == f2.numerator * f1.denominator;
        }

        public static bool operator !=(Fraction f1, Fraction f2) {
            return !(f1 == f2);
        }
    }

    class Product {
        public string name {private set; get; }
        public double price {private set; get; }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Quantity cannot be negative.");
                }
                else
                {
                    quantity = value;
                }
            }
        }

        public Product(string name, double price, int quantity) {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public static Product operator +(Product product, int quantity) {
            product.quantity += quantity;
            return product;
        }

        public static Product operator -(Product product, int quantity) {
            product.quantity -= quantity;
            return product;
        }

        public static bool operator ==(Product product1, Product product2) {
            return product1.name == product2.name && product1.price == product2.price;
        }

        public static bool operator !=(Product product1, Product product2) {
            return !(product1 == product2);
        }

        public static bool operator >(Product product1, Product product2) {
            return product1.price > product2.price;
        }

        public static bool operator <(Product product1, Product product2) {
            return product1.price < product2.price;
        }

        public override bool Equals(object obj) {
            if (obj is Product product) {
                return this == product;
            }
            return false;
        }



        public void PrintInfo() {
            Console.WriteLine($"Product Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Quantity: {quantity}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Magazine magazine = new Magazine("a", 1, "a", "123", "a", 123);
            // magazine += 5;
            // magazine.PrintInfo();

            // Book book1 = new Book("a", "a", 1, "a");
            // Book book2 = new Book("b", "b", 2, "b");
            // Book book3 = new Book("c", "c", 3, "c");
            // Console.WriteLine();

            // BookList bookList = new BookList();
            // bookList += book1;
            // bookList += book2;
            // bookList += book3;
            // bookList.PrintBooks();

            // bookList.RemoveBook(1);
            // Console.WriteLine("After removing book at index 1:");
            // bookList.PrintBooks();

            // int foundIndex = bookList.findBookByName("c");
            // if (foundIndex != -1)
            // {
            //     Console.WriteLine();
            //     Console.WriteLine($"Book found at index {foundIndex}:");
            //     bookList[foundIndex].PrintInfo();
            // }
            // else
            // {
            //     Console.WriteLine("Book not found.");
            // }
        }
    }
}
