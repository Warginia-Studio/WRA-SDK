using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WRA.CharacterSystems.AmmoSystem
{
    public class AmmoController : CharacterSystemBase
    {
        [HideInInspector] public UnityEvent<int, string> OnAddAmmo;
        [HideInInspector] public UnityEvent<int, string> OnRemoveAmmo;
    
        [SerializeField] private List<AmmoData> AmmoDatas;
        
        public void SetAmmo(string ammoName, int count)
        {
            var ammodata = AmmoDatas.Find(ctg => ctg.AmmoName == ammoName);
            if (ammodata == null)
                return;
            ammodata.AmmoCont = count;
        }
        
        public void SetAmmoData(List<AmmoData> ammoData)
        {
            AmmoDatas = ammoData;
        }
        
        public void AddAmmo(string ammoName, int count = 1)
        {
            var ammodata = AmmoDatas.Find(ctg => ctg.AmmoName == ammoName);
            if (ammodata == null)
                return;
            ammodata.AmmoCont += count;
            OnAddAmmo?.Invoke(count, ammoName);
        }

        public void RemoveAmmo(string ammoName, int count = 1)
        {
            var ammodata = AmmoDatas.Find(ctg => ctg.AmmoName == ammoName);
            if (ammodata == null)
                return;
            ammodata.AmmoCont -= count;
            OnRemoveAmmo?.Invoke(count, ammoName);
        }
        
        public List<AmmoData> GetAmmoData()
        {
            return AmmoDatas;
        }
        
        public int GetAmmoCount(string ammoName)
        {
            return AmmoDatas.Find(ctg => ctg.AmmoName.ToLower() == ammoName.ToLower()).AmmoCont;
        }

        public int GetAllAmmo()
        {
            var ammo = 0;
            AmmoDatas.ForEach(ctg => ammo += ctg.AmmoCont);
            return ammo;
        }
    }
}
