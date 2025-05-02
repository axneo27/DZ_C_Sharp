
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace dz3
{

    public partial class Freezer
    {
        private int _temperature;
        private int _currentLoad;
        private readonly int _maxLoad;
        private readonly int _maxTemperature;
        private readonly int _minTemperature;

        static readonly int defaultTemperature;
        static readonly int defaultMaxLoad ;

        static Freezer ()
        {
            Freezer.defaultMaxLoad = 1000;
            Freezer.defaultTemperature = -18;
        }

        public Freezer(int maxLoad, int minTemperature, int maxTemperature)
        {
            _maxLoad = maxLoad;
            _minTemperature = minTemperature;
            _maxTemperature = maxTemperature;
            _currentLoad = 0;
            _temperature = 0;
        }
        
        public Freezer(int minT, int maxT) : this(Freezer.defaultMaxLoad, minT, maxT)
        {
            _temperature = Freezer.defaultTemperature;
        }
        public int Temperature {
            get { return _temperature; }
            set
            {
                if (value < _minTemperature || value > _maxTemperature)
                {
                    Console.WriteLine("Temperature out of range.");
                    return;
                }
                _temperature = value;
            }
        }
        
    }

    internal class Program
    {
        static void Main()
        {
            Freezer[] freezers = new Freezer[5];
            freezers[0] = new Freezer(1000, -20, 0);
            freezers[1] = new Freezer(-20, 0);
            freezers[2] = new Freezer(1000, -20, 0);
            freezers[3] = new Freezer(-20, 0);
            freezers[4] = new Freezer(1000, -20, 0);
            
            foreach (var freezer in freezers)
            {
                Console.WriteLine(freezer.ToString());
            }
        }
    }
}
