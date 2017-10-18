// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using System.Collections.Generic;
using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Equipment
{
    public class MockEquipmentComponent 
        : MonoBehaviour
        , IEquipmentInterface
        , ITestableMonobehaviour
    {
        public IDictionary<EEquipmentSlot, EquipmentItemComponent> SetEquipmentItemInSlotResults { get; private set; }

        public void UseEquipmentInSlot(EEquipmentSlot inSlot)
        {
            throw new System.NotImplementedException();
        }

        public void StopUsingEquipmentInSlot(EEquipmentSlot inSlot)
        {
            throw new System.NotImplementedException();
        }

        public void SetEquipmentItemInSlot(EquipmentItemComponent inEquipmentItem, EEquipmentSlot inSlot)
        {
            SetEquipmentItemInSlotResults.Add(inSlot, inEquipmentItem);
        }

        public void PrepareForTest(params object[] parameters)
        {
            SetEquipmentItemInSlotResults = new Dictionary<EEquipmentSlot, EquipmentItemComponent>();
        }
    }
}

#endif // UNITY_EDITOR
