public class ScreenDecorator : ZombieDecorator
{
    public ScreenDecorator(IZombie zombie, int health) : base(zombie, health)
    {
    }
    public override bool HasMetallicAccessory()
    {
        return true;
    }

    public override void TakeDamage(int value, DamageType damageType)
    {
        if (damageType == DamageType.LOB)
        {
            _zombie.TakeDamage(value, damageType);
        }
        else
        {
            _health -= value;
            if (_health < 0)
            {
                _zombie.TakeDamage(-1 * _health, damageType);
                _health = 0;
            }
        }
    }

    public override DecorationType GetZombieType()
    {
        if (_health > 0)
        {
            return DecorationType.CONE;
        }
        else
        {
            return _zombie.GetZombieType();
        }
    }
}