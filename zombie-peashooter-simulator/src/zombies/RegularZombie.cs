public class RegularZombie : IZombie
{
    private int _health;
    protected List<IObserver> _observers = new();
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
        _observers.ForEach(x => x.Update(this));
    }
    public void Notify()
    {
        _observers.ForEach(x => x.Update(this));
    }
    public bool HasMetallicAccessory()
    {
        return false;
    }

    public bool IsAlive()
    {
        return _health > 0;
    }

    public void RemoveAccessory()
    {
        // do nothing
    }

    public void TakeDamage(int value)
    {
        _health -= value;
    }

    public ZombieType GetZombieType()
    {
        return ZombieType.REGULAR;
    }

    public void TakeDamageFromAbove(int value)
    {
        this.TakeDamage(value);
    }
}