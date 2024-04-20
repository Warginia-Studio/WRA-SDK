namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public interface ICommand
    {
        string Name { get; }
    
        string Description { get; }
    
        void Execute(params string[] args);
    }
}
