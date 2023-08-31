namespace Examples
{
    record City (String Name, IEnumerable<string> Stations);

    class LinqSelectManyExamples
    {
        public static void Main()
        {
            var cities = new List<City>
            {
                new City ( "London", new[] {"Kings Cross KGX", "Liverpool Street LVS", "Euston EUS"}),
                new City ( "Birmingham", new[] {"New Street NST"})
            };

            Console.WriteLine("All Stations: ");
            foreach (var station in cities.SelectMany(city => city.Stations))
            {
                Console.WriteLine(station);
            }
        }
    }
}