using UnityEngine;

namespace Physics.Lifting
{
    public class Liftable : MonoBehaviour
    {
        [SerializeField] private Transform liftingParrent;
    
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Lift");
        }

        public void BeginLift(Transform lift)
        {
            liftingParrent.parent = lift;
        }

        public void EndLift()
        {
            liftingParrent.parent = null;
        }
    }
}
