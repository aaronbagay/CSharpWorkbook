// See https://aka.ms/new-console-template for more information
/* The System.Text.StringBuilder class helps build strings in many ways. Here we are 
building strings line by line so that they can be properly displayed on the console. */
var menuBuilder = new System.Text.StringBuilder();

menuBuilder.AppendLine("Welcom to the Burger Joint");
menuBuilder.AppendLine(string.Empty);
menuBuilder.AppendLine("1) Burgers and Fries - 5 USD");
menuBuilder.AppendLine("2) Cheeseburger - 7 USD");
menuBuilder.AppendLine("3) Double-cheesburger - 9 USD");
menuBuilder.AppendLine("4) Soda - 2 USD");
menuBuilder.AppendLine(string.Empty);
menuBuilder.AppendLine("Note that every burger option comes with fries and ketchup!");

Console.WriteLine(menuBuilder.ToString() );
Console.WriteLine("Please type one of the following options to order: ");

var option = Console.ReadKey();

switch (option.KeyChar.ToString())
{
    case "1":
    {
        Console.WriteLine("\nAlright some burgers on the go. Please pay at the cashier.");
        break;
    }
    case "2":
    {
        Console.WriteLine("\nThank you for ordering cheese burgers. Please pay at the cashier.");
        break;    
    }
    case "3":
    {
        Console.WriteLine("\nThank you for orderind double cheeseburgers, hope you enjoy them. Please pay at the cashier.");
        break;    
    }
    case "4":
    {
        Console.WriteLine("\nThank you for ordering some soda, please pay at the cashier.");
        break;
    }
    default:
    {
        Console.WriteLine("\nSorry you chose an invalid option.");
        break;
    }
}