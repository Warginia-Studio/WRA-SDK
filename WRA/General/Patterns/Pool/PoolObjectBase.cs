using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.General.Patterns.Pool
{
    public abstract class PoolObjectBase : MonoBehaviour, IKillable, IPoolObject
    {
        public UnityEvent<IPoolObject> OnKillEvent;
        public UnityEvent<IPoolObject> OnSpawnEvent;
        
        public int VariantId
        {
            get => _variantId;
            set => _variantId = value;
        }

        [FormerlySerializedAs("VariantId")][SerializeField] private int _variantId = 0;
        public virtual void OnInit() {}
        public virtual void OnSpawn(){}
    
        public virtual void OnBeginKill(float delay) {}
    
        public virtual void OnKill() {}
        
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
            OnKillEvent?.Invoke(this);
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
