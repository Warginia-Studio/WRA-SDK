namespace WRA.CharacterSystems.InteractionsSystem
{
    public interface IInteractable
    {
        void Interract(InteractionControlerBase who);

        string GetInteractionDescription();
    }
}
