using System;

class BakedGoods
{
    protected string name;
    protected int quantity;

    public BakedGoods(string name)
    {
        this.name = name;
        quantity = 0;
    }

    public void Bake(int amount)
    {
        quantity += amount;
        Console.WriteLine(amount + " " + name + "(s) baked.");
    }

    public void Sell(int amount)
    {
        if (amount > quantity)
        {
            Console.WriteLine("Not enough " + name + "s to sell.");
        }
        
        else
        {
            quantity -= amount;
            Console.WriteLine(amount + " " + name + "(s) sold.");
        }
    }

    public void Display()
    {
        Console.WriteLine(name + ": " + quantity + " in stock");
    }

    static void Main()
    {
        BakedGoods bread = new BakedGoods("Bread");
        BakedGoods cupcake = new BakedGoods("Cupcake");


        bread.Bake(10);
        cupcake.Bake(5);
        bread.Sell(3);        
        cupcake.Sell(2);
        cupcake.Sell(5);

        bread.Display();
        cupcake.Display();

        int wasted_items = bread.quantity+cupcake.quantity;

        Console.WriteLine($"Wasted items: {wasted_items}");


        
    }
}
