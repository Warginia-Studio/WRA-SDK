using System;
using System.Collections;
using System.Collections.Generic;
using UIExtension.Managers;
using UIExtension.UI;
using UnityEngine;
using UnityEngine.UI;

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
