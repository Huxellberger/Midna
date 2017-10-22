// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Test.Components.Equipment;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.Equipment
{
    [TestFixture]
    public class EquipmentComponentTestFixture
    {
        private TestEquipmentComponent _equipmentComponent;
        private TestEquipmentItemComponent _primaryItem;
        private TestEquipmentItemComponent _secondaryItem;

        [SetUp]
        public void BeforeTest()
        {
            var gameObject = new GameObject();
            _equipmentComponent = TestableMonobehaviourFunctions<TestEquipmentComponent>
                .PrepareMonobehaviourComponentForTest();

            _primaryItem = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest();

            _secondaryItem = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest();
        }

        [TearDown]
        public void AfterTest()
        {
            _secondaryItem = null;
            _primaryItem = null;

            _equipmentComponent = null;
        }

        [Test]
        public void UseEquipmentInSlot_NoItem_DoesNotUse()
        {
            _equipmentComponent.UseEquipmentInSlot(EEquipmentSlot.PrimarySlot);
        }

        [Test]
        public void UseEquipmentInSlot_Item_UsesCorrectItem()
        {
            _equipmentComponent.SetEquipmentItemInSlot(_primaryItem, EEquipmentSlot.PrimarySlot);
            _equipmentComponent.SetEquipmentItemInSlot(_secondaryItem, EEquipmentSlot.SecondarySlot);

            _equipmentComponent.UseEquipmentInSlot(EEquipmentSlot.PrimarySlot);

            Assert.IsTrue(_primaryItem.UseItemCalled);
            Assert.IsFalse(_secondaryItem.UseItemCalled);
        }

        [Test]
        public void StopUsingEquipmentInSlot_NoItem_DoesNotStopUsing()
        {
            _equipmentComponent.StopUsingEquipmentInSlot(EEquipmentSlot.PrimarySlot);
        }

        [Test]
        public void StopUsingEquipmentInSlot_Item_StopsUsingCorrectItem()
        {
            _equipmentComponent.SetEquipmentItemInSlot(_primaryItem, EEquipmentSlot.PrimarySlot);
            _equipmentComponent.SetEquipmentItemInSlot(_secondaryItem, EEquipmentSlot.SecondarySlot);

            _equipmentComponent.StopUsingEquipmentInSlot(EEquipmentSlot.PrimarySlot);

            Assert.IsTrue(_primaryItem.StopUsingItemCalled);
            Assert.IsFalse(_secondaryItem.StopUsingItemCalled);
        }

        [Test]
        public void SetEquipmentItemInSlot_OwnerIsEquipmentComponentGameObject()
        {
            _equipmentComponent.SetEquipmentItemInSlot(_primaryItem, EEquipmentSlot.PrimarySlot);

            Assert.AreSame(_equipmentComponent.gameObject, _primaryItem.Owner);
        }

        [Test]
        public void SetEquipmentItemInSlot_OldItemNoLongerHasEquipmentComponentGameObjectAsOwner()
        {
            _equipmentComponent.SetEquipmentItemInSlot(_primaryItem, EEquipmentSlot.PrimarySlot);
            _equipmentComponent.SetEquipmentItemInSlot(_secondaryItem, EEquipmentSlot.PrimarySlot);

            Assert.IsNull(_primaryItem.Owner);
        }
    }
}

#endif
