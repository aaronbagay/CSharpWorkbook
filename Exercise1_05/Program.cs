// See https://aka.ms/new-console-template for more information
Console.WriteLine("Are the local and utc dates equal? {0}",DateTime.Now.Date == DateTime.UtcNow.Date);

Console.WriteLine("\n if the dates are equal, does it mean that there's no TimeSpan interval between them? {0}",
(DateTime.Now.Date - DateTime.UtcNow.Date) == TimeSpan.Zero);

DateTime localTime = DateTime.Now;
DateTime utcTime = DateTime.UtcNow;
TimeSpan interval = (localTime - utcTime);

Console.WriteLine("\n Difference between the {0} Time and {1} Time: {2}:{3} hours",
localTime.Kind.ToString(),
utcTime.Kind.ToString(),
interval.Hours,
interval.Minutes);

Console.WriteLine("\n If we jump two days to the future on {0} we'll be on {1}",
new DateTime(2023, 12, 31).ToShortDateString(),
new DateTime(2023, 12, 31).AddDays(2).ToShortDateString() );

var frenchDate = new DateTime(2023, 4, 19, 7,  0, 0);
Console.WriteLine(frenchDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture ("fr-FR")));

var usDate =  new DateTime(2023, 4, 19, 6, 0, 0);
Console.WriteLine(usDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
