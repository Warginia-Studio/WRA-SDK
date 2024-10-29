using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WRA.CharacterSystems.BuffSystem
{
    public class BuffController : MonoBehaviour
    {
        public UnityEvent<BuffBase> OnBuffAdded;
        public UnityEvent<BuffBase> OnBuffRemoved;
        
        public List<BuffBase> ActiveBuffs => activeBuffs;
        
        private List<BuffBase> activeBuffs = new List<BuffBase>();

        private void Update()
        {
            for (int i = 0; i < activeBuffs.Count; i++)
            {
                activeBuffs[i].Duration -= Time.deltaTime;
                if (activeBuffs[i].Duration <= 0)
                {
                    RemoveBuff(activeBuffs[i]);
                }
            }
        
        }

        public void AddBuff(BuffBase buffBase)
        {
            activeBuffs.Add(Instantiate(buffBase));
            activeBuffs[^1].OnBeginBuff(GetCharacterData());
            OnBuffAdded?.Invoke(activeBuffs[^1]);
        }
        
        public void RemoveBuff(BuffBase buffBase)
        {
            activeBuffs[^1].OnEndBuff(GetCharacterData());
            activeBuffs.Remove(buffBase);
            OnBuffRemoved?.Invoke(buffBase);
        }
    }
}