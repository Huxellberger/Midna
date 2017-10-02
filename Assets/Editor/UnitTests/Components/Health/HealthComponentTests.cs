// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Test.Components.ActonStateMachine;
using Assets.Scripts.Test.Components.Health;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.Health
{
    [TestFixture]
    public class HealthComponentTestFixture
    {
        [SetUp]
        public void BeforeTest()
        {
            _healthComponent =
                TestableMonobehaviourFunctions<TestHealthComponent>.PrepareMonobehaviourComponentForTest();

            _actionStateMachineComponent = TestableMonobehaviourFunctions<MockActionStateMachineComponent>
                .AddTestableMonobehaviourComponent(_healthComponent.gameObject);
        }

        [TearDown]
        public void AfterTest()
        {
            _actionStateMachineComponent = null;
            _healthComponent = null;
        }

        [Test]
        public void Start_DefaultMaxHealthGreaterThanZero()
        {
            Assert.Greater(_healthComponent.GetMaxHealth(), 0);
        }

        [Test]
        public void Start_HasMaxHealth()
        {
            Assert.AreEqual(_healthComponent.GetCurrentHealth(), _healthComponent.GetMaxHealth());
        }

        [Test]
        public void AdjustHealth_ClampedToMax()
        {
            _healthComponent.AdjustHealth(100);
            Assert.AreEqual(_healthComponent.GetCurrentHealth(), _healthComponent.GetMaxHealth());
        }

        [Test]
        public void AdjustHealth_ChangesHealth()
        {
            var expectedHealthChange = _healthComponent.GetCurrentHealth() / 2;

            _healthComponent.AdjustHealth(-expectedHealthChange);

            Assert.AreEqual(_healthComponent.GetMaxHealth() - expectedHealthChange, _healthComponent.GetCurrentHealth());
        }

        [Test]
        public void AdjustHealth_HealthChangeDisabled_NoEffect()
        {
            _healthComponent.SetHealthChangedEnabled(false);

            _healthComponent.AdjustHealth(-1 *(_healthComponent.GetCurrentHealth() / 2));

            Assert.AreEqual(_healthComponent.GetMaxHealth(), _healthComponent.GetCurrentHealth());
        }

        [Test]
        public void AdjustHealth_ReachesZero_EntersDeadActionState()
        {
            _healthComponent.AdjustHealth(_healthComponent.GetMaxHealth() * -1);

            Assert.NotNull((DeadActionState)_actionStateMachineComponent.RequestedState);
        }

        [Test]
        public void ReplenishHealth_SetsToMax()
        {
            _healthComponent.AdjustHealth(-1 * (_healthComponent.GetCurrentHealth() / 2));
            _healthComponent.ReplenishHealth();

            Assert.AreEqual(_healthComponent.GetMaxHealth(), _healthComponent.GetCurrentHealth());
        }

        [Test]
        public void ReplenishHealth_HealthChangeDisabled_NoEffect()
        {
            _healthComponent.SetHealthChangedEnabled(false);
            _healthComponent.AdjustHealth(-1 * (_healthComponent.GetCurrentHealth() / 2));
            _healthComponent.ReplenishHealth();

            Assert.AreEqual(_healthComponent.GetMaxHealth(), _healthComponent.GetCurrentHealth());
        }

        private TestHealthComponent _healthComponent;
        private MockActionStateMachineComponent _actionStateMachineComponent;
    }
}
