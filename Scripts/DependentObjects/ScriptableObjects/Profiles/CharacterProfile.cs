using System.Collections.Generic;
using DependentObjects.ScriptableObjects.Providers;
using Patterns;
using UnityEngine;

namespace DependentObjects.ScriptableObjects.Profiles
{
   [CreateAssetMenu(menuName = "thief01/Profiles/Character Profile", fileName = "Character Profile")]
   public class CharacterProfile : ScriptableSingleton<CharacterProfile>
   {
      public DamageProvider DamageProvider;
      public List<string> statisticsNames = new List<string>();

   }
}
