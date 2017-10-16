// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Components.UnityEvent;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.Equipment.EquipmentItem;
using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.Components.Health;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.Equipment.EquipmentItem
{
    [TestFixture]
    public class CaneTestFixture
    {
        private TestCane _cane;
        private MockHealthComponent _healthComponent;

        [SetUp]
        public void BeforeTest()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<BoxCollider2D>();

            TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .AddTestableMonobehaviourComponent(gameObject);

            _cane = TestableMonobehaviourFunctions<TestCane>.AddTestableMonobehaviourComponent(gameObject);

            _healthComponent =
                TestableMonobehaviourFunctions<MockHealthComponent>.PrepareMonobehaviourComponentForTest();
        }

        [TearDown]
        public void AfterTest()
        {
            _healthComponent = null;

            _cane = null;
        }

        [Test]
        public void UseItem_FiresCaneActivatedMessage()
        {
            var eventCapture = new UnityTestMessageHandleResponseObject<CaneActivatedMessage>();
            var handle = UnityMessageEventFunctions.RegisterActionWithDispatcher<CaneActivatedMessage>(_cane.gameObject, eventCapture.OnResponse);

            _cane.UseItem();

            Assert.IsTrue(eventCapture.ActionCalled);

            UnityMessageEventFunctions.UnregisterActionWithDispatcher(_cane.gameObject, handle);
        }

        [Test]
        public void Collision_NotUsingItem_NoHealthChange()
        {
            _cane.TestCollide(_healthComponent.gameObject);

            Assert.IsNull(_healthComponent.AdjustHealthResult);
        }

        [Test]
        public void Collision_UsingItem_ReducesHealthByPokeDamage()
        {
            _cane.UseItem();

            _cane.TestCollide(_healthComponent.gameObject);

            Assert.AreEqual(_cane.PokeHealthChange, _healthComponent.AdjustHealthResult);
        }

        [Test]
        public void Collision_UsedItemBeforePokeDuration_ReducesHealthByPokeDamage()
        {
            _cane.UseItem();
            _cane.deltaTime = _cane.PokeDuration - 0.1f;
            _cane.TestUpdate();

            _cane.TestCollide(_healthComponent.gameObject);

            Assert.AreEqual(_cane.PokeHealthChange, _healthComponent.AdjustHealthResult);
        }

        [Test]
        public void Collision_UsedItemAfterPokeDuration_DoesNotReduceHealthByPokeDamage()
        {
            _cane.UseItem();
            _cane.deltaTime = _cane.PokeDuration + 0.1f;
            _cane.TestUpdate();

            _cane.TestCollide(_healthComponent.gameObject);

            Assert.IsNull(_healthComponent.AdjustHealthResult);
        }
    }
}
