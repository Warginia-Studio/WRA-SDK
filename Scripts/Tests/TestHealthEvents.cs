using Character;
using DependentObjects.Classes;
using UnityEngine;

namespace Tests
{
    public class TestHealthEvents : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;

        private void Awake()
        {
            healthController.OnBeforeDamage.AddListener(OnDmg);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DamageInfo damageInfo = new DamageInfo();
                damageInfo.PhysicalDamage = 100;
                healthController.DealDamage(damageInfo);
            }
        }

        private void OnDmg(DamageInfo dmg)
        {
            dmg.PhysicalDamage = 0;
        }
    }
}
