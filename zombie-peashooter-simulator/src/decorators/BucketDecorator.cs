public class BucketDecorator : ZombieDecorator
{
    public BucketDecorator(IZombie zombie) : base(zombie, 125)
    {
        _zombieType = ZombieType.BUCKET;
    }
    public override bool HasMetallicAccessory()
    {
        return true;
    }

    public override void TakeDamage(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            _zombie.TakeDamage(-1 * _health);
            Die();
        }
    }

    public override void TakeDamageFromAbove(int value)
    {
        TakeDamage(value);
    }
}