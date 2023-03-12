using System;
using System.Collections.Generic;
using System.Linq;
using DependentObjects.Classes.Slots;
using DependentObjects.Enums;
using DependentObjects.ScriptableObjects.Managment;
using UnityEngine;

namespace Managment
{
    public class Armament : Container<ArmamentSlot, ArmableItem>
    {
        [SerializeField] private List<ArmamentCategory> armamentBindSlots;

        private List<ArmamentSlot> armamentSlots = new List<ArmamentSlot>();

        private void Awake()
        {
            
        }

        public override bool TryAddItem(ArmableItem ArmableItem)
        {
            throw new System.NotImplementedException();
        }


        public override bool TryAddItemAtSlot(ArmableItem armable, int slotid)
        {
            if (CheckSlot(armable, slotid))
            {
                return false;
            }
        
            var item = Instantiate(armable);
            armamentSlots.Add(new ArmamentSlot(item, slotid));

            OnContainerChanged.Invoke();
            return true;
        }

        public override bool TryMoveItem(ArmableItem armable, int slotId)
        {
            if (!IsPossibleToMoveItem(armable, slotId))
            {
                return false;
            }
            
            armamentSlots.Find(ctg => ctg.Item == armable).SetNewSlotId(slotId);
            OnContainerChanged.Invoke();
            return true;
        }


        public override bool IsPossibleToAddItemAtSlot(ArmableItem armable, int slotId)
        {
            if (CheckSlot(armable, slotId))
            {
                return false;
            }

            return true;
        }

        public override bool IsPossibleToMoveItem(ArmableItem armable, int slotId)
        {
            if (CheckSlot(armable, slotId) )
            {
                return false;
            }

            return true;
        }


        public override bool TryRemoveItem(ArmableItem armable)
        {
            bool result = armamentSlots.Remove(armamentSlots.Find(ctg => ctg.Item == armable));

            OnContainerChanged.Invoke();
            return result;
        }

        public override ArmableItem[] GetItems()
        {
            var items = this.armamentSlots.Select(ctg => ctg.Item);
        

            return items.ToArray();
        }

        public override ArmamentSlot[] GetSlots()
        {
            return armamentSlots.ToArray();
        }

        protected override bool CheckSlot(ArmableItem armable, int slotId)
        {
            if (armable == null)
                return true;
            var foundSlot = armamentSlots.Find(ctg => ctg.SlotId == slotId);
            if (foundSlot != null)
                return true;
            if (armamentBindSlots.Count <= slotId)
                throw new Exception($"Out of range with slot id: {slotId} in class Armament");
            if (armamentBindSlots[slotId] != armable.ArmamentCategory)
                return true;
            
            return false;
        }
    }
}
