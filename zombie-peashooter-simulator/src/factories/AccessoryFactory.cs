public class AccessoryFactory : EntityFactory
{
    public override Entity CreateEntity(string entity)
    {
        if (entity == "cone")
        {
            return new Cone();
        }
        else if (entity == "bucket")
        {
            return new Bucket();
        }
        else if (entity == "screen")
        {
            return new Screen();
        }
        else
        {
            throw new ArgumentException("invalid argument");
        }
    }
}