using UnityEngine;
using UnityEngine.UI;
using WRA.CharacterSystems.InventorySystem;

namespace WRA.UI.Controls.Feedback
{
   public class StatusChanger : MonoBehaviour
   {
      private Image status;
      private void Awake()
      {
         status = GetComponent<Image>();
      }

      public virtual void SetStatus(DragDropProfile.Status status, string customStatusName)
      {
         // this.status.color = DragDropManager.Instance.DragDropProfile.GetFinalColorOfDropStatus(status, customStatusName);
      }
   }
}
