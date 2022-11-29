using System.Collections.Generic;
using UnityEngine;

namespace UIExtension.UI
{
    [CreateAssetMenu(fileName = "Drag Drop Profile", menuName = "thief01/UI Extension/Drag Drop Profile")]
    public class DragDropProfile : ScriptableObject
    {
        public enum Status
        {
            empty,
            possible,
            notPossible,
            busy,
            wrongType,
            custom
        }
    
        [System.Serializable]
        private struct CustomStatus
        {
            [SerializeField] public Color colorStatus;
            [SerializeField] public string statusName;
        }
    
        [SerializeField] private Color dragColor;
        [SerializeField] private Color idlecolor;
    
        [SerializeField] private Color possible;
        [SerializeField] private Color notPossible;
        [SerializeField] private Color busy;
        [SerializeField] private Color wrongType;
        [SerializeField] private CustomStatus[] customStatusConfiguration;
    
        private Dictionary<string, Color> CustomStatuses
        {
            get
            {
                if (customStatuses == null)
                {
                    customStatuses = new Dictionary<string, Color>();
                    for (int i = 0; i < customStatusConfiguration.Length; i++)
                    {
                        customStatuses.Add(customStatusConfiguration[i].statusName, customStatusConfiguration[i].colorStatus);
                    }
                }

                return customStatuses;
            }
        }

        private Color[] Colors
        {
            get
            {
                if (colors == null)
                {
                    colors = new[] { Color.clear, possible, notPossible, busy, wrongType };
                }
                return colors;
            }
        }

        private Color[] colors;

        private Dictionary<string, Color> customStatuses;
    
        public Color GetFinalColorOfDropStatus(Status status, string customStatusName = "")
        {
            switch (status)
            {
                case Status.custom:
                    return CustomStatuses[customStatusName];
                default:
                    return Colors[(int)status];
            }
        }

        public Color DragableColor(bool dragging)
        {
            return dragging ? dragColor : idlecolor;
        }
    }
}
