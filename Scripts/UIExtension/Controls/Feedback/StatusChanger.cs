using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Profiles;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Controls.Feedback
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
