﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Please type a username. It must have at least 6 characters: ");
var username = Console.ReadLine();

if (username.Length < 6)
{
    Console.WriteLine($"The username {username} is not valid.");
}
else
{
    Console.WriteLine("Now type a password. It must have a length of at least 6 characters and also contain a number.");
    var password = Console.ReadLine();
    if (password.Length < 6)
    {
        Console.WriteLine("The password must have at least 6 characters.");
    }
    else if (!password.Any( c => Char.IsDigit(c)))
    {
        Console.WriteLine("The password must contain at least one number.");
    }
    else
    {
        Console.WriteLine("User successfully registered.");
    }
}