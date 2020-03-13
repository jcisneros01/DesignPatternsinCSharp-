using System;

namespace DesignPatternsInCSharp.Factory
{
    public class Tea: IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }
}