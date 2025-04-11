using System.Data;

public class GameEventManager
{
    private GameObjectManager _objectManager;

    public GameEventManager(GameObjectManager objectManager)
    {
        _objectManager = objectManager;
    }
    public void SimulateCollisionDetection(CollisionType collisionTypes)
    {
        if (collisionTypes == CollisionType.PEASHOOTER)
        {
            DoDamage(25, _objectManager.GetNextZombie());
        }
        else if (collisionTypes == CollisionType.WATERMELON)
        {
            DoDamageFromAbove(40, _objectManager.GetNextZombie());
        }
        else if (collisionTypes == CollisionType.MAGNET_SHROOM)
        {
            ApplyMagnetForce(_objectManager.GetNextZombie());
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public void DoDamage(int value, IZombie e)
    {
        e.TakeDamage(value);
    }
    public void DoDamageFromAbove(int value, IZombie e)
    {
        e.TakeDamageFromAbove(value);
    }
    public void ApplyMagnetForce(IZombie e)
    {
        if (e.HasMetallicAccessory())
        {
            e.RemoveAccessory();
        }
    }
}