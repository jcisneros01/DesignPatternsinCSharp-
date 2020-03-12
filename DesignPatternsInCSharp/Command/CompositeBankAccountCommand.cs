using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInCSharp.Command
{
    public class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public CompositeBankAccountCommand()
        {
            
        }

        public CompositeBankAccountCommand(IEnumerable<BankAccountCommand> collection): base(collection)
        {
            
        }
        
        public virtual void Call()
        {
            ForEach(cmd => cmd.Call());
        }

        public virtual void Undo()
        {
            foreach (var cmd in 
                ((IEnumerable<BankAccountCommand>)this).Reverse())
            {
                if (cmd.Success)cmd.Undo();
            }
        }

        public virtual bool Success {
            get { return this.All(cmd => cmd.Success); }
            set
            {
                foreach (var cmd in this)
                {
                    cmd.Success = value;
                }
            }
        }
    }
}