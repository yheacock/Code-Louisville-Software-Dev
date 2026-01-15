//json source: https://labyrinthos.co/blogs/tarot-card-meanings-list


using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class TarotCard
{
    public string name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
}

public class TarotDeck
{
    public List<TarotCard> Cards { get; set; } = new List<TarotCard>();
}

class Program
{
    static void Main()
    {
        try
        {
            //json File is searched in bin\debug\net9.0
            string jsonString = File.ReadAllText("tarot.json");

            Console.WriteLine("Computer is picking a Tarot Card for you");

            //Loading Dot Effect
            for(int i = 0;i < 5;i++)
            {
                Console.Write(".");
                Thread.Sleep(750);
            }
            Console.WriteLine(".");

            TarotDeck deck = JsonSerializer.Deserialize<TarotDeck>(jsonString)!;

            Random rand = new Random();
            var card = deck.Cards[rand.Next(deck.Cards.Count)];
            Console.WriteLine($"Name: {card.name}");
            Console.WriteLine($"Description: {card.description}");
        Console.WriteLine(new string('-', 40));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file 'tarot.json' was not found.");
        }
        catch (JsonException)
        {
            Console.WriteLine("Error parsing JSON file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        Console.WriteLine("Press Enter to exit");
        Console.ReadLine();
    }
}
