using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using WRA.CharacterSystems.InteractionsSystem;
using WRA.CharacterSystems.InventorySystem.Managment;
using WRA.CharacterSystems.StatisticsSystem;

public class CharacterSystemsProvider : MonoBehaviour
{
    public Inventory Inventory { get; }
    public StatisticsControler StatisticsControler { get; }
    public InteractionControllerBase InteractionControllerBase { get; }

    [SerializeField] private Inventory inventory;
    [FormerlySerializedAs("statisticsController")] [SerializeField] private StatisticsControler statisticsControler;
    [SerializeField] private InteractionControllerBase interactionControllerBase;
    
    private void Awake()
    {
        
    }
}
