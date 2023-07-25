﻿namespace Examples;

public class LinqSkipTakeExamples
{
    public static void Main()
    {
        var grades = new[] { 25, 95, 75, 40, 54, 9, 99 };
        Console.WriteLine("Skip: Highest Grades (skipping first: ");
        foreach (var grade in grades.OrderByDescending(g => g).Skip(1))
        {
            Console.Write($"{grade} ");
        }
        Console.WriteLine();
        
        Console.WriteLine("SkipWhile @ Middle Grades (excluding 25 or 75): ");
        foreach (var grade in grades.OrderByDescending(g => g).SkipWhile(g => g is <= 25 or >= 75))
        {
            Console.Write($"{grade} ");
        }
        Console.WriteLine();
        
        Console.Write("SkipLast: Bottom Half Grades: ");
        foreach (var grade in grades.OrderBy(g => g).SkipLast(grades.Length/2))
        {
            Console.Write($"{grade} ");
        }
        Console.WriteLine();
        
        Console.Write("Take: Two Highest Grade: ");
        foreach (var grade in grades.OrderByDescending(g => g).Take(2))
        {
            Console.Write($"{grade} ");
        }
    }
}