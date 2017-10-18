// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Components.Equipment;
using Assets.Scripts.Test.Components.Equipment.Loadout;
using NUnit.Framework;

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
        public void GetSecondaryItem_ReturnsPrimaryItemWithComponentAsParent()
        {
            _loadout.SecondaryItemType = TestableMonobehaviourFunctions<TestEquipmentItemComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            Assert.AreSame(_loadout.gameObject.transform, _loadout.TestGetSecondary().gameObject.transform.parent);
        }
    }
}
