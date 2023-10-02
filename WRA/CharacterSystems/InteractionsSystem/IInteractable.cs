namespace WRA.CharacterSystems.InteractionsSystem
{
    public interface IInteractable
    {
        void Interract(InteractionControlerSystemBase who);

        string GetInteractionDescription();
    }
}
