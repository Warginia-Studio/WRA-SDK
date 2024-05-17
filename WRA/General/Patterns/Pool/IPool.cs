namespace WRA.General.Patterns.Pool
{
    public interface IPool
    {
        void FillPool(int count);
        
        void FreePool();
        
        void KillAll();
        
        void SetPrefab(string name);
        
        TObject SpawnObject<TObject>() where TObject : PoolObjectBase;
    }
}