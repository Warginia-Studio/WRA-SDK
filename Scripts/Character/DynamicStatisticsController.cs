using System;
using System.Collections.Generic;
using DependentObjects.Classes.Statistics;
using UnityEngine;

namespace Character
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
