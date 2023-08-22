using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WRA.General.Patterns;

namespace WRA.CharacterSystems.StatisticsSystem
{
   [CreateAssetMenu(menuName = "thief01/WRA-SDK/Profiles/Character Profile", fileName = "Character Profile")]
   public class CharacterProfile : ScriptableSingleton<CharacterProfile>
   {
      public float InteractionRange = 5;
      public DamageProvider DamageProvider;

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
