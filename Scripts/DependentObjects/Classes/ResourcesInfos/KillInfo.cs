using UnityEngine;

namespace DependentObjects.Classes
{
    public class KillInfo
    {
        public bool WillBeDead=true;
        public Transform Killer;
    
        public KillInfo(Transform killer)
        {
            Killer = killer;
        }
    }
}
