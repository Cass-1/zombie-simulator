public abstract class ZombieDecorator : IZombie
{
    protected int _health;
    protected IZombie _zombie;
    protected List<IObserver> _observers;
    public ZombieDecorator(IZombie zombie, int health)
    {
        _zombie = zombie;
        _health = health;
        _observers = new();
    }

    public void Attach(IObserver observer)
    {
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Where(x => x != observer);
    }

    public void Die()
    {
        Notify();
    }

    public abstract DecorationType GetZombieType();

    public abstract bool HasMetallicAccessory();

    public bool IsAlive()
    {
        return _zombie.IsAlive();
    }

    public void Notify()
    {
        this._observers.ForEach(x => x.Update());
    }

    public void RemoveAccessory()
    {
        _health = 0;
    }

    public abstract void TakeDamage(int value, DamageType damageType);

}