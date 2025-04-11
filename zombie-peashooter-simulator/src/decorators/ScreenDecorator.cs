public class ScreenDecorator : ZombieDecorator
{
    public ScreenDecorator(IZombie zombie, int health) : base(zombie, health)
    {
    }
    public override bool HasMetallicAccessory()
    {
        return true;
    }

    public override void TakeDamage(int value)
    {
        _health -= value;
        if (_health < 0)
        {
            _zombie.TakeDamage(-1 * _health);
            _health = 0;
        }
    }

    public override void TakeDamageFromAbove(int value)
    {
        _zombie.TakeDamage(value);
    }

    public override ZombieType GetZombieType()
    {
        if (_health > 0)
        {
            return ZombieType.CONE;
        }
        else
        {
            return _zombie.GetZombieType();
        }
    }
}