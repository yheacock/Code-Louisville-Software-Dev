using System;

class Program
{
    static int ship_hp = 100;
    static int money = 50;
    static Random rnd = new Random();

    static (string Name, int HpChange, int MoneyChange)[] fishTypes = new (string, int, int)[]
    {
        ("Small Fish", 0, 3),
        ("Big Fish", 0, 9),
        ("Shark", -30, 27),
        ("Piranha", -20, 10),
        ("Electric Eel", -15, 7),
        ("Crab", 0, 10),
        ("Octopus", -20, 10),
        ("Seaweed", 0, 1),
        ("Treasure Chest", 0, 50),
        ("Jellyfish", -5, 5),
        ("Swordfish", -15, 14),
        ("Dolphin", 0, 25),
        ("Poisonous Fish", -20, 5)
    };

    static void Main()
    {
        Console.WriteLine("Welcome to fishing game. Collect as many coins as you can.\n");
        GameLoop();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); 
    }

    static void GameLoop()
    {
        while (ship_hp > 0)
        {
            DisplayStats();
            Console.WriteLine($"Enter 1 to fish\nEnter 2 to repair ship. ${(100-ship_hp)*2}");
            int input = int.Parse(Console.ReadLine());

            if( input == 1)
                Fish();
            else   
                RepairShip(ship_hp,money);
                
        }

        Console.WriteLine("Your HP dropped to 0. Game Over!");
        Console.WriteLine($"You made ${money} in total.");
    }

    static void DisplayStats()
    {
        Console.WriteLine($"Current HP: {ship_hp}, Money: ${money}\n");
    }

    static void RepairShip(int current_ship_hp, int current_money)
    {
        int current_missingHp = 100 - current_ship_hp;
        int totalCost = current_missingHp * 2;

        if (totalCost > money)
        {
            Console.WriteLine("You don't have enough money to repair your ship.");
            Console.WriteLine("-----------------------------------------------------------------");
        } 
        else
        {
            Console.WriteLine("Your ship is repaired.");
            Console.WriteLine("-----------------------------------------------------------------");

            ship_hp = 100;

            money -= totalCost;
        }
        
    }

    static void Fish()
    {
        int index = rnd.Next(fishTypes.Length);
        var catchFish = fishTypes[index];

        ship_hp += catchFish.HpChange;
        money += catchFish.MoneyChange;

        if (catchFish.HpChange > 0)
            Console.WriteLine($"Great! You caught a {catchFish.Name}! You earned ${catchFish.MoneyChange}.");
        else if (catchFish.HpChange < 0)
            Console.WriteLine($"Oh no! You caught a {catchFish.Name}! You lost {-catchFish.HpChange} HP and earned ${catchFish.MoneyChange}.");
        else
            Console.WriteLine($"You caught a {catchFish.Name}! You earned ${catchFish.MoneyChange}.");

        Console.WriteLine("\n-----------------------------------------------------------------");

        if (ship_hp > 100) ship_hp = 100;
        Console.WriteLine();
    }
}
