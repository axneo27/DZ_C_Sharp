namespace dz12
{
    public class Company
    {
        public string Name { get; set; }
        public DateTime FoundingDate { get; set; }
        public string BusinessProfile { get; set; }
        public string CEO_PIB { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }
        public List<Worker> Workers { get; set; } = new List<Worker>();

        public Company(string name, DateTime foundingDate, string businessProfile,
                      string ceo_pib, int employeeCount, string address)
        {
            Name = name;
            FoundingDate = foundingDate;
            BusinessProfile = businessProfile;
            CEO_PIB = ceo_pib;
            EmployeeCount = employeeCount;
            Address = address;
        }

        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }

        public override string ToString()
        {
            string companyInfo = $"{Name}, {FoundingDate.ToShortDateString()}, {BusinessProfile}, " +
                   $"{CEO_PIB}, {EmployeeCount}, {Address}\n";
            
            string workersInfo = "Workers:\n";
            foreach (var worker in Workers)
            {
                workersInfo += $"\t{worker}\n";
            }
            
            return companyInfo + workersInfo + "---------------------------";
        }
    }

    public class Worker { 
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        
        public Worker(string fullName, string position, string contactPhone, string email, decimal salary)
        {
            FullName = fullName;
            Position = position;
            ContactPhone = contactPhone;
            Email = email;
            Salary = salary;
        }
        
        public override string ToString()
        {
            return $"{FullName}, {Position}, {ContactPhone}, {Email}, {Salary}";
        }
    }

    class Program
    {
        static List<Company> InitializeCompaniesWithWorkers()
        {
            var companies = new List<Company>
            {
                new Company("Tech Innovations", new DateTime(2005, 3, 15), "Software Development",
                            "Ivanov I.I.", 150, "123 Tech Street, London"),
                new Company("Green Solutions", new DateTime(2010, 6, 20), "Environmental Consulting",
                            "Petrov P.P.", 80, "456 Green Avenue"),
                new Company("HealthCare Plus", new DateTime(2000, 1, 10), "Healthcare Services",
                            "Sidorov S.S.", 200, "789 Health Blvd"),
                new Company("Foodies Delight", new DateTime(2022, 8, 5), "Food and Beverage",
                            "Kuznetsov K.K.", 50, "321 Food Lane"),
                new Company("Marketing Masters", new DateTime(2024, 11, 30), "Marketing",
                            "Vasiliev V.V.", 120, "654 Market Street"),
                new Company("IT Solutions", new DateTime(2025, 4, 25), "IT",
                            "White S.S.", 90, "987 IT Park"),
            };

            companies[0].AddWorker(new Worker("John Smith", "Software Engineer", "+123456789", "john@tech.com", 5000));
            companies[0].AddWorker(new Worker("Alice Johnson", "Project Manager", "+987654321", "alice@tech.com", 7000));
            companies[0].AddWorker(new Worker("Bob Brown", "QA Engineer", "+112233445", "bob@tech.com", 4500));

            companies[1].AddWorker(new Worker("Emma Wilson", "Environmental Specialist", "+334455667", "emma@green.com", 4000));
            companies[1].AddWorker(new Worker("David Lee", "Consultant", "+778899001", "david@green.com", 5500));

            companies[2].AddWorker(new Worker("Sarah Connor", "Doctor", "+445566778", "sarah@health.com", 8000));
            companies[2].AddWorker(new Worker("Mike Peterson", "Nurse", "+889900112", "mike@health.com", 3500));
            companies[2].AddWorker(new Worker("Lisa Wong", "Administrator", "+223344556", "lisa@health.com", 4000));

            companies[3].AddWorker(new Worker("James Cook", "Chef", "+667788990", "james@food.com", 3000));
            companies[3].AddWorker(new Worker("Olivia Baker", "Manager", "+990011223", "olivia@food.com", 4500));

            companies[4].AddWorker(new Worker("Sophia Garcia", "Marketing Specialist", "+112233445", "sophia@marketing.com", 4800));
            companies[4].AddWorker(new Worker("Daniel Kim", "Graphic Designer", "+556677889", "daniel@marketing.com", 4200));

            companies[5].AddWorker(new Worker("Robert White", "IT Specialist", "+998877665", "robert@it.com", 6000));
            companies[5].AddWorker(new Worker("Jennifer Black", "System Administrator", "+443322110", "jennifer@it.com", 6500));

            return companies;
        }

        static void PrintResults(string title, IEnumerable<Company> results)
        {
            Console.WriteLine($"\n{title}:");
            foreach (var c in results) Console.WriteLine(c);
        }

        static void PrintWorkerResults(string title, IEnumerable<Worker> results)
        {
            Console.WriteLine($"\n{title}:");
            foreach (var w in results) Console.WriteLine(w);
        }

        static void ex1()
        {
            var companies = InitializeCompaniesWithWorkers();
            var allCompanies = from c in companies select c;
            PrintResults("All companies", allCompanies);

            var foodCompanies = from c in companies where c.Name.Contains("Food") select c;
            PrintResults("Food companies", foodCompanies);

            var marketingCompanies = from c in companies where c.BusinessProfile == "Marketing" select c;
            PrintResults("Marketing companies", marketingCompanies);

            var marketingOrITCompanies = from c in companies 
                                      where c.BusinessProfile == "Marketing" || c.BusinessProfile == "IT" 
                                      select c;
            PrintResults("Marketing or IT companies", marketingOrITCompanies);

            var companies100Plus = from c in companies where c.EmployeeCount > 100 select c;
            PrintResults("Companies with >100 employees", companies100Plus);

            var companies100to300 = from c in companies 
                                  where c.EmployeeCount >= 100 && c.EmployeeCount <= 300 
                                  select c;
            PrintResults("Companies with 100-300 employees", companies100to300);

            var londonCompanies = from c in companies where c.Address.Contains("London") select c;
            PrintResults("London companies", londonCompanies);

            var whiteCEOCompanies = from c in companies where c.CEO_PIB.Contains("White") select c;
            PrintResults("Companies with CEO 'White'", whiteCEOCompanies);

            var companiesOlder2Years = from c in companies 
                                     where (DateTime.Now - c.FoundingDate).TotalDays > 365 * 2 
                                     select c;
            PrintResults("Companies older than 2 years", companiesOlder2Years);

            var companies123Days = from c in companies 
                                 where (DateTime.Now - c.FoundingDate).TotalDays >= 123 
                                 select c;
            PrintResults("Companies 123+ days old", companies123Days);

            var blackWhiteCompanies = from c in companies 
                                    where c.CEO_PIB.Contains("Black") && c.Name.Contains("White") 
                                    select c;
            PrintResults("Companies with Black CEO and White in name", blackWhiteCompanies);
        }

        static void ex2() 
        {
            var companies = InitializeCompaniesWithWorkers();
            PrintResults("All companies", companies);

            PrintResults("Food companies", companies.Where(c => c.Name.Contains("Food")));

            PrintResults("Marketing companies", companies.Where(c => c.BusinessProfile == "Marketing"));

            PrintResults("Marketing or IT companies", 
                companies.Where(c => c.BusinessProfile == "Marketing" || c.BusinessProfile == "IT"));

            PrintResults("Companies with >100 employees", companies.Where(c => c.EmployeeCount > 100));

            PrintResults("Companies with 100-300 employees", 
                companies.Where(c => c.EmployeeCount >= 100 && c.EmployeeCount <= 300));

            PrintResults("London companies", companies.Where(c => c.Address.Contains("London")));

            PrintResults("Companies with CEO 'White'", companies.Where(c => c.CEO_PIB.Contains("White")));

            PrintResults("Companies older than 2 years", 
                companies.Where(c => (DateTime.Now - c.FoundingDate).TotalDays > 365 * 2));

            PrintResults("Companies 123+ days old", 
                companies.Where(c => (DateTime.Now - c.FoundingDate).TotalDays >= 123));

            PrintResults("Companies with Black CEO and White in name", 
                companies.Where(c => c.CEO_PIB.Contains("Black") && c.Name.Contains("White")));
        }

        static void ex3() { 
            var companies = InitializeCompaniesWithWorkers();
            var TechInnovationsWorkers = from w in companies[0].Workers select w;
            PrintWorkerResults("Tech Innovations Workers", TechInnovationsWorkers);

            var TechInnovationWorkersWithSalaryOver5000 = from w in companies[0].Workers where w.Salary > 5000 select w;
            PrintWorkerResults("Tech Innovations Workers with salary > 5000", TechInnovationWorkersWithSalaryOver5000);

            var AllManagerWorkers = from c in companies from w in c.Workers where w.Position.Contains("Manager") select w;
            PrintWorkerResults("All Manager Workers", AllManagerWorkers);

            var AllWorkersPhoneStartsWith23 = from c in companies from w in c.Workers where w.ContactPhone.StartsWith("+23") select w;
            PrintWorkerResults("All Workers with phone starting with +23", AllWorkersPhoneStartsWith23);

            var AllWorkersEmailStartsWithDI = from c in companies from w in c.Workers where w.Email.StartsWith("di") select w;
            PrintWorkerResults("All Workers with email starting with 'di'", AllWorkersEmailStartsWithDI);

            var AllWorkersNameLionel = from c in companies from w in c.Workers where w.FullName.Contains("Lionel") select w;
            PrintWorkerResults("All Workers with name containing 'Lionel'", AllWorkersNameLionel);
                                        
        }

        static int DigitSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        static void ex4() { 
            List<int> numbers = new List<int> { 121, 75, 81 };

            var sortedAsc = from n in numbers
                            orderby DigitSum(n) ascending
                            select n;

            var sortedDesc = from n in numbers
                            orderby DigitSum(n) descending
                            select n;

            Console.WriteLine("Sorted by digit sum ascending:");
            printNums(sortedAsc.ToList());
            Console.WriteLine("Sorted by digit sum descending:");
            printNums(sortedDesc.ToList());
        }

        static void printNums(List<int> numbers)
        {
            foreach (var n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // ex1();

            // ex2();

            // ex3();

            ex4();
        }
    }
}
