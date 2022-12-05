using System.Collections;
using System.Collections.Generic;
using Patterns;
using UIExtension.UI;
using UnityEngine;
using UnityEngine.Events;

public class StatusManager : MonoBehaviourSingletonAutoCreateUI<StatusManager>
{
    public UnityEvent<DragDropProfile.Status, string, Vector2Int, Vector2Int> OnStatusChanged = new UnityEvent<DragDropProfile.Status, string, Vector2Int, Vector2Int>();


    public void SetStatus(DragDropProfile.Status status, string customStatus, Vector2Int startPos, Vector2Int endPos)
    {
        OnStatusChanged.Invoke(status, customStatus, startPos, endPos);
    }

    public void Reset()
    {
        OnStatusChanged.Invoke(DragDropProfile.Status.empty, "", -Vector2Int.one, -Vector2Int.one);
    }
}
