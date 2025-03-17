public class ZombieFactory : EntityFactory
{
    public override Entity CreateEntity(string entity)
    {
        if (entity == "cone")
        {
            return new ConeZombie();
        }
        else if (entity == "bucket")
        {
            return new BucketZombie();
        }
        else if (entity == "screen")
        {
            return new ScreenZombie();
        }
        else if (entity == "regular")
        {
            return new RegularZombie();
        }
        else
        {
            throw new ArgumentException("invalid argument");
        }
    }
}