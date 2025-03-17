public abstract class Entity
{
    public abstract void Add(Entity entity);
    public abstract void Remove(Entity entity);

    // return how much damage the entity was unable to take
    public abstract int TakeDamage(int damage);
    public abstract void Die();
    public abstract bool isDead();
}