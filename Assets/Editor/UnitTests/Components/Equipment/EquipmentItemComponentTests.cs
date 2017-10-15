// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Components.Equipment;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.Equipment
{
    [TestFixture]
    public class EquipmentItemComponentTestFixture {

        [Test]
        public void UseItem_OnUseItemCalled()
        {
            var equipmentItem = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest();

            equipmentItem.UseItem();
            Assert.IsTrue(equipmentItem.UseItemCalled);
        }

        [Test]
        public void StopUsingItem_OnStopUsingItemCalled()
        {
            var equipmentItem = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest();

            equipmentItem.StopUsingItem();
            Assert.IsTrue(equipmentItem.StopUsingItemCalled);
        }
    }
}
