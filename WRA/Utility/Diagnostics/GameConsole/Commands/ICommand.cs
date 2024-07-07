using System.Collections.Generic;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public interface ICommand
    {
        string Name { get; }
    
        string Description { get; }
        
        string Usage { get; }
        
        List<string> Arguments { get; }
    
        void Execute(params string[] args);
    }
}
