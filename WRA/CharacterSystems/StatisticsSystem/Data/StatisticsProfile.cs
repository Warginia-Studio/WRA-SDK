using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WRA.General.Patterns.Singletons;

namespace WRA.CharacterSystems.StatisticsSystem.Data
{
   [CreateAssetMenu(menuName = "thief01/WRA-SDK/Profiles/Statistics Profile", fileName = "Statistics Profile")]
   public class StatisticsProfile : ScriptableObject
   {
      public float InteractionRange = 5;

      public List<string> statisticsNames
      {
         get
         {
            return StatisticInfos.Select(ctg => ctg.StatisticName).ToList();
         }
      }
      public List<DynamicStatisticInfo> StatisticInfos = new List<DynamicStatisticInfo>();
   }
}
