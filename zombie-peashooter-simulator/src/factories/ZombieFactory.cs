public static class ZombieFactory
{
    public static IZombie CreateDecorator(ZombieType type)
    {
        RegularZombie zombie = new();
        if (type == ZombieType.CONE)
        {
            return new ConeDecorator(zombie, 75);
        }
        else if (type == ZombieType.BUCKET)
        {
            return new BucketDecorator(zombie, 150);
        }
        else if (type == ZombieType.SCREEN)
        {
            return new ScreenDecorator(zombie, 120);
        }
        else if (type == ZombieType.NONE)
        {
            return zombie;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}