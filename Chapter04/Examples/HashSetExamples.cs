namespace Chapter04.Examples
{
    class HashSetExamples
    {
        public static void Main()
        {
            var actors = new List<string> { "Harrison Ford", "Will Smith", "Sigourney Weaver" };
            var singers = new List<string> { "Will Smith", "Adele" };

            var actingOrSinging = new HashSet<string>(singers);
            actingOrSinging.UnionWith(actors);
            Console.WriteLine($"Acting or Singing: {string.Join(", ", actingOrSinging)}");

            var actingOnly = new HashSet<string>(actors);
            actingOnly.ExceptWith(singers);
            Console.WriteLine($"Acting only: {string.Join(", ", actingOnly)}");
            Console.ReadLine();
        }
    }
}