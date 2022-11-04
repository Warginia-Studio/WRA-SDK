using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableConfiguration : ScriptableObject
{
    public enum Status
    {
        possible,
        notPossible,
        busy,
        wrongType,
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

    private Dictionary<string, Color> customStatuses;
    
    public Color GetFinalColor(Status status, string customStatusName = "")
    {
        switch (status)
        {
            case Status.possible:
                return possible;
            case Status.notPossible:
                return notPossible;
            case Status.busy:
                return busy;
            case Status.wrongType:
                return wrongType;
            default:
                return CustomStatuses[customStatusName];
        }
    }
}
