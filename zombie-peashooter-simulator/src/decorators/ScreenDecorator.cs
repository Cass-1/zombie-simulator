public class ScreenDecorator : ZombieDecorator
{
    public ScreenDecorator(IZombie zombie) : base(zombie, 25)
    {
        _zombieType = ZombieType.SCREEN;
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
        _zombie.TakeDamage(value);
        if (!_zombie.IsAlive())
        {
            this.HasZombie = false;
            Die();
        }
    }
}