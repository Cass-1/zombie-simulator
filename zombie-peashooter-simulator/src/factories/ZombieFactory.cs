public class ZombieFactory : EntityFactory
{
    public override Entity CreateEntity(string entity)
    {
        EntityFactory factory = new AccessoryFactory();
        return new RegularZombie(factory.CreateEntity(entity));
    }
}