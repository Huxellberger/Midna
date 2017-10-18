// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Test.Components.Equipment;
using Assets.Scripts.Test.Components.Equipment.Loadout;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.Equipment.Loadout
{
    public class LoadoutComponentTestFixture
    {
        [Test]
        public void Start_AssignsCorrectItemsToSlots()
        {
            var equipmentInterface = TestableMonobehaviourFunctions<MockEquipmentComponent>
                .PrepareMonobehaviourComponentForTest();

            var loadoutComponent =
                TestableMonobehaviourFunctions<TestLoadoutComponent>.AddTestableMonobehaviourComponent(
                    equipmentInterface.gameObject);

            var primaryEquipmentItem = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest();

            var secondaryEquipmentItem = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest();

            loadoutComponent.GetPrimaryItemResult = primaryEquipmentItem;
            loadoutComponent.GetSecondaryItemResult = secondaryEquipmentItem;

            loadoutComponent.TestStart();

            Assert.AreSame(primaryEquipmentItem, equipmentInterface.SetEquipmentItemInSlotResults[EEquipmentSlot.PrimarySlot]);
            Assert.AreEqual(secondaryEquipmentItem, equipmentInterface.SetEquipmentItemInSlotResults[EEquipmentSlot.SecondarySlot]);
        }
    }
}
