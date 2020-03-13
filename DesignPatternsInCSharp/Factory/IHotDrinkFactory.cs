namespace DesignPatternsInCSharp.Factory
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}