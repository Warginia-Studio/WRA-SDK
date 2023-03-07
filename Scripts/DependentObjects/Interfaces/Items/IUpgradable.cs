using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable
{
    void Upgrade();

    (int, int) GetUpgradeLevels();

    bool IsPossibleToUpgrade();

    string GetUpgradeRequired();
}
