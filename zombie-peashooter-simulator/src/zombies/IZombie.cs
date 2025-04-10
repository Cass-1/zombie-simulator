public interface IZombie
{
    public void TakeDamage(int value, DamageType damageType);
    public DecorationType GetZombieType();
    public void RemoveAccessory();
    public bool IsAlive();
    public bool HasMetallicAccessory();
}

public enum DamageType
{
    STRAIGHT,
    LOB
}

public enum DecorationType
{
    CONE,
    BUCKET,
    SCREEN
}