string file = "items.txt";
if (!File.Exists(file))
{
    File.WriteAllText(file, "");
    System.Console.WriteLine($"{file} fanns inte. En ny fil har skapats.");
}

ShoppingList list = new ShoppingList("items.txt");
list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    string input = Console.ReadLine();
    if (int.TryParse(input, out int choice))
    {
        if (choice == 1)
        {
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            while (true)
            {
                Console.Write("Pris: ");

                try
                {
                    int price = int.Parse(Console.ReadLine());
                    list.Add(new Item(name, price));
                    break;
                }
                catch
                {
                    System.Console.WriteLine("Ange endast heltal som pris. V.G. Försök igen!");
                }
            }


        }
        else if (choice == 2)
        {
            Console.Write("Nummer: ");
            try
            {
                int number = int.Parse(Console.ReadLine());
                list.RemoveAt(number);
            }
            catch
            {
                System.Console.WriteLine("Varan finns inte och kan därför inte tas bort. Du går nu tillbaka till menyn");
            }
        }
        else if (choice == 3)
        {
            list.Save();
        }
        else if (choice == 4)
        {
            Console.Write("Namn att söka efter: ");
            string wanted = Console.ReadLine();
            Item found = list.Find(wanted);

            if (found == null)
            {
                Console.WriteLine("Varan finns inte i listan.");
            }
            else
            {
                Console.WriteLine($"Hittade: {found}");
            }
        }
        else if (choice == 5)
        {
            break;
        }
    }
}
