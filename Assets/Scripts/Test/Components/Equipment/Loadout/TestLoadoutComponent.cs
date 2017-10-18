// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Components.Equipment.Loadout;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.Equipment.Loadout
{
    public class TestLoadoutComponent 
        : LoadoutComponent
        , ITestableMonobehaviour
    {
        public EquipmentItemComponent GetPrimaryItemResult { get; set; }
        public EquipmentItemComponent GetSecondaryItemResult { get; set; }

        public void TestStart()
        {
            Start();
        }

        protected override EquipmentItemComponent GetPrimaryItem()
        {
            return GetPrimaryItemResult;
        }

        protected override EquipmentItemComponent GetSecondaryItem()
        {
            return GetSecondaryItemResult;
        }

        public void PrepareForTest(params object[] parameters)
        {
        }
    }
}

#endif // UNITY_EDITOR
