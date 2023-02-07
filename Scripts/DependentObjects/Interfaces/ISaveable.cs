namespace WRACore.DependentObjects.Interfaces
{
    public interface ISaveable
    {
        string GetSaveData();

        void LoadFromData(string data);
    }
}