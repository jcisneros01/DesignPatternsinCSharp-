using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Metadata;
using DesignPatternsInCSharp.Adapter;

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
            #region Adapter
            /*foreach (var vo in new List<VectorObject>
            {
                new VectorRectangle(1, 1, 10, 10),
                new VectorRectangle(3, 3, 6, 6)
            })
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    foreach (var point in adapter)
                    {
                        DrawPoint(point);
                        DrawPoint(point);
                    }
                }
            }*/
            #endregion

            var b = new ContainerBuilder();
            b.RegisterType<OpenCommand>()
                .As<ICommand>()
                .WithMetadata("Name", "Open");
            b.RegisterType<SaveCommand>()
                .As<ICommand>()
                .WithMetadata("Name", "Save");
            //b.RegisterType<Button>();
           // b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd =>
                new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();

            using (var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
               // editor.ClickAll();
                foreach (var button in editor.Buttons)
                {
                    button.PrintMe();
                }
            }

        }

        private static void DrawPoint(Point p)
        {
            Console.Write(".");
        }

    }
    
    public interface ICommand
    {
        void Execute();
    }

    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving current file");
        }
    }

    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }

    public class Button
    {
        private ICommand _command;
        private  string _name { get; set; }

        public Button(ICommand command, string name)
        {
            if (command == null)
            {
                throw new ArgumentNullException(paramName: nameof(command));
            }
            
            _command = command;
            _name = name;
        }

        public void Click()
        {
            _command.Execute();
        }

        public void PrintMe()
        {
            Console.WriteLine($"I am a button called {_name}");
        }
    }
    
    
    public class Editor
    {
        private readonly IEnumerable<Button> buttons;

        public IEnumerable<Button> Buttons => buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            this.buttons = buttons;
        }

        public void ClickAll()
        {
            foreach (var btn in buttons)
            {
                btn.Click();
            }
        }
    }
}