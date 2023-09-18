using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public string SceneName { get; set; }
    
    public List<SimpleObject> AllObjects { get; set; } = new List<SimpleObject>();
}

public class SimpleObject
{
    public Type Type { get; set; }
    public object ObjectData { get; set; }
}
