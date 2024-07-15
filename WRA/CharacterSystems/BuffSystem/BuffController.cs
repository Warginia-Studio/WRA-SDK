using System;
using System.Collections.Generic;
using UnityEngine;

namespace WRA.CharacterSystems.BuffSystem
{
    public class BuffController : CharacterSystemBase
    {
        public List<BuffBase> ActiveBuffs => activeBuffs;
        
        private List<BuffBase> activeBuffs = new List<BuffBase>();

        private void Update()
        {
            for (int i = 0; i < activeBuffs.Count; i++)
            {
                activeBuffs[i].Duration -= Time.deltaTime;
                if (activeBuffs[i].Duration <= 0)
                {
                    activeBuffs[i].OnEndBuff(GetCharacterData());
                    activeBuffs.RemoveAt(i);
                }
            }
        
        }

        public void AddBuff(BuffBase buffBase)
        {
            activeBuffs.Add(Instantiate(buffBase));
            buffBase.OnBeginBuff(GetCharacterData());
        }
    }
}