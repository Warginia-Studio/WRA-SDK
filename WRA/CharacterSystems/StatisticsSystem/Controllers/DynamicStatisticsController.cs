using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public class DynamicStatisticsController : MonoBehaviour
    {
        [SerializeField] private List<DynamicStatisticValue> baseStatistics;

        private void Awake()
        {
            for (int i = 0; i < baseStatistics.Count; i++)
            {
                Debug.Log(baseStatistics[i].GetStatisticInString());
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
