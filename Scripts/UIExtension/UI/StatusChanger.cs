using UIExtension.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.UI
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
         this.status.color = DragDropManager.Instance.DragDropProfile.GetFinalColorOfDropStatus(status, customStatusName);
      }
   }
}
