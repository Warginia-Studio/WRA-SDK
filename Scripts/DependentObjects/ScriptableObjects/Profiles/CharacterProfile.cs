using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Patterns;
using UnityEngine;

[CreateAssetMenu(menuName = "thief01/Profiles/Character Profile", fileName = "Character Profile")]
public class CharacterProfile : ScriptableSingleton<CharacterProfile>
{
   public DamageProvider DamageProvider;
   public List<string> statisticsNames = new List<string>();

}
