using System;
using System.Collections.Generic;
using DependentObjects.Classes.Slots;
using DependentObjects.Enums;
using DependentObjects.ScriptableObjects.Managment;
using UnityEngine;

namespace Managment
{
    public class Armament : Container<ArmamentSlot, ArmableItem>
    {
        [SerializeField] private List<ArmamentCategory> armamentBindSlots;

        private List<ArmamentSlot> armamentSlots; 

        public override bool TryAddItem(ArmableItem ArmableItem)
        {
            throw new System.NotImplementedException();
        }


        public override bool TryAddItemAtSlot(ArmableItem armable, int position)
        {
            if (!CheckSlot(armable, position))
                return false;
        
            OnContainerChanged.Invoke();
            return true;
        }

        public override bool TryMoveItem(ArmableItem armable, int slotId)
        {
            throw new System.NotImplementedException();
        }


        public override bool IsPossibleToAddItemAtSlot(ArmableItem armable, int slotId)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsPossibleToMoveItem(ArmableItem armable, int slotId)
        {
            throw new System.NotImplementedException();
        }


        public override bool TryRemoveItem(ArmableItem armable)
        {
            throw new System.NotImplementedException();
        }

        public override ArmableItem[] GetItems()
        {
            throw new System.NotImplementedException();
        }

        public override ArmamentSlot[] GetSlots()
        {
            return armamentSlots.ToArray();
        }

        protected override bool CheckSlot(ArmableItem armable, int slotId)
        {
            if (armable == null)
                return false;
            var foundSlot = armamentSlots.Find(ctg => ctg.SlotId == slotId);
            if (foundSlot != null)
                return false;
            if (armamentBindSlots.Count <= slotId)
                throw new Exception($"Out of range with slot id: {slotId} in class Armament");
            if (armamentBindSlots[slotId] != armable.ArmamentCategory)
                return false;
        
            armamentSlots.Add(new ArmamentSlot(Instantiate(armable), slotId));
        
            return true;
        }
    }
}
