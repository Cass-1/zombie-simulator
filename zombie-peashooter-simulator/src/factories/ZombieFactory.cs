public static class ZombieFactory
{
    public static IZombie CreateDecorator(ZombieType type)
    {
        RegularZombie zombie = new();
        if (type == ZombieType.CONE)
        {
            return new ConeDecorator(zombie);
        }
        else if (type == ZombieType.BUCKET)
        {
            return new BucketDecorator(zombie);
        }
        else if (type == ZombieType.SCREEN)
        {
            return new ScreenDecorator(zombie);
        }
        else if (type == ZombieType.REGULAR)
        {
            return zombie;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}