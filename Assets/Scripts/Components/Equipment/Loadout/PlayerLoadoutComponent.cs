﻿// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.Equipment.Loadout
{
    public class PlayerLoadoutComponent 
        : LoadoutComponent
    {
        public GameObject PrimaryItemType;
        public GameObject SecondaryItemType;

        protected override EquipmentItemComponent GetPrimaryItem()
        {
            return InstantiateItemOfType(PrimaryItemType);
        }

        protected override EquipmentItemComponent GetSecondaryItem()
        {
            return InstantiateItemOfType(SecondaryItemType);
        }

        private EquipmentItemComponent InstantiateItemOfType(GameObject inItemType)
        {
            if (inItemType != null)
            {
                var item = Instantiate(inItemType);
                item.transform.parent = gameObject.transform;
                item.transform.position = gameObject.transform.position;

                return item.GetComponent<EquipmentItemComponent>();
            }

            return null;
        }
    }
}

