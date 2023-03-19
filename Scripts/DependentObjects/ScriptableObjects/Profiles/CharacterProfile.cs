using System.Collections.Generic;
using System.Linq;
using DependentObjects.Classes.Statistics;
using DependentObjects.ScriptableObjects.Providers;
using Patterns;
using UnityEngine;

namespace DependentObjects.ScriptableObjects.Profiles
{
   [CreateAssetMenu(menuName = "thief01/Profiles/Character Profile", fileName = "Character Profile")]
   public class CharacterProfile : ScriptableSingleton<CharacterProfile>
   {
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
