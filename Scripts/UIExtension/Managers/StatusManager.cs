using UnityEngine;
using UnityEngine.Events;
using WRACore.DependentObjects.ScriptableObjects;
using WRACore.Patterns;

namespace WRACore.UIExtension.Managers
{
    public class StatusManager : MonoBehaviourSingletonAutoCreateUI<StatusManager>
    {
        public struct OnStatusChangedInfo
        {
            public DragDropProfile.Status Status;
            public string CustomStatus;
            public Vector2Int StartPos;
            public Vector2Int EndPos;
            public Container.Container Holder;
        }
        public UnityEvent<OnStatusChangedInfo> OnStatusChanged =
            new UnityEvent<OnStatusChangedInfo>();


        public void SetStatus(DragDropProfile.Status status, string customStatus, Container.Container container, Vector2Int startPos, Vector2Int endPos)
        {
            OnStatusChangedInfo oschi = new OnStatusChangedInfo();
            oschi.Holder = container;
            oschi.Status = status;
            oschi.CustomStatus = customStatus;
            oschi.StartPos = startPos;
            oschi.EndPos = endPos;
            OnStatusChanged.Invoke(oschi);
        }

        public void Reset()
        {
            OnStatusChangedInfo oschi = new OnStatusChangedInfo();
            oschi.Holder = null;
            oschi.Status = DragDropProfile.Status.empty;
            oschi.CustomStatus = "";
            oschi.StartPos = -Vector2Int.one;
            oschi.EndPos = -Vector2Int.one;
            OnStatusChanged.Invoke(oschi);
        }
    }
}
