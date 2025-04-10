public class RegularZombie : IZombie
{
    private int _health;
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

    public void TakeDamage(int value, DamageType damageType)
    {
        _health -= value;
    }

    DecorationType IZombie.GetType()
    {
        return DecorationType.REGULAR;
    }
}