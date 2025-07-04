
namespace dz11 { 

    public enum Direction
    {
        Up,
        Down
    }

    public class FileManager
    {
        private readonly string root = "someDirectory";
        private string currentDir;
        public int selectedItem = 0;
        private List<object> children;
        private Stack<string> history;

        public FileManager()
        {
            history = new Stack<string>();
            currentDir = root;
            children = new List<object>();
            SetChildren();
        }

        private void SetChildren()
        {
            children.Clear();
            foreach (var dir in Directory.GetDirectories(currentDir))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                children.Add(dirInfo);
            }
            foreach (var file in Directory.GetFiles(currentDir))
            {
                FileInfo fileInfo = new FileInfo(file);
                children.Add(fileInfo);
            }
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if(selectedItem > 0)
                    {
                        selectedItem--;
                    }
                    break;
                case Direction.Down:
                    if(selectedItem < children.Count - 1)
                    {
                        selectedItem++;
                    }
                    break;
            }
            
        }

        public void Back()
        {
            if(history.Count > 0)
            {
                currentDir = history.Pop();
                SetChildren();
                selectedItem = 0;
            }
        }

        public void Enter()
        {
            object child = children[selectedItem];

            if (child is DirectoryInfo)
            {
                DirectoryInfo dir = (DirectoryInfo)child;
                history.Push(currentDir);
                currentDir = dir.FullName;
                SetChildren();
                selectedItem = 0;
            } else if (child is FileInfo)
            {
                FileInfo file = (FileInfo)child;
                PrintFileContent(file);
                Console.ReadKey(true);
            }
        }

        public void PrintChildren()
        {
            for (int i = 0; i < children.Count; i++)
            {
                string childName = "";

                DirectoryInfo? dir = children[i] as DirectoryInfo;

                if(dir != null)
                {
                    childName = dir.Name;
                }
                else
                {
                    FileInfo? file = children[i] as FileInfo;
                    childName = file.Name;
                }


                if (i == selectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"->{childName}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {childName}");
                }
            }
        }

        public void PrintFileContent(FileInfo file)
        {
            Console.Clear();
            Console.WriteLine($"{file.Name}:");
            Console.WriteLine(File.ReadAllText(file.FullName));
        }

        public void DeleteSelected()
        {
            object child = children[selectedItem];

            if (child is DirectoryInfo)
            {
                DirectoryInfo dir = (DirectoryInfo)child;
                Directory.Delete(dir.FullName, true);
            }
            else if (child is FileInfo)
            {
                FileInfo file = (FileInfo)child;
                File.Delete(file.FullName);
            }

            SetChildren();
            selectedItem = 0;
        }

        public void RenameSelected(string newName)
        {
            object child = children[selectedItem];

            if (child is DirectoryInfo)
            {
                DirectoryInfo dir = (DirectoryInfo)child;
                string newPath = Path.Combine(dir.Parent.FullName, newName);
                Directory.Move(dir.FullName, newPath);
            }
            else if (child is FileInfo)
            {
                FileInfo file = (FileInfo)child;
                string newPath = Path.Combine(file.Directory.FullName, newName);
                File.Move(file.FullName, newPath);
            }

            SetChildren();
            selectedItem = 0;
        }
    }

    class Program
    {
        static void Main()
        {
            FileManager fm = new FileManager();

            while(true)
            {
                Console.Clear();
                fm.PrintChildren();

                var key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.UpArrow)
                {
                    fm.Move(Direction.Up);
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    fm.Move(Direction.Down);
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    fm.Enter();
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    fm.Back();
                }
                else if (key.Key == ConsoleKey.D) { 
                    fm.DeleteSelected();
                }
                else if (key.Key == ConsoleKey.R)
                {
                    Console.SetCursorPosition(2, fm.selectedItem);
                    while (true)
                    {
                        var key2 = Console.ReadKey(true);
                        if (key2.Key == ConsoleKey.Backspace)
                        {
                            break;
                        }
                        string? newName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newName))
                        {
                            fm.RenameSelected(newName);
                            break;
                        }
                    }
                }
            }
        }
    }
}
