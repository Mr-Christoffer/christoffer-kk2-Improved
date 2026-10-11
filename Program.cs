string file = "items.txt";
if (!File.Exists(file))
{
    File.WriteAllText(file, "");
    System.Console.WriteLine($"{file} fanns inte. En ny fil har skapats.");
}
ShoppingList list = new ShoppingList("items.txt", 2000);
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
                string priceInput = Console.ReadLine();

                if (!int.TryParse(priceInput, out int price))
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen.");
                    continue;
                }

                try
                {
                    bool wasItemAdded = list.Add(new Item(name, price));
                    if (wasItemAdded == false)
                    {
                        System.Console.WriteLine("Budgeten räckte inte. Varan har inte lagts till.");
                    }
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Priset får inte vara negativt. Försök igen.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message} Du återgår nu till menyn.");
                    break;
                }
            }
        }
        else if (choice == 2)
        {
            Console.Write("Nummer: ");
            try
            {
                string numberInput = Console.ReadLine();
                if (int.TryParse(numberInput, out int number))
                {
                    list.RemoveAt(number);
                }
                else
                {
                    System.Console.WriteLine("Ogiltig inmatning. Du återgår nu till menyn.");
                }
            }
            catch (FormatException)
            {
                System.Console.WriteLine("Endast heltal är tillåtet. Du återgår nu till menyn.");
            }
            catch (ArgumentOutOfRangeException)
            {
                System.Console.WriteLine("Varan finns inte och kan därför inte tas bort. Du går nu tillbaka till menyn");
            }
            catch (OverflowException)
            {
                System.Console.WriteLine("Du har angett ett för stort tal.");
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
