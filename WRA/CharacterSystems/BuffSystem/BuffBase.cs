using UnityEngine;
using UnityEngine.Serialization;
using WRA.CharacterSystems.SkillsSystem;

namespace WRA.CharacterSystems.BuffSystem
{
    public abstract class BuffBase : ScriptableObject
    {
        public float Duration { get; set; }
        public float BaseDuration => baseDuration;
        public float PercentageDuration => Duration / BaseDuration;
        
        public string BuffName;
        [TextArea] public string DefaultDescription;
        public Sprite BuffSprite;
        [SerializeField] float baseDuration;
    
        protected BuffController BuffController;
        
        public abstract string GetDescription<T>(T owner) where T : CharacterData;
        
        public abstract void OnBeginBuff<T>(T owner) where T : CharacterData;
        
        public abstract void OnEndBuff<T>(T owner) where T : CharacterData;
    }
}