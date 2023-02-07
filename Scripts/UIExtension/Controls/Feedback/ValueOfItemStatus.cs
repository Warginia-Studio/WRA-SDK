using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using WRACore.DependentObjects.ScriptableObjects;
using WRACore.UIExtension.Controls.Containers;

namespace WRACore.UIExtension.Controls.Feedback
{
    public class ValueOfItemStatus : MonoBehaviour
    {
        [SerializeField] private Image valuableStatus;
        [SerializeField] private Color[] colors = new Color[6];

        private ContainerHolder containerHolder;
        private Item holdingItem;
        private IEnumerator Start()
        {
            yield return null;
            containerHolder = GetComponent<ContainerHolder>();
            Debug.Log(containerHolder.HoldingItem.GetType());
            Debug.Log(typeof(Item));
            Debug.Log(containerHolder.HoldingItem.GetType() == typeof(Item));
            if (containerHolder.HoldingItem.GetType() == typeof(Item))
            {
                holdingItem = (Item)containerHolder.HoldingItem;
                valuableStatus.color = colors[(int)holdingItem.ValueType];
            }

        

        }
    }
}
