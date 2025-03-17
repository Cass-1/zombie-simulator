public class ZombieFactory : EntityFactory
{
    public override Entity CreateEntity(string entity)
    {
        if (entity == "regular")
        {
            return new RegularZombie();
        }
        else
        {
            EntityFactory factory = new AccessoryFactory();
            return new RegularZombie(factory.CreateEntity(entity));
        }
    }
}