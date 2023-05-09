// See https://aka.ms/new-console-template for more information

var numberToBeGuessed = new Random().Next(0,10);

int remainingChances = 5;

int guessedNumber;

bool numberFound = false;

while (remainingChances != 0 || numberFound == false)
{
    Console.WriteLine(@$"You have {remainingChances} to guess the number I am thinking.
    Please enter a number from 1 to 10: ");
    guessedNumber = int.Parse(Console.ReadLine());
    if (guessedNumber == numberToBeGuessed)
    {
        numberFound = true;
        Console.WriteLine($"Congrats! You guessed the number with {remainingChances} attempts remaining");
        break;
    }
    else if (remainingChances == 0)
    {
        Console.WriteLine($"Game over! The number was {numberToBeGuessed}");
        break;
    }
    else if (guessedNumber < numberToBeGuessed)
    {
        --remainingChances;
        Console.WriteLine($"No, the number I was thinking was higher than {guessedNumber}. You also have {remainingChances} left. Enter anothe guess:");
    }
    else if (guessedNumber > numberToBeGuessed)
    {
        --remainingChances;
        Console.WriteLine($"No, the number I was thinking was lower than {guessedNumber}. You also have {remainingChances} left. Enter another guess: ");
    }
}