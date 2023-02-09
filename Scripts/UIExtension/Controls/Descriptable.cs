using UnityEngine;

namespace UIExtension.Controls
{
    public class Descriptable : DescriptableBase
    {
        [SerializeField][TextArea(15,20)] private string description;
        protected override string GetDescription()
        {
            return description;
        }
    }
}
