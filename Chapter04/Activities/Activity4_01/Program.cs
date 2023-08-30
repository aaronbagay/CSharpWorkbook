

namespace Chapter04.Activities.Activity4_01
{
    class Program
    {
        public static void Main()
        {
            const string flightDataUrl = "https://www.gov.uk/government/uploads/system/uploads/attachment_data/file/245855/HMT_-_2011_Air_Data.csv";
            const string flightDataFilePath = "hm-treasury-flight-data-2011.csv";

            var flightQuery = new FlightQuery(new FlightLoader());

            if (File.Exists(flightDataFilePath))
            {
                Console.WriteLine($"Importing {flightDataFilePath}");
                flightQuery.Import(flightDataFilePath);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Downloading {flightDataUrl}");
                flightQuery.Download(flightDataUrl, flightDataFilePath);
                Console.WriteLine();
                Console.WriteLine($"Downloaded to {flightDataFilePath}...");
            }

            Console.WriteLine($"Found {flightQuery.Count} flight records");

            const string goCommand = "go";
            const string clearCommand = "clear";
            const string classCommand = "class";
            const string originCommand = "origin";
            const string destinationCommand = "destination";

            Console.WriteLine($"Commands: {goCommand} | {clearCommand} | {classCommand} value | {originCommand} value | {destinationCommand} value");
            string input;
            do
            {
                Console.Write("Enter a command:");
                input = Console.ReadLine().ToLower();

                string command;
                string argument;
                var spaceIndex = input.IndexOf(' ');
                if (spaceIndex == -1)
                {
                    command = input;
                    argument = null;
                }
                else
                {
                    command = input[..spaceIndex].Trim();
                    argument = input[spaceIndex..].Trim();
                }

                switch (command)
                {
                    case goCommand:
                        var flights = flightQuery.RunQuery();
                        if (flights.Any())
                        {
                            var average = flights.Average(fl => fl.PaidFare);
                            var min = flights.Min(fl => fl.PaidFare);
                            var max = flights.Max(fl => fl.PaidFare);
                            Console.WriteLine($"Results: Count={flights.Count}, Avg={average:N2}, Min={min:N2}, Max={max:N2}");
                        }
                        else
                        {
                            Console.WriteLine("No matching flights found");
                        }
                        break;

                    case clearCommand:
                        flightQuery.ClearFilters();
                        break;

                    case classCommand:
                        flightQuery.AddFilter(FilterCriteriaType.Class, argument);
                        break;

                    case originCommand:
                        flightQuery.AddFilter(FilterCriteriaType.Origin, argument);
                        break;

                    case destinationCommand:
                        flightQuery.AddFilter(FilterCriteriaType.Destination, argument);
                        break;
                }
            } while (input != string.Empty);
        }
    }
}