namespace Chapter05.Exercises.Exercise05
{
    public enum RegionName
    {
        North,
        East,
        South,
        West
    };

    public class Customer
    {
        private readonly RegionName _protectedRegion;

        public Customer(string name, RegionName region, RegionName protectedRegion)
        {
            Name = name;
            
        }

        public class CustomerOperations
        {
            public const RegionName ProtectedRegion = RegionName.West;

            public async Task<IEnumerable<Customer>> FetchTopCustomers()
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                
                Logger.Log
            }
        }
        
    }
}