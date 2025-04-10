public abstract class ZombieDecorator : IZombie
{
    protected int _health;
    protected IZombie _zombie;
    public ZombieDecorator(IZombie zombie, int health)
    {
        _zombie = zombie;
        _health = health;
    }

    public abstract DecorationType GetZombieType();

    public abstract bool HasMetallicAccessory();

    public bool IsAlive()
    {
        return _zombie.IsAlive();
    }

    public void RemoveAccessory()
    {
        _health = 0;
    }

    public abstract void TakeDamage(int value, DamageType damageType);

}