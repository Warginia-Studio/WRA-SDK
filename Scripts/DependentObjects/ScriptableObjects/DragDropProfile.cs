using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace DependentObjects.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Drag Drop Profile", menuName = "thief01/UI Extension/DDP_Default")]
    public class DragDropProfile : ScriptableSingleton<DragDropProfile>
    {
        public enum Status
        {
            empty,
            selected,
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
        
        [SerializeField] private Vector2Int cellSize;
    
        [SerializeField] private Color dragColor;
        [SerializeField] private Color idlecolor;

        [Header("Statuses")]
        [SerializeField] private Color selected;
        [SerializeField] private Color possible;
        [SerializeField] private Color notPossible;
        [SerializeField] private Color busy;
        [SerializeField] private Color wrongType;
        [SerializeField] private CustomStatus[] customStatusConfiguration;

        public Vector2Int CellSize => cellSize;
    
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
                if (colors == null || colors.Length==0) 
                {
                    colors = new[] { Color.clear, selected, possible, notPossible, busy, wrongType };
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

        public void UpdateColors()
        {
            colors = new[] { Color.clear, selected, possible, notPossible, busy, wrongType };
        }
    }
}
