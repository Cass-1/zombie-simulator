using System.Data;

public class GameObjectManager : IObserver
{
    public bool HasZombies => _enemies.Count > 0;
    private List<IZombie> _enemies = new();

    public void Update(IObservable observable)
    {
        if (observable is RegularZombie)
        {
            _ = _enemies.Remove(observable as IZombie);
            observable.Detach(this);
        }
        else if (observable is ZombieDecorator)
        {
            observable.Detach(this);
            int index = _enemies.IndexOf(observable as IZombie);
            ZombieDecorator zombieDecorator = observable as ZombieDecorator;
            if (zombieDecorator.HasZombie)
            {
                IZombie zombie = (zombieDecorator).WrappedObject();
                _enemies[index] = zombie;
                zombie.Attach(this);
            }
            else
            {
                _enemies.Remove(zombieDecorator);
            }
        }
    }

    public void AddZombie(ZombieType type)
    {
        var zombie = ZombieFactory.CreateDecorator(type);
        _enemies.Add(zombie);
        zombie.Attach(this);

    }
    public IZombie GetNextZombie()
    {
        return _enemies.First();
    }

    public List<string> GetZombieTypesAndHealth()
    {
        List<string> typesAndHealth = new();
        foreach (var zombie in _enemies)
        {
            if (zombie is ZombieDecorator)
            {
                (int accessoryHealth, int wrappedHealth) = (zombie as ZombieDecorator).GetDetailedHealth();
                typesAndHealth.Add($"({zombie.GetZombieType()},({accessoryHealth},{wrappedHealth}))");
            }
            else
            {
                typesAndHealth.Add($"({zombie.GetZombieType()},{zombie.GetHealth()})");
            }
        }
        return typesAndHealth;
    }

    public string GetZombieGraphics()
    {
        string zombieArray = "[";
        List<string> info = GetZombieTypesAndHealth();
        foreach (var i in info)
        {
            zombieArray += $"{i},";
        }
        zombieArray += "]";
        return zombieArray;
    }
}