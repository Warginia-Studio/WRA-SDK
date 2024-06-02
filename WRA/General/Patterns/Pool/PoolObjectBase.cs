using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.General.Patterns.Pool
{
    public abstract class PoolObjectBase : MonoBehaviour, IKillable
    {
        public UnityEvent OnKillEvent;
        public UnityEvent OnSpawnEvent;
        public abstract void OnInit();
        public abstract void OnSpawn();
    
        public abstract void OnBeginKill(float delay);
    
        public abstract void OnKill();
        
        public void Spawn()
        {
            OnSpawn();
            SetActive(true);
        }
    
        public void Kill()
        {
            OnKill();
            SetActive(false);
            StopAllCoroutines();
            OnKillEvent?.Invoke();
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

        public virtual void Kill(KillInfo killInfo)
        {
            Kill();
        }
    }
}
