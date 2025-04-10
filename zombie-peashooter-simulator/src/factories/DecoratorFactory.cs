public static class DecoratorFactory
{
    public static ZombieDecorator CreateDecorator(DecorationType type, IZombie zombie)
    {
        if (type == DecorationType.CONE)
        {
            return new ConeDecorator(zombie, 75);
        }
        else if (type == DecorationType.BUCKET)
        {
            return new BucketDecorator(zombie, 150);
        }
        else if (type == DecorationType.SCREEN)
        {
            return new ScreenDecorator(zombie, 120);
        }
        else
        {
            throw new ArgumentException();
        }
    }
}