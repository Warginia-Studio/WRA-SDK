using UnityEngine;

namespace WRA.PlayerSystems.SaveSystem
{
    public class SLObserver : MonoBehaviour
    {
        private void Awake()
        {
            SaveLoadManager.AddSLObserver(this);
        }

        private void OnDestroy()
        {
            SaveLoadManager.RemoveSLObserver(this);
        }

        public void GetData()
        {
        
        }

        public void SetData()
        {
        
        }
    }
}
