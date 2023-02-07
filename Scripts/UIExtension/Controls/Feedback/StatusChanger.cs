using UnityEngine;
using UnityEngine.UI;
using WRACore.DependentObjects.ScriptableObjects;
using WRACore.UIExtension.Managers;

namespace WRACore.UIExtension.Controls.Feedback
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
