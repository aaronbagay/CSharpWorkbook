// See https://aka.ms/new-console-template for more information

using System;

Console.WriteLine("Type a value for a: ");
var a = int.Parse(Console.ReadLine() );
Console.WriteLine("Now type a value for b: ");
var b = int.Parse(Console.ReadLine() );

Console.WriteLine($"The vall for a is { a } and b is { b }");
Console.WriteLine($"Sum : { a + b }");
Console.WriteLine($"Multiplication : {a * b}");
Console.WriteLine($"Subtraction : {a - b}");
Console.WriteLine($"Division : {a / b}");