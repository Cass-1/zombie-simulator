using System.Data;

public class GameObjectManager : IObserver
{
    public bool HasZombies => _enemies.Count > 0;
    private List<IZombie> _enemies = new();

    public void Update(IObservable observable)
    {
        if (observable is IZombie)
        {
            _ = _enemies.Remove(observable as IZombie);
        }
    }

    public void AddZombie(ZombieType type)
    {
        _enemies.Add(ZombieFactory.CreateDecorator(type));
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