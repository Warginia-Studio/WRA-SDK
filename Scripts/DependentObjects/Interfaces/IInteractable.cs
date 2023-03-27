using Character;
using Character.Interactions;

namespace DependentObjects.Interfaces
{
    public interface IInteractable
    {
        void Interract(InteractionControllerBase who);

        string GetInteractionDescription();
    }
}
