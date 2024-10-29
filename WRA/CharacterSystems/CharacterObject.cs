using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using WRA.General.Patterns.Pool;

namespace WRA.CharacterSystems
{
    public abstract class CharacterObject : PoolObject
    {
        [HideInInspector] public UnityEvent OnSystemsRegistered;
        public bool SystemsRegistered { get; private set; }
        private List<ICharacterSystem> characterSystemBases;
        private List<ICharacterChildren> characterChildrens = new List<ICharacterChildren>();

        private bool registeredSystems = false;
        private void Awake()
        {
            RegisterAllSystems();
        }

        public T GetCharacterSystem<T>() where T : Transform
        {
            if(!registeredSystems)
                RegisterAllSystems();
            return characterSystemBases.Find(ctg => ctg is T) as T;
        }

        private void RegisterAllSystems()
        {
            if (characterSystemBases != null)
                return;
            registeredSystems = true;
            characterSystemBases = GetComponents<ICharacterSystem>().ToList();
            characterSystemBases.ForEach(ctg=> ctg.SetCharacterObject(this));
        
            OnSystemsRegistered.Invoke();
            SystemsRegistered = true;
        }
        
        public void RegisterChildren(ICharacterChildren characterChildren)
        {
            characterChildren.OnInit(GetCharacterSystem<Transform>());
            characterChildrens.Add(characterChildren);
        }
    }
}
