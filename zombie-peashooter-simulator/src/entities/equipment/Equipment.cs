public class Equipment : Entity
{

    private bool _isDead;
    private int _health;
    private int _id;
    public Equipment(int health)
    {
        this._health = health;
        this._isDead = false;
    }
    public override void Add(Entity entity)
    {
        // not implemented for Equipment
    }

    public override void Remove(Entity entity)
    {
        // not implemented for Equipment
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
    public override bool isDead()
    {
        return this._isDead;
    }
}