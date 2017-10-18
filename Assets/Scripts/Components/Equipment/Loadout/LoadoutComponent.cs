// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.Equipment.Loadout
{
    [RequireComponent(typeof(IEquipmentInterface))]
    public abstract class LoadoutComponent 
        : MonoBehaviour
    {

        protected void Start()
        {
            var equipmentInterface = GetComponent<IEquipmentInterface>();

            var primaryItem = GetPrimaryItem();
            var secondaryItem = GetSecondaryItem();

            equipmentInterface.SetEquipmentItemInSlot(primaryItem, EEquipmentSlot.PrimarySlot);
            equipmentInterface.SetEquipmentItemInSlot(secondaryItem, EEquipmentSlot.SecondarySlot);
        }

        protected abstract EquipmentItemComponent GetPrimaryItem();
        protected abstract EquipmentItemComponent GetSecondaryItem();
    }
}
