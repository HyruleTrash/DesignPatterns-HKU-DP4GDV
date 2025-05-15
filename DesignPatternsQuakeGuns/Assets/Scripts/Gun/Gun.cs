public class Gun
{
    private IShootStrategy _strategy;
    public IShootStrategy strategy { set { _strategy = value; } }
}