using System.ComponentModel;

public abstract class Entity
{
    // return how much damage the entity was unable to take
    public abstract int TakeDamage(int damage);
    public abstract void Die();
    public abstract bool IsDead();
    public abstract string GetEntityType();
    public abstract void Add(Entity entity);
    public abstract void Remove(Entity entity);
    public abstract int GetHealth();
}