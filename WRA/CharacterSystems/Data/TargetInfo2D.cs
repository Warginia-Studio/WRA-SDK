using System.Diagnostics.Contracts;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using Transform = WRA.CharacterSystems.Transform;

namespace Character.Bullet
{
    public class TargetInfo2D : InfoBase
    {
        public LayerMask EnemyLayer { get; set; }
        
        public Transform Owner { get; set; }

        public Collider2D ColliderTarget { get; set; }
        private Vector3 TargetPosition { get; set; }
        private bool IsDummyTarget { get; set; }
        
        public TargetInfo2D(Transform owner, Collider2D colliderTarget, LayerMask enemyLayer, bool isDummyTarget = false) : base(owner, null)
        {
            Owner = owner;
            Target = colliderTarget.gameObject.transform;
            ColliderTarget = colliderTarget;
            EnemyLayer = enemyLayer;
            IsDummyTarget = isDummyTarget;
        }
        
        public void SetDummyTarget(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }
        
        public Vector3 GetTargetPosition(Vector3 from)
        {
            return IsTargetReallyNull() ? TargetPosition : ColliderTarget.ClosestPoint(from);
        }

        public bool IsTargetNull()
        {
            if (IsDummyTarget)
            {
                return false;
            }
            return ColliderTarget == null;
        }

        private bool IsTargetReallyNull()
        {
            return ColliderTarget == null;
        }
    }
}
