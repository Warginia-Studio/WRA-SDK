using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

public interface IPoolObject
{
    public int VariantId { get; set; }
    public abstract void OnInit();
    
    public abstract void OnSpawn();
    
    public abstract void OnBeginKill(float delay);
    
    public abstract void OnKill();
    
    public void Spawn();

    public void Kill();
    
    public void Kill(float delay);
    
    public void SetActive(bool active);
    
    public void Kill(KillInfo killInfo);
}
