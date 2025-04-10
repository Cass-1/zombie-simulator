public class GameObjectManager : IObserver
{
    public List<IZombie> Enemies = new();

    public void Update(IObservable observable)
    {
        if (observable is IZombie)
        {
            _ = Enemies.Remove(observable as IZombie);
        }
    }
}