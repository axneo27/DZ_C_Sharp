using System.Text.Json;

namespace fin1 {

    public static class StringExtensions
    { 
        public static string FirstLetterToUpperCaseOrConvertNullToEmptyString(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }

    public enum Direction
    {
        Up,
        Down
    }

    public class DictionaryException : Exception
    {
        public DictionaryException() { }

        public DictionaryException(string message) 
            : base(message) { }

        public DictionaryException(string message, Exception innerException)
            : base(message, innerException) { }    
    }

    public class LanguageDictionary
    { 
        public string Name { get; set; }
        public Dictionary<string, List<string>> LangDict { get; set; } = new Dictionary<string, List<string>>();

        private int selectedItem = 0;

        public void AddWord(string firstLang, List<string> secondLang) 
        {
            if (!ContainsLanguageWord(firstLang)) 
            { 
                LangDict[firstLang.ToLower()] = secondLang;
            } 
            else 
            {
                throw new DictionaryException("This word already exists in the dictionary.");
            }
        }

        public void RemoveWord(string firstLang) 
        {
            if (ContainsLanguageWord(firstLang)) 
            {
                LangDict.Remove(firstLang.ToLower());
            } 
            else 
            {
                throw new DictionaryException("This word does not exist in the dictionary.");
            }
        }

        public void RemoveTranslationVariant(string firstLang, string secondLang) 
        {
            if (!ContainsLanguageWord(firstLang))
            {
                throw new DictionaryException("The source word does not exist in the dictionary.");
            }
            
            if (!ContainsLanguageTranslation(firstLang, secondLang)) 
            {
                throw new DictionaryException("This translation variant does not exist for the given word.");
            }

            List<string> translations = LangDict[firstLang.ToLower()];
            if (translations.Count == 1) 
            { 
                throw new DictionaryException("Cannot remove the last translation variant.");
            }
            
            translations.Remove(secondLang.ToLower());
        }

        public void AddTranslationVariant(string firstLang, string secondLang) 
        {
            if (!ContainsLanguageWord(firstLang))
            {
                throw new DictionaryException("The source word does not exist in the dictionary.");
            } else if (string.IsNullOrEmpty(secondLang)) { 
                throw new DictionaryException("The translation variant cannot be empty.");
            }

            if (!ContainsLanguageTranslation(firstLang, secondLang)) 
            {
                LangDict[firstLang.ToLower()].Add(secondLang.ToLower());
            } else { 
                throw new DictionaryException("This translation variant already exists for the given word.");
            }
        }

        public void ChangeTranslationVariant(string firstLang, string oldSecondLang, string newSecondLang) 
        {
            if (string.IsNullOrEmpty(newSecondLang)) 
            {
                throw new DictionaryException("The translation variant cannot be empty.");
            }
            if (!ContainsLanguageWord(firstLang))
            {
                throw new DictionaryException("The source word does not exist in the dictionary.");
            }
            if (!ContainsLanguageTranslation(firstLang, oldSecondLang)) 
            {
                throw new DictionaryException("The original translation variant does not exist.");
            }
            if (ContainsLanguageTranslation(firstLang, newSecondLang)) 
            {
                throw new DictionaryException("The new translation already exists for this word.");
            }

            List<string> translations = LangDict[firstLang];
            int index = translations.IndexOf(oldSecondLang);
            if (index != -1) 
            {
                translations[index] = newSecondLang.ToLower();
            }
        }

        public List<string> FindTranslation(string lang) 
        {
            if (!ContainsLanguageWord(lang)) 
            {
                throw new DictionaryException("This word does not exist in the dictionary.");
            }
            
            return LangDict[lang.ToLower()];
        }

        private bool ContainsLanguageWord(string lang) 
        {
            return LangDict.ContainsKey(lang.ToLower());
        }

        private bool ContainsLanguageTranslation(string firstLang, string secondLang) 
        {
            if (ContainsLanguageWord(firstLang)) 
            {
                return LangDict[firstLang.ToLower()]
                    .Any(translation => string.Equals(translation.ToLower(), secondLang.ToLower()));
            }
            return false;
        }

        public void Run() { 
            while (true) { 
                Console.Clear();
                PrintWords();

                var key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.UpArrow)
                {
                    Move(Direction.Up);
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    Move(Direction.Down);
                }
                else if (key.Key == ConsoleKey.C) { 
                    WordCreation();
                }
                else if (key.Key == ConsoleKey.D) {
                    try { 
                        RemoveWord(LangDict.ElementAt(selectedItem).Key);
                    }
                    catch (Exception ex) { 
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1000);
                    }
                    
                }
                else if (key.Key == ConsoleKey.Enter) { 
                    RunWordInfo(LangDict.ElementAt(selectedItem).Key);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private void WordCreation() {
            Console.Clear();
            Console.WriteLine("Enter the word in the first language:");
            var firstLang = Console.ReadLine();
            Console.WriteLine("Enter the translation in the second language:");
            var secondLang = Console.ReadLine();
            try
            {
                AddWord(firstLang, new List<string> { secondLang.ToLower() });
            }
            catch (DictionaryException ex) { 
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
        }

        private void TranslationChange(string oldTranslation) { 
            Console.Clear();
            Console.WriteLine("Enter the new translation variant:");
            var newTranslation = Console.ReadLine() ?? "";
            try
            {
                ChangeTranslationVariant(LangDict.ElementAt(selectedItem).Key, oldTranslation.ToLower(), newTranslation.ToLower());
            }
            catch (DictionaryException ex) { 
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
        }

        private void TranslationAddition() {
            Console.Clear();
            Console.WriteLine("Enter new translation variant:");
            var secondLang = Console.ReadLine() ?? "";
            try
            {
                AddTranslationVariant(LangDict.ElementAt(selectedItem).Key, secondLang.ToLower());
            }
            catch (DictionaryException ex) { 
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
        }

        private void RunWordInfo(string word) {
            int selectedWordTranslation = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Word: {word}");
                for (int i = 0; i < LangDict[word].Count; i++) { 
                    if (i == selectedWordTranslation)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"->{LangDict[word][i].FirstLetterToUpperCaseOrConvertNullToEmptyString()}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {LangDict[word][i].FirstLetterToUpperCaseOrConvertNullToEmptyString()}");
                    }
                }

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (selectedWordTranslation > 0)
                    {
                        selectedWordTranslation--;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (selectedWordTranslation < LangDict[word].Count - 1)
                    {
                        selectedWordTranslation++;
                    }
                }
                else if (key.Key == ConsoleKey.D) {
                    try { 
                        RemoveTranslationVariant(word, LangDict[word][selectedWordTranslation]);
                    }
                    catch (DictionaryException ex) { 
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1000);
                    }
                }
                else if (key.Key == ConsoleKey.C) {
                    TranslationAddition();
                }
                else if (key.Key == ConsoleKey.Enter) {
                    TranslationChange(LangDict[word][selectedWordTranslation]);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private void Move(Direction direction) {
            switch (direction)
            {
                case Direction.Up:
                    if(selectedItem > 0)
                    {
                        selectedItem--;
                    }
                    break;
                case Direction.Down:
                    if(selectedItem < LangDict.Count - 1)
                    {
                        selectedItem++;
                    }
                    break;
            }
        }

        public void PrintWords() {
            int i = 0;
            if (LangDict.Count == 0) { 
                Console.WriteLine("The dictionary is empty.");
            }
            foreach (var word in LangDict) 
            {
                if (i == selectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"->{word.Key.FirstLetterToUpperCaseOrConvertNullToEmptyString()}: {string.Join(", ", word.Value)}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {word.Key.FirstLetterToUpperCaseOrConvertNullToEmptyString()}: {string.Join(", ", word.Value)}");
                }
                i++;
            }
        }
    }

    public class DictionaryProgram {
        private DictionaryProgram() { }
        public static DictionaryProgram Instance { get; } = new DictionaryProgram();
        public List<LanguageDictionary> dictionaries = new List<LanguageDictionary>();
        private int selectedItem = 0;

        public bool CreateNewDictionary(string name) {
            if (!dictionaries.Exists(obj => obj.Name == name)) {
                dictionaries.Add(new LanguageDictionary { Name = name });
                return true;
            }
            return false;
        }

        public void ReadDictionariesFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new DictionaryException("File not found");
                }

                string jsonString = File.ReadAllText(path);
                var options = new JsonSerializerOptions { WriteIndented = true };
                dictionaries = JsonSerializer.Deserialize<List<LanguageDictionary>>(jsonString, options) ?? new List<LanguageDictionary>();
            }
            catch (JsonException ex)
            {
                throw new DictionaryException("Error parsing dictionaries file", ex);
            }
            catch (Exception ex)
            {
                throw new DictionaryException("Error reading dictionaries file", ex);
            }
        }

        public void WriteDictionariesToFile(string path)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(dictionaries, options);
                File.WriteAllText(path, jsonString);
            }
            catch (Exception ex)
            {
                throw new DictionaryException("Error writing dictionaries to file", ex);
            }
        }

        public void Run() {
            try { 
                ReadDictionariesFromFile("dictionaries.json");
            }
            catch (DictionaryException ex) {
                Console.WriteLine(ex.Message);
            }
            while (true) { 
                Console.Clear();
                PrintDictionariesNames();

                var key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.UpArrow)
                {
                    Move(Direction.Up);
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    Move(Direction.Down);
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    Enter();
                }
                else if (key.Key == ConsoleKey.D) { 
                    DeleteSelected();
                }
                else if (key.Key == ConsoleKey.C) {
                    DictionaryCreation();
                }
            }
            try {
                WriteDictionariesToFile("dictionaries.json");
            }
            catch (DictionaryException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void Move(Direction direction) {
            switch (direction)
            {
                case Direction.Up:
                    if(selectedItem > 0)
                    {
                        selectedItem--;
                    }
                    break;
                case Direction.Down:
                    if(selectedItem < dictionaries.Count - 1)
                    {
                        selectedItem++;
                    }
                    break;
            }
        }

        private void Enter() {
            Console.Clear();
            dictionaries[selectedItem].Run();
        }

        private void PrintDictionariesNames()
        {
            for (int i = 0; i < dictionaries.Count; i++)
            {
                if (i == selectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"->{dictionaries[i].Name}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {dictionaries[i].Name}");
                }
            }
        }

        private void DeleteSelected() {
            try { 
                dictionaries.RemoveAt(selectedItem);
            }
            catch (IndexOutOfRangeException) {
                Console.WriteLine("Nothing to delete");
            }
            
        }

        private void DictionaryCreation() { 
            while (true) {
                Console.Clear();
                Console.WriteLine("Enter the name of the dictionary");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) { 
                    Console.WriteLine("Name cannot be empty");
                    Thread.Sleep(1000);
                    return; 
                }
                if (CreateNewDictionary(name)) {
                    break;
                } else { 
                    Console.WriteLine("Dictionary with this name already exists");
                    Thread.Sleep(1000);
                }
            }
        }
    }

    

    public class Program {
        
        public static void Main() {
            DictionaryProgram.Instance.Run();
        }
    }
}
