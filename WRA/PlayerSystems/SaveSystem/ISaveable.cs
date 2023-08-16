namespace WRA.PlayerSystems.SaveSystem
{
    public interface ISaveable
    {
        string GetSaveData();

        void LoadFromData(string data);
    }
}