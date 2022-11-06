using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    string GetSaveData();

    void LoadFromData(string data);
}