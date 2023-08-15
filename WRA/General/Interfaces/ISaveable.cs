namespace WRA.General.Interfaces
{
    public interface ISaveable
    {
        string GetSaveData();

        void LoadFromData(string data);
    }
}