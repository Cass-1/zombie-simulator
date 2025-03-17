
public class RegularZombie : Entity
{
    private bool _isDead;
    private int _health;

    private Entity? _accessory;
    public RegularZombie(Entity? accessory = null)
    {
        this._health = 50;
        this._accessory = accessory;
        this._isDead = false;
    }

    public override int TakeDamage(int damage)
    {
        if (this._accessory != null)
        {
            int leftoverDamage = this._accessory.TakeDamage(damage);
            if (this._accessory.IsDead())
            {
                this._accessory = null;
                if (leftoverDamage > 0)
                {
                    this.TakeDamage(leftoverDamage);
                }
            }
        }
        else
        {
            this._health -= damage;
            if (this._health <= 0)
            {
                this.Die();
                return this._health * -1;
            }
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

    public override string GetEntityType()
    {
        if (this._accessory != null)
        {
            return this._accessory.GetEntityType();
        }
        else
        {
            return "R";
        }
    }

    public override void Add(Entity accessory)
    {
        if (this._accessory == null)
        {
            this._accessory = accessory;
        }
    }

    public override void Remove(Entity accessory)
    {
        this._accessory = null;
    }

    public override int GetHealth()
    {
        int accessoryHealth = this._accessory == null ? 0 : this._accessory.GetHealth();
        return this._health >= 0 ? this._health + accessoryHealth : 0;
    }
}