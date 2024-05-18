using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadingStatus
{
    bool IsReady();
    float GetProgress();
    
    void StartScene();
}
