using System.Threading.Tasks;

namespace DesignPatternsInCSharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Command

/*            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000)
            };

            WriteLine(ba);

            foreach (var c in commands)
                c.Call();

            WriteLine(ba);

            foreach (var c in Enumerable.Reverse(commands))
                c.Undo();

            WriteLine(ba);
            
            */
            /*var ba = new BankAccount();
            var deposit = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
            var withdraw = new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 50);
            var composite = new CompositeBankAccountCommand(new []{deposit, withdraw});
            
            composite.Call();
            WriteLine(ba);
            composite.Undo();
            WriteLine(ba);*/

/*            var from = new BankAccount();
            from.Deposit(100);
            var to = new BankAccount();

            var mtc = new MoneyTransferCommand(from, to, 100);
            mtc.Call();
      

            // Deposited $100, balance is now 100
            // balance: 100
            // balance: 0

            WriteLine(from);
            WriteLine(to);*/


            #endregion
            #region Factory

/*            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);*/

            //var foo = await Foo.CreateAsync();

/*            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);*/
            
            /*var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
            drink.Consume();*/
            
            /*var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();*/

            #endregion
        }
    }
}