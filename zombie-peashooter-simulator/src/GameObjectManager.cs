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

    public IEnumerable<ZombieType> GetZombieTypes()
    {
        return _enemies.Select(x => x.GetZombieType());
    }

    public string GetZombieGraphics()
    {
        string zombieArray = "[";
        IEnumerable<ZombieType> types = GetZombieTypes();
        foreach (var type in types)
        {
            if (type == ZombieType.REGULAR)
            {
                zombieArray += "R,";
            }
            else if (type == ZombieType.CONE)
            {
                zombieArray += "C,";
            }
            else if (type == ZombieType.SCREEN)
            {
                zombieArray += "S,";
            }
            else if (type == ZombieType.BUCKET)
            {
                zombieArray += "B,";
            }
            else
            {
                throw new ConstraintException();
            }
        }
        zombieArray += "]";
        return zombieArray;
    }
}