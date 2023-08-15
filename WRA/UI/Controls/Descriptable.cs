using UnityEngine;
using WRA.General.Interfaces;

namespace WRA.UI.Controls
{
    public class Descriptable : DescriptableBase
    {
        [SerializeField][TextArea(15,20)] private string description;

        private IDescriptable descriptable;
        
        private void Awake()
        {
            if (descriptable == null)
                descriptable = GetComponent<IDescriptable>();
        }

        protected override string GetDescription()
        {
            if (descriptable != null)
                return descriptable.GetDescription();
            return description;
        }
    }
}
