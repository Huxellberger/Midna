// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Equipment
{
    public class EquipmentComponent
        : MonoBehaviour
        , IEquipmentInterface
    {
        private IDictionary<EEquipmentSlot, EquipmentItemComponent> ItemSlots { get; set; }

        protected void Start()
        {
            ItemSlots = new Dictionary<EEquipmentSlot, EquipmentItemComponent>();
        }

        // IEquipmentInterface
        public void UseEquipmentInSlot(EEquipmentSlot inSlot)
        {
            if (ItemSlots.ContainsKey(inSlot))
            {
                ItemSlots[inSlot].UseItem();
            }
        }

        public void StopUsingEquipmentInSlot(EEquipmentSlot inSlot)
        {
            if (ItemSlots.ContainsKey(inSlot))
            {
                ItemSlots[inSlot].StopUsingItem();
            }
        }

        public void SetEquipmentItemInSlot(EquipmentItemComponent inEquipmentItem, EEquipmentSlot inSlot)
        {
            if (inEquipmentItem != null)
            {
                ItemSlots.Remove(inSlot);
                ItemSlots.Add(inSlot, inEquipmentItem);
            }
        }
        // ~IEquipmentInterface
    }
}
