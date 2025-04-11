// See https://aka.ms/new-console-template for more information


using System.Xml;

GameObjectManager objectManager = new();
GameEventManager eventManager = new(objectManager);

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
        List<ZombieType> zombies = CreateZombies();
        zombies.ForEach(x => objectManager.AddZombie(x));
    }
    else if (input.Contains('2'))
    {
        while (objectManager.HasZombies)
        {
            Console.WriteLine(objectManager.GetZombieGraphics());
            CollisionType collisionType = ChooseAttack();
            eventManager.simulateCollisionDetection(collisionType);
            Console.WriteLine(objectManager.GetZombieGraphics());
        }
    }
    else if (input.Contains('3'))
    {
        break;
    }
}

static CollisionType ChooseAttack()
{
    while (true)
    {
        Console.WriteLine("1. Peashooter\n2. Watermelon\n3. Magnet");
        string? input = Console.ReadLine();

        if (input == null)
        {
            // do nothing
        }
        else if (input.Contains('1'))
        {
            return CollisionType.PEASHOOTER;
        }
        else if (input.Contains('2'))
        {
            return CollisionType.WATERMELON;
        }
        else if (input.Contains('3'))
        {
            return CollisionType.MAGNET_SHROOM;
        }
    }
}

static List<ZombieType> CreateZombies()
{
    List<ZombieType> zombies = new();
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
            zombies.Add(ZombieType.REGULAR);
        }
        else if (input.Contains('2'))
        {
            zombies.Add(ZombieType.CONE);
        }
        else if (input.Contains('3'))
        {
            zombies.Add(ZombieType.BUCKET);
        }
        else if (input.Contains('4'))
        {
            zombies.Add(ZombieType.SCREEN);
        }
        else if (input.Contains('5'))
        {
            return zombies;
        }
    }
}