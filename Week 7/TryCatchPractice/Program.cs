using System;

Console.WriteLine("Please enter your monthly income.");

string user_input = Console.ReadLine();
int income;
Console.WriteLine("\n");
try
{
    income = int.Parse(user_input);
    int yearly = income * 12;

    double taxRate;

    if (yearly < 11600)
    {
        taxRate = 0.10;
    }
    else if (yearly < 48475)
    {
        taxRate = 0.12;
    }
    else if (yearly < 103350)
    {
        taxRate = 0.22;
    }
    else if (yearly < 197300)
    {
        taxRate = 0.24;
    }
    else if (yearly < 250525)
    {
        taxRate = 0.32;
    }
    else if (yearly < 626350)
    {
        taxRate = 0.35;
    }
    else
    {
        taxRate = 0.25;
    }

    double taxOwed = yearly * taxRate;

    Console.WriteLine($"Yearly Income: ${yearly}");
    Console.WriteLine($"Tax Rate: {taxRate * 100}%");
    Console.WriteLine($"Tax Owed: ${taxOwed}");
}
catch (FormatException)
{
    Console.WriteLine("Invalid input. Please enter a number.");
}
