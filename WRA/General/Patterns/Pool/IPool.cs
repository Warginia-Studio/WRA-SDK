namespace WRA.General.Patterns.Pool
{
    public interface IPool
    {
        void FreePool();
        
        void KillAll();
        
    }
}