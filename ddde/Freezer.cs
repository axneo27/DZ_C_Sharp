namespace dz3 
{
    public partial class Freezer
    {
        public override string ToString()
        {
            return $"Freezer: Current Load = {_currentLoad}, Temperature = {_temperature}, Max Load = {_maxLoad}, Min Temperature = {_minTemperature}, Max Temperature = {_maxTemperature}";
        }

        public void AddProduct(int weight)
        {
            if (weight < 0)
            {
                Console.WriteLine("Cannot add product: weight cannot be negative.");
                return;
            }
            if (_currentLoad + weight > _maxLoad)
            {
                Console.WriteLine("Cannot add product: exceeds max load.");
                return;
            }
            _currentLoad += weight;
        }

        public int GetCurrentLoad()
        {
            return _currentLoad;
        }

        public void ChangeTemperature(ref Freezer freezer, int temperature)
        {
            if (temperature < _minTemperature || temperature > _maxTemperature)
            {
                Console.WriteLine("Cannot change temperature: out of range.");
                return;
            }
            freezer._temperature = temperature;
        }

        public void ChangeTemperature(int temperature)
        {
            if (temperature < _minTemperature || temperature > _maxTemperature)
            {
                Console.WriteLine("Cannot change temperature: out of range.");
                return;
            }
            _temperature = temperature;
        }

        public void RemoveProduct(int weight)
        {
            if (weight < 0)
            {
                Console.WriteLine("Cannot remove product: weight cannot be negative.");
                return;
            }
            if (_currentLoad - weight < 0)
            {
                Console.WriteLine("Cannot remove product: exceeds current load.");
                return;
            }
            _currentLoad -= weight;
        }
    }
}


