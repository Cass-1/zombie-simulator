public class Screen : Accessory
{
    public Screen() : base(25)
    {
    }

    public override string GetEntityType()
    {
        return "S";
    }
}