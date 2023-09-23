using UnityEngine;

namespace WRA.UI.PanelsSystem.CinematicSystem
{
    [System.Serializable]
    public struct Curtain
    {
        public RectTransform curtain;
        public Vector3 showPosition;
        public Vector3 hidePosition;

        public void UpdatePositionByDelta(float delta)
        {
            curtain.anchoredPosition = Vector3.Lerp(hidePosition, showPosition, delta);
        }
    }
}
