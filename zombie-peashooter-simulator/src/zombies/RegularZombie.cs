public class RegularZombie : IZombie
{
    private int _health = 50;
    protected List<IObserver> _observers = new();

    public int GetHealth() => _health;
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
    public void Notify()
    {
        for (int i = 0; i < _observers.Count; i++)
        {
            _observers.ElementAt(i).Update(this);
        }
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
        if (_health > 0)
        {
            _health -= value;
        }
        if (_health <= 0)
        {
            Die();
        }

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