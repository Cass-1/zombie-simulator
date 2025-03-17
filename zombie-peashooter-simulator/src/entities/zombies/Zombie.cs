using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Zombie : Entity
{
    private bool _isDead;
    private int _health;
    private int _id;

    private List<Entity> _subEntities = new();
    public Zombie(int health, List<Entity> subEntities)
    {
        this._health = health;
        this._subEntities.AddRange(subEntities);
        this._isDead = false;
    }
    public override void Add(Entity entity)
    {
        this._subEntities.Add(entity);
    }

    public override void Die()
    {
        this._isDead = true;
    }

    public override bool isDead()
    {
        return this._isDead;
    }

    public override void Remove(Entity entity)
    {
        this._subEntities.Remove(entity);
    }

    public override int TakeDamage(int damage)
    {
        if (this._subEntities.Count > 0)
        {
            Entity entity = this._subEntities.First();
            int leftoverDamage = entity.TakeDamage(damage);
            if (entity.isDead())
            {
                this._subEntities.Remove(entity);
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
}