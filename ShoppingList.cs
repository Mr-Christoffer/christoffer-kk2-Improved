// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    public int Budget;

    public ShoppingList(string path, int budget)
    {
        this.path = path;
        Budget = budget;
        
    }

    public void Add(Item item)
    {
        int currentAmount = Total();
        if (item.Price + currentAmount <= Budget)
        {
            items.Add(item);
        }
        else
        {
            System.Console.WriteLine("Din budget räcker inte till. Varan har inte lagts till.");
        }

        
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
            Console.WriteLine("Listan är sparad.");
        }
        catch (UnauthorizedAccessException)
        {
            System.Console.WriteLine("Du har inte behörighet att redigera denna fil. Inget har sparats");
        }
        catch (IOException)
        {
            System.Console.WriteLine("Filen kunde inte sparas");
        }


    }

    // Reads the file back into the list.
    public void Load()
    {
        try
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                try
                {
                    items.Add(new Item(parts[1], int.Parse(parts[0])));
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("En rad innehöll felaktigt formaterad information. Raden har hoppats över.");
                }
                catch (OverflowException)
                {
                    System.Console.WriteLine("Raden innehåller priser som är för stora. Raden har hoppats över.");
                }
                catch (IndexOutOfRangeException)
                {
                    System.Console.WriteLine("Felaktig rad hoppades över.");
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            System.Console.WriteLine("Du har inte behörighet till denna fil. Inget har laddats.");
        }
        catch (IOException)
        {
            System.Console.WriteLine("Filen kunde inte läsas.");
        }




    }
}


