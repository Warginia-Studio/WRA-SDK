using DependentObjects.Enums;
using UnityEngine;

namespace Utility
{
    public class EnumedLayer : MonoBehaviour
    {
        public EnumedLayers Layer => layer;
        [SerializeField] private EnumedLayers layer;
    
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("EnumLayer");
        }

    }
}
