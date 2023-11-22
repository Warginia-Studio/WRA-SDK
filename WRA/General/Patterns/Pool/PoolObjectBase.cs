using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.General.Patterns;

public abstract class PoolObjectBase : MonoBehaviour
{
    public abstract void OnInit();
    public abstract void OnSpawn();
    
    public abstract void OnBeginKill(float delay);
    
    public abstract void OnKill();
    
    public void Kill()
    {
        OnKill();
        SetActive(false);
        StopAllCoroutines();
    }

    public void Kill(float delay)
    {
        OnBeginKill(delay);
        StartCoroutine(KillDelay(delay));
    }

    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    private IEnumerator KillDelay(float delay)
    {
        float time = 0;
        while (time < delay)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Kill();
    }
}
