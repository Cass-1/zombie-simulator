public abstract class Accessory : Entity
{

    private bool _isDead;
    private int _health;
    private string _entityType;
    public Accessory(int health, string entityType)
    {
        this._health = health;
        this._entityType = entityType;
        this._isDead = false;
    }

    public override int TakeDamage(int damage)
    {
        this._health -= damage;
        if (_health <= 0)
        {
            this.Die();
            return this._health * -1;
        }
        return 0;
    }

    public override void Die()
    {
        this._isDead = true;
    }
    public override bool IsDead()
    {
        return this._isDead;
    }

    public override void Add(Entity entity)
    {
        // doesn't implement this method
    }

    public override void Remove(Entity entity)
    {
        // doesn't implement this method
    }
    public override int GetHealth()
    {
        return this._health >= 0 ? this._health : 0;
    }

    public override string GetEntityType()
    {
        return this._entityType;
    }
}