public interface IZombie : IObservable
{
    public void TakeDamage(int value);
    public ZombieType GetZombieType();
    public void RemoveAccessory();
    public bool IsAlive();
    public bool HasMetallicAccessory();
    public void Die();
    public void TakeDamageFromAbove(int value);
}

public enum DamageType
{
    STRAIGHT,
    LOB
}