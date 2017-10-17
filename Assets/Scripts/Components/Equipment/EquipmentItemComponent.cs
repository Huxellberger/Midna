// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.Equipment
{
    public abstract class EquipmentItemComponent 
        : MonoBehaviour
    {
        public GameObject Owner { get; set; }
        public void UseItem()
        {
            OnUseItem();
        }

        public void StopUsingItem()
        {
            OnStopUsingItem();
        }

        protected abstract void OnUseItem();
        protected abstract void OnStopUsingItem();
    }
}
