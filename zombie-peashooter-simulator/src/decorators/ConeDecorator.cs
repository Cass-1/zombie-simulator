public class ConeDecorator : ZombieDecorator
{
    public ConeDecorator(IZombie zombie) : base(zombie, 25)
    {
        _zombieType = ZombieType.CONE;
    }
    public override bool HasMetallicAccessory()
    {
        return false;
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