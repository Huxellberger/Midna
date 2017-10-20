// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Components.Equipment;
using Assets.Scripts.Test.Components.Equipment.Loadout;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.Equipment.Loadout
{
    public class PlayerLoadoutComponentTestFixture
    {
        private TestPlayerLoadoutComponent _loadout;
        [SetUp]
        public void BeforeTest()
        {
            var loadoutGameObject = TestableMonobehaviourFunctions<MockEquipmentComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            _loadout = TestableMonobehaviourFunctions<TestPlayerLoadoutComponent>.AddTestableMonobehaviourComponent(
                loadoutGameObject);
        }

        [TearDown]
        public void AfterTest()
        {
            _loadout = null;
        }

        [Test]
        public void GetPrimaryItem_ReturnsPrimaryItemWithComponentAsParent()
        {
            _loadout.PrimaryItemType = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            Assert.AreSame(_loadout.gameObject.transform, _loadout.TestGetPrimary().gameObject.transform.parent);
        }

        [Test]
        public void GetPrimaryItem_ReturnsPrimaryItemWithComponentLocationSameAsOwner()
        {
            _loadout.PrimaryItemType = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            _loadout.gameObject.transform.position = Vector3.left;

            Assert.AreEqual(_loadout.gameObject.transform.position, _loadout.TestGetPrimary().gameObject.transform.position);
        }

        [Test]
        public void GetSecondaryItem_ReturnsPrimaryItemWithComponentAsParent()
        {
            _loadout.SecondaryItemType = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            Assert.AreSame(_loadout.gameObject.transform, _loadout.TestGetSecondary().gameObject.transform.parent);
        }

        [Test]
        public void GetSecondaryItem_ReturnsPrimaryItemWithComponentLocationSameAsOwner()
        {
            _loadout.SecondaryItemType = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            _loadout.gameObject.transform.position = Vector3.left;

            Assert.AreEqual(_loadout.gameObject.transform.position, _loadout.TestGetSecondary().gameObject.transform.position);
        }
    }
}
