
namespace dz10 {

    class Shop: IDisposable { 

        public enum ShopType
        {
            Food,
            Economic,
            Clothing,
            Shoes
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }

        public int NumOfTrashBins { get; set; }

        public Shop(string name, string address, ShopType type)
        {
            Name = name;
            Address = address;
            Type = type;
            NumOfTrashBins = 20;
        }

        public void Dispose()
        {
            NumOfTrashBins = 0;
            Console.WriteLine("Shop resources have been disposed.");
        }
    }

    class MemoryAllocator: IDisposable { 
        public int[] Arr { get; set; }

        public MemoryAllocator(int size)
        {
            Arr = new int[size];
        }

        public MemoryAllocator()
        {
            Arr = new int[1000000];
        }

        public void UseMemory()
        {
            for (int i = 0; i < 20; i++) { 
                Arr = null;
                Arr = new int[1000000]; 
                for (int j = 0; j < Arr.Length; j++)
                {
                    Arr[j] = j;
                }
            }
            Arr = new int[1000000];
        }

        public int GetGeneration()
        {
            return GC.GetGeneration(Arr);
        }

        public void CollectGarbage(int generation = -1)
        {
            if (generation < 0)
            {
                GC.Collect();
            }
            else
            {
                GC.Collect(generation);
            }
        }

        public void Dispose()
        {
            Arr = null;
            Console.WriteLine("Memory resources have been disposed.");
        }
    }

    class Program
    {
        static void Main()
        {
            // 1
            // using (Shop shop = new Shop("Supermarket", "123 Main St", Shop.ShopType.Food))
            // {
            //     Console.WriteLine($"Shop Name: {shop.Name}");
            //     Console.WriteLine($"Address: {shop.Address}");
            //     Console.WriteLine($"Type: {shop.Type}");
            //     Console.WriteLine($"Number of Trash Bins: {shop.NumOfTrashBins}");

            //     shop.NumOfTrashBins = 30;
            //     Console.WriteLine($"Updated Number of Trash Bins: {shop.NumOfTrashBins}");
            // }

            //2
            using (MemoryAllocator allocator = new MemoryAllocator(10))
            {
                allocator.CollectGarbage();
                Console.WriteLine($"Memory Generation: {allocator.GetGeneration()}");

                allocator.UseMemory();
                allocator.CollectGarbage();
                Console.WriteLine($"Memory Generation: {allocator.GetGeneration()}");
            }
        }
    }
}
