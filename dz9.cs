
namespace dz9 {

    // ex2
    public class Worker { 
        public string Login { get; set; }
        public string Password { get; set; }

        public Worker(string login, string password) {
            Login = login;
            Password = password;
        }

        public override string ToString() {
            return $"Login: {Login}, Password: {Password}";
        }
    }

    public static class WorkerProgram {

        public static Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();
        public static void Run() {
            while (true) { 
                Console.WriteLine("1. Add Worker");
                Console.WriteLine("2. Remove Worker");
                Console.WriteLine("3. Change Login");
                Console.WriteLine("4. Change Password");
                Console.WriteLine("5. Print Workers");
                Console.WriteLine("6. Get Info Worker");
                Console.WriteLine("7. Exit");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        Console.Write("Enter login: ");
                        string login = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine() ?? string.Empty;
                        AddWorker(login, password);
                        break;
                    case "2":
                        Console.Write("Enter login to remove: ");
                        string removeLogin = Console.ReadLine() ?? string.Empty;
                        RemoveWorker(removeLogin);
                        break;
                    case "3":
                        Console.Write("Enter old login: ");
                        string oldLogin = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter new login: ");
                        string newLogin = Console.ReadLine() ?? string.Empty;
                        ChangeLogin(oldLogin, newLogin);
                        break;
                    case "4":
                        Console.Write("Enter login: ");
                        string changeLogin = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter new password: ");
                        string newPassword = Console.ReadLine() ?? string.Empty;
                        ChangePassword(changeLogin, newPassword);
                        break;
                    case "5":
                        PrintWorkers();
                        break;
                    case "6":
                        Console.Write("Enter login to get info: ");
                        string infoLogin = Console.ReadLine() ?? string.Empty;
                        GetInfoWorker(infoLogin);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
        }

        public static void AddWorker(string login, string password) {
            if (!Workers.ContainsKey(login)) {
                Workers[login] = new Worker(login, password);
            } else {
                Console.WriteLine("Worker with this login already exists.");
            }
        }

        public static void RemoveWorker(string login) {
            if (Workers.ContainsKey(login)) {
                Workers.Remove(login);
            } else {
                Console.WriteLine("Worker with this login does not exist.");
            }
        }

        public static void ChangeLogin(string oldLogin, string newLogin) {
            if (Workers.ContainsKey(oldLogin)) {
                if (!Workers.ContainsKey(newLogin)) {
                    Worker worker = Workers[oldLogin];
                    Workers.Remove(oldLogin);
                    worker.Login = newLogin;
                    Workers[newLogin] = worker;
                } else {
                    Console.WriteLine("New login already exists.");
                }
            } else {
                Console.WriteLine("Worker with this login does not exist.");
            }
        }

        public static void ChangePassword(string login, string newPassword) {
            if (Workers.ContainsKey(login)) {
                Workers[login].Password = newPassword;
            } else {
                Console.WriteLine("Worker with this login does not exist.");
            }
        }

        public static void PrintWorkers() {
            foreach (var worker in Workers.Values) {
                Console.WriteLine(worker);
            }
        }

        public static void GetInfoWorker(string login) {
            if (Workers.ContainsKey(login)) {
                Console.WriteLine(Workers[login]);
            } else {
                Console.WriteLine("Worker with this login does not exist.");
            }
        }
    }

    public static class EngUkDictionary {
        public static Dictionary<string, List<string>> langDict = new Dictionary<string, List<string>>() {
            { "hello", new List<string> { "привіт", "здрастуйте" } },
            { "goodbye", new List<string> { "до побачення", "бувай" } },
            { "please", new List<string> { "будь ласка" } },
            { "thank you", new List<string> { "дякую", "спасибі" } },
            { "yes", new List<string> { "так" } },
            { "no", new List<string> { "ні" } }
        };

        public static void Run() { 
            while (true) {
                Console.WriteLine("1. Add Word");
                Console.WriteLine("2. Remove Word");
                Console.WriteLine("3. Remove Translation Variant");
                Console.WriteLine("4. Change Word");
                Console.WriteLine("5. Change Translation Variant");
                Console.WriteLine("6. Find Translation");
                Console.WriteLine("7. Exit");

                string? choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        Console.Write("Enter English word: ");
                        string english = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter Ukrainian translations (comma separated): ");
                        string ukraineInput = Console.ReadLine() ?? string.Empty;
                        string lowerUkraineInput = ukraineInput.ToLower();
                        List<string> ukraine = lowerUkraineInput.Split(',').Select(s => s.Trim()).ToList();

                        AddWord(english, ukraine);
                        break;
                    case "2":
                        Console.Write("Enter English word to remove: ");
                        string removeEnglish = Console.ReadLine() ?? string.Empty;
                        RemoveWord(removeEnglish);
                        break;
                    case "3":
                        Console.Write("Enter English word: ");
                        string wordToRemoveVariant = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter Ukrainian translation variant to remove: ");
                        string ukraineToRemove = Console.ReadLine() ?? string.Empty;
                        RemoveTranslationVariant(wordToRemoveVariant, ukraineToRemove);
                        break;
                    case "4":
                        Console.Write("Enter old English word: ");
                        string oldEnglish = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter new English word: ");
                        string newEnglish = Console.ReadLine() ?? string.Empty;
                        ChangeWord(oldEnglish, newEnglish);
                        break;
                    case "5":
                        Console.Write("Enter English word: ");
                        string changeWord = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter old Ukrainian translation variant: ");
                        string oldUkraine = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter new Ukrainian translation variant: ");
                        string newUkraine = Console.ReadLine() ?? string.Empty;
                        ChangeTranslationVariant(changeWord, oldUkraine, newUkraine);
                        break;
                    case "6":
                        Console.Write("Enter English word to find translation: ");
                        string findEnglish = Console.ReadLine() ?? string.Empty;
                        FindTranslation(findEnglish);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void AddWord(string english, List<string> ukraine) {
            if (!ContainsEnglishWord(english)) { 
                langDict[english.ToLower()] = ukraine;
            } else {
                Console.WriteLine("This word already exists in the dictionary.");
            }
        }

        public static void RemoveWord(string english) {
            if (ContainsEnglishWord(english)) {
                langDict.Remove(english.ToLower());
            } else {
                Console.WriteLine("This word does not exist in the dictionary.");
            }
        }

        public static void RemoveTranslationVariant(string english, string ukraine) {
            if (ContainsUkrainianTranslation(english, ukraine)) {
                List<string> translations = langDict[english.ToLower()];
                translations.Remove(ukraine.ToLower());
            } else {
                Console.WriteLine("This translation variant does not exist for the given word.");
            }
        }

        public static void ChangeWord(string oldEnglish, string newEnglish) {
            if (ContainsEnglishWord(oldEnglish) && !ContainsEnglishWord(newEnglish)) {
                List<string> translations = langDict[oldEnglish];
                langDict.Remove(oldEnglish);
                langDict[newEnglish.ToLower()] = translations;
            } else {
                Console.WriteLine("This word does not exist or the new word already exists.");
            }
        }

        public static void ChangeTranslationVariant(string english, string oldUkraine, string newUkraine) {
            if (ContainsUkrainianTranslation(english, oldUkraine) && !ContainsUkrainianTranslation(english, newUkraine)) {
                List<string> translations = langDict[english];
                int index = translations.IndexOf(oldUkraine);
                if (index != -1) {
                    translations[index] = newUkraine.ToLower();
                }
            } else {
                Console.WriteLine("This translation variant does not exist or the new translation already exists.");
            }
        }

        public static void FindTranslation(string english) {
            if (ContainsEnglishWord(english)) {
                Console.WriteLine($"Translations for '{english}':");
                foreach (var translation in langDict[english.ToLower()]) {
                    Console.Write($"{translation}, ");
                }
                Console.WriteLine();
            } else {
                Console.WriteLine("This word does not exist in the dictionary.");
            }
        }

        private static bool ContainsEnglishWord(string english) {
            foreach (var key in langDict.Keys) {
                if (string.Equals(key, english.ToLower())) {
                    return true;
                }
            }
            return false;
        }

        private static bool ContainsUkrainianTranslation(string english, string ukraine) {
            if (ContainsEnglishWord(english)) {
                foreach (var translation in langDict[english]) {
                    if (string.Equals(translation, ukraine.ToLower())) {
                        return true;
                    }
                }
            }
            return false;
        }
    } 

    class Program {

        // ex1
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        

        static void Main(string[] args)
        {
            // ex1
            // int a = 5;
            // int b = 10;
            // Console.WriteLine($"Before swap: a = {a}, b = {b}");
            // Swap(ref a, ref b);
            // Console.WriteLine($"After swap: a = {a}, b = {b}");

            // ex2
            // WorkerProgram.Run();
            // // ex3
            // EngUkDictionary.Run();
        }

    }


}
