using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WRA.CharacterSystems.AmmoSystem
{
    public class AmmoControler : CharacterSystemBase
    {
        public UnityEvent OnAmmoChange;
    
        [SerializeField] private List<AmmoData> AmmoDatas;

        public void RemoveAmmo(string ammoName, int count = 1)
        {
            var ammodata = AmmoDatas.Find(ctg => ctg.AmmoName == ammoName);
            if (ammodata == null)
                return;
            ammodata.AmmoCont -= count;
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
