public class Cone : Accessory
{
    public Cone() : base(25)
    {
    }

    public override string GetEntityType()
    {
        return "C";
    }
}