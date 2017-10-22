// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

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
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider2D;
        private MockHealthComponent _healthComponent;

        [SetUp]
        public void BeforeTest()
        {
            var gameObject = new GameObject();
            _collider2D = gameObject.AddComponent<BoxCollider2D>();
            _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

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
            _spriteRenderer = null;
        }

        [Test]
        public void Start_SpriteDisabled()
        {
            Assert.IsFalse(_spriteRenderer.enabled);
        }

        [Test]
        public void Start_ColliderDisabled()
        {
            Assert.IsFalse(_collider2D.enabled);
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
        public void UseItem_SpriteEnabled()
        {
            _cane.UseItem();

            Assert.IsTrue(_spriteRenderer.enabled);
        }

        [Test]
        public void UseItem_ColliderEnabled()
        {
            _cane.UseItem();

            Assert.IsTrue(_collider2D.enabled);
        }

        [Test]
        public void UseItem_TimesOut_SpriteDisabled()
        {
            _cane.UseItem();

            _cane.deltaTime = _cane.PokeDuration + 0.1f;
            _cane.TestUpdate();

            Assert.IsFalse(_spriteRenderer.enabled);
        }

        [Test]
        public void UseItem_TimesOut_ColliderDisabled()
        {
            _cane.UseItem();

            _cane.deltaTime = _cane.PokeDuration + 0.1f;
            _cane.TestUpdate();

            Assert.IsFalse(_collider2D.enabled);
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

        [Test]
        public void Collision_OwnerCollides_DoesNotReduceHealthByPokeDamage()
        {
            _cane.UseItem();
            _cane.Owner = _healthComponent.gameObject;

            _cane.TestCollide(_healthComponent.gameObject);

            Assert.IsNull(_healthComponent.AdjustHealthResult);
        }
    }
}

#endif
