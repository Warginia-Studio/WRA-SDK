using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;

namespace WRA.General.Effects
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Behaviours/Effects/Base Effect")]
    public abstract class EffectBehaviourBase : ScriptableObject, IResourceEffect
    {

        public abstract void PlayEffect(Vector3 position);
    }
}
