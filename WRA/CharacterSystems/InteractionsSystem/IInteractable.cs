namespace WRA.CharacterSystems.InteractionsSystem
{
    public interface IInteractable
    {
        void Interract(InteractionControllerSystemBase who);

        string GetInteractionDescription();
    }
}
