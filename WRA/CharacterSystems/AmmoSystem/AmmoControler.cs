using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoControler : CharacterSystemBase
{
    [SerializeField] private List<AmmoData> AmmoDatas;

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
