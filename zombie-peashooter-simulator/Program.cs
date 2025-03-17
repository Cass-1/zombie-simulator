// See https://aka.ms/new-console-template for more information
using System.Formats.Asn1;

Console.WriteLine("Hello, World!");

List<Entity> zombies = new();

while (true)
{
    Console.WriteLine("1. Create Zombies\n2. Demo Game Play\n3. Quit");
    string? input = Console.ReadLine();

    if (input == null)
    {
        // do nothing
    }
    else if (input.Contains('1'))
    {
        zombies.AddRange(CreateZombies());
    }
    else if (input.Contains('2'))
    {
        Console.WriteLine("Enter damage the peashooter should do: ");
        string? damage = Console.ReadLine();
        int peaDamage = 25;
        try
        {
            peaDamage = Int32.Parse(damage ?? "25");
            Console.WriteLine($"You have set the pea damage to {peaDamage}");
        }
        catch
        {
            Console.WriteLine("You entered an invalid number, defaulting to 25");
        }
        while (zombies.Count > 0)
        {
            Console.WriteLine(GetGraphicOfZombieList(zombies));
            Entity zombie = zombies.First();
            zombie.TakeDamage(peaDamage);
            if (zombie.IsDead())
            {
                zombies.Remove(zombie);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
    else if (input.Contains('3'))
    {
        break;
    }
}

static List<Entity> CreateZombies()
{
    List<Entity> zombies = new();
    EntityFactory factory = new ZombieFactory();
    while (true)
    {
        Console.WriteLine("1. Create Regular Zombie\n2. Create Cone Zombie\n3. Create Bucket Zombie\n4. Create Screen Door Zombie\n5. Stop");
        string? input = Console.ReadLine();
        if (input == null)
        {
            // do nothing
        }
        else if (input.Contains('1'))
        {
            zombies.Add(factory.CreateEntity("regular"));
        }
        else if (input.Contains('2'))
        {
            zombies.Add(factory.CreateEntity("cone"));
        }
        else if (input.Contains('3'))
        {
            zombies.Add(factory.CreateEntity("bucket"));
        }
        else if (input.Contains('4'))
        {
            zombies.Add(factory.CreateEntity("screen"));
        }
        else if (input.Contains('5'))
        {
            return zombies;
        }
    }
}

static string GetGraphicOfZombieList(List<Entity> zombies)
{
    string? zombieListGraphic = "[";
    foreach (var z in zombies)
    {
        zombieListGraphic += z.GetEntityType() + "/" + z.GetHealth().ToString() + ",";
    }
    zombieListGraphic += "]";
    return zombieListGraphic;
}