public class GameEventManager
{
    public void simulateCollisionDetection(CollisionTypes collisionTypes)
    {
        if (collisionTypes == CollisionTypes.PEASHOOTER)
        {
            throw new NotImplementedException();
        }
        else if (collisionTypes == CollisionTypes.WATERMELON)
        {
            throw new NotImplementedException();
        }
        else if (collisionTypes == CollisionTypes.MAGNET_SHROOM)
        {
            throw new NotImplementedException();
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public void DoDamage(int value, DamageType damageType, IZombie e)
    {
        e.TakeDamage(value, damageType);
    }
    public void ApplyMagnetForce(IZombie e)
    {
        if (e.HasMetallicAccessory())
        {
            e.RemoveAccessory();
        }
    }
}