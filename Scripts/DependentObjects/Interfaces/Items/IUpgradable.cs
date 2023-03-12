namespace DependentObjects.Interfaces.Items
{
    public interface IUpgradable
    {
        void Upgrade();

        (int, int) GetUpgradeLevels();

        bool IsPossibleToUpgrade();

        string GetUpgradeRequired();
    }
}
