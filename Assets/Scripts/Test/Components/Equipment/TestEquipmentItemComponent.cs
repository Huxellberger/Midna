// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.Equipment
{
    public class TestEquipmentItemComponent 
        : EquipmentItemComponent
        , ITestableMonobehaviour
    {
        public bool UseItemCalled { get; private set; }
        public bool StopUsingItemCalled { get; private set; }

        protected override void OnUseItem()
        {
            UseItemCalled = true;
        }

        protected override void OnStopUsingItem()
        {
            StopUsingItemCalled = true;
        }

        public void PrepareForTest(params object[] parameters)
        {
            UseItemCalled = false;
            StopUsingItemCalled = false;
        }
    }
}
