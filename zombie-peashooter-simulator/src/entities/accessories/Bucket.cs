public class Bucket : Accessory
{
    public Bucket() : base(100)
    {
    }

    public override string GetEntityType()
    {
        return "B";
    }
}