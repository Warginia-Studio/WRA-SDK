using System.Collections.Generic;
using DependentObjects.Enums;
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

        public bool UseColors => useColors;
        public bool UseSprites => useSprites;
    
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
        [SerializeField] private bool stretchItemInArmamentSlot = false;
        [SerializeField] private bool stretchItemInUseableSlot = false;

        [Header("Background Colors value of item")] 
        [SerializeField] private bool useColors;
        [SerializeField] private Color commonColor;
        [SerializeField] private Color uncommonColor;
        [SerializeField] private Color rareColor;
        [SerializeField] private Color epicColor;
        [SerializeField] private Color lengedaryColor;
        [SerializeField] private Color mythicColor;
        
        [Header("Background images value of item")] 
        [SerializeField] private bool useSprites;
        [SerializeField] private Sprite commonSprite;
        [SerializeField] private Sprite uncommonSprite;
        [SerializeField] private Sprite rareSprite;
        [SerializeField] private Sprite epicSprite;
        [SerializeField] private Sprite lengedarySprite;
        [SerializeField] private Sprite mythicSprite;

        public Vector2Int CellSize => cellSize;
        public bool StretchItemInArmamentSlot => stretchItemInArmamentSlot;
        public bool StretchItemInUseableSlot => stretchItemInUseableSlot;
    
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

        private Color[] StatusesColors
        {
            get
            {
                if (statusesColors == null || statusesColors.Length==0) 
                {
                    statusesColors = new[] { Color.clear, selected, possible, notPossible, busy, wrongType };
                }
                return statusesColors;
            }
        }

        private Color[] BackgroundValuesColors
        {
            get
            {
                if (backgroundValuesColors == null || backgroundValuesColors.Length == 0)
                {
                    backgroundValuesColors = new[]
                        { commonColor, uncommonColor, rareColor, epicColor, lengedaryColor, mythicColor };
                }

                return backgroundValuesColors;
            }
        }
        
        private Sprite[] BackgroundValuesSprites
        {
            get
            {
                if (backgroundValuesSprites == null || backgroundValuesSprites.Length == 0)
                {
                    backgroundValuesSprites = new[]
                        { commonSprite, uncommonSprite, rareSprite, epicSprite, lengedarySprite, mythicSprite };
                }

                return backgroundValuesSprites;
            }
        }
        
        

        private Color[] statusesColors;
        private Color[] backgroundValuesColors;
        private Sprite[] backgroundValuesSprites;

        private Dictionary<string, Color> customStatuses;
    
        public Color GetFinalColorOfDropStatus(Status status, string customStatusName = "")
        {
            switch (status)
            {
                case Status.custom:
                    return CustomStatuses[customStatusName];
                default:
                    return StatusesColors[(int)status];
            }
        }

        public Color GetColorForValueOfItem(ValueOfItem valueOfItem)
        {
            return BackgroundValuesColors[(int)valueOfItem];
        }
        
        public Sprite GetSpriteForValueOfItem(ValueOfItem valueOfItem)
        {
            return BackgroundValuesSprites[(int)valueOfItem];
        }

        public Color DragableColor(bool dragging)
        {
            return dragging ? dragColor : idlecolor;
        }
        
        

        public void UpdateColors()
        {
            statusesColors = new[] { Color.clear, selected, possible, notPossible, busy, wrongType };
        }
    }
}
