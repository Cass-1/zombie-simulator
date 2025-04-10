public class BucketDecorator : ZombieDecorator
{
    public BucketDecorator(IZombie zombie, int health) : base(zombie, health)
    {
    }
    public override bool HasMetallicAccessory()
    {
        return true;
    }

    public override void TakeDamage(int value, DamageType damageType)
    {
        _health -= value;
        if (_health < 0)
        {
            _zombie.TakeDamage(-1 * _health, damageType);
            _health = 0;
        }
    }

    public override DecorationType GetZombieType()
    {
        if (_health > 0)
        {
            return DecorationType.BUCKET;
        }
        else
        {
            return _zombie.GetZombieType();
        }
    }
}