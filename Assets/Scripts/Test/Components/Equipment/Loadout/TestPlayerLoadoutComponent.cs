// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Components.Equipment.Loadout;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.Equipment.Loadout
{
    public class TestPlayerLoadoutComponent 
        : PlayerLoadoutComponent
        , ITestableMonobehaviour
    {
        public EquipmentItemComponent TestGetPrimary()
        {
            return GetPrimaryItem();
        }

        public EquipmentItemComponent TestGetSecondary()
        {
            return GetSecondaryItem();
        }

        public void PrepareForTest(params object[] parameters)
        {
        }
    }
}

#endif // UNITY_EDITOR
