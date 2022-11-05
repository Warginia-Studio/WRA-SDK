using System.Collections.Generic;
using UnityEngine;

namespace UIExtension.UI
{
    public class DropableConfiguration : ScriptableObject
    {
        public enum Status
        {
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
                    colors = new[] { possible, notPossible, busy, wrongType };
                }
                return colors;
            }
        }

        private Color[] colors;

        private Dictionary<string, Color> customStatuses;
    
        public Color GetFinalColor(Status status, string customStatusName = "")
        {
            switch (status)
            {
                case Status.custom:
                    return CustomStatuses[customStatusName];
                default:
                    return Colors[(int)status];
            }
        }
    }
}
