Console.WriteLine("Shop for Books");
Console.WriteLine("Write the item code of the book(s) you want to order and click enter. (Enter 'Q' to finish order)");

string[,] books = {
    { "3498", "The Book Thief" },
    { "2643", "Brave New World" },
    { "8906", "Housemaid" },
    { "3468", "Sapiens" },
    { "2638", "The Summer I Turned Pretty" } };

Console.WriteLine("Available books:");
for (int i = 0; i < books.GetLength(0); i++)
{
    Console.WriteLine($"{books[i, 0]} - {books[i, 1]}");
}

string input;
bool book_found = false;
do
{
    Console.Write("\nEnter item code: ");
    input = Console.ReadLine()!;

    if (input.ToUpper() == "Q")
        break;
    for (int i = 0; i < books.GetLength(0); i++)
    {
        if (input == books[i, 0])
        {
            Console.WriteLine($"You ordered {books[i, 1]}.");
            book_found = true;
            break;
        }
        else
        {
            book_found = false;
        }

    }
    if (book_found == false)
    {
        Console.WriteLine("Book not found.");
    }

    
}
while (true);