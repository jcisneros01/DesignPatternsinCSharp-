using System;

namespace DesignPatternsInCSharp.Factory
{
    public class Coffee: IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is sensational!");
        }
    }
}