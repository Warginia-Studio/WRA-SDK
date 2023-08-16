namespace WRA.CharacterSystems.InteractionsSystem
{
    public interface IInteractable
    {
        void Interract(InteractionControllerBase who);

        string GetInteractionDescription();
    }
}
