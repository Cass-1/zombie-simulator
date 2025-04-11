public abstract class ZombieDecorator : IZombie
{
    protected int _health;
    protected IZombie _zombie;
    protected List<IObserver> _observers;
    protected ZombieType _zombieType;
    public bool HasZombie;
    public int GetHealth() => _health;
    public (int, int) GetDetailedHealth() => (_health, _zombie.GetHealth());
    public ZombieDecorator(IZombie zombie, int health)
    {
        _zombie = zombie;
        _health = health;
        _observers = new();
        this.HasZombie = true;
    }

    public IZombie WrappedObject()
    {
        return _zombie;
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Die()
    {
        Notify();
    }

    public ZombieType GetZombieType()
    {
        return _zombieType;
    }

    public abstract bool HasMetallicAccessory();

    public bool IsAlive()
    {
        return _zombie.IsAlive();
    }

    public void Notify()
    {
        for (int i = 0; i < _observers.Count; i++)
        {
            _observers.ElementAt(i).Update(this);
        }
    }

    public void RemoveAccessory()
    {
        _health = 0;
        Die();
    }

    public abstract void TakeDamage(int value);
    public abstract void TakeDamageFromAbove(int value);

}