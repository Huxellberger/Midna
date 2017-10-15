// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.Equipment
{
    public interface IEquipmentInterface
    {
        void UseEquipmentInSlot(EEquipmentSlot inSlot);
        void StopUsingEquipmentInSlot(EEquipmentSlot inSlot);
        void SetEquipmentItemInSlot(EquipmentItemComponent inEquipmentItem, EEquipmentSlot inSlot);
    }
}
