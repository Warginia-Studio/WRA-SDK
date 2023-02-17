namespace DependentObjects.Interfaces
{
    public interface IStaminaable
    {
        bool TryUseStamina(float stamina);
    
        void RegenStamina(float stamina);
    }
}
