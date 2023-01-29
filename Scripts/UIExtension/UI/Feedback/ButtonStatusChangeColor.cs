using UnityEngine;

namespace UIExtension.UI.Feedback
{
    public class ButtonStatusChangeColor : ButtonStatusBase
    {
        [SerializeField] private Color activeColor;

        [SerializeField] private Color deactiveColor;


        public override void ChangedStatus(bool active)
        {
            controlledObject.color = active ? activeColor : deactiveColor;
        }
    }
}
