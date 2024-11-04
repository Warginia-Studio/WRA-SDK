using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

public interface IPoolObject
{
    public int VariantId { get; set; }
    public void OnInit();
    
    public void OnSpawn();
    
    public void OnBeginKill(float delay);
    
    public void OnKill();
    
    public void Spawn();

    public void Kill();
    
    public void Kill(float delay);
    
    public void SetActive(bool active);
    
    public void Kill(KillInfo killInfo);
}
