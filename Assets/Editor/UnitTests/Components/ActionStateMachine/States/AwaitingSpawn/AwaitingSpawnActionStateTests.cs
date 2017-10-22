// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.AwaitingSpawn;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Test.Components.ActonStateMachine;
using Assets.Scripts.Test.Components.Health;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.AwaitingSpawn
{
    [TestFixture]
    public class AwaitingSpawnActionStateTestFixture
    {
        private AwaitingSpawnActionState _state;
        private TestUnityMessageEventDispatcherComponent _dispatcher;
        private MockActionStateMachineComponent _stateMachine;
        private MockHealthComponent _healthComponent;

        [SetUp]
        public void BeforeTest()
        {
            _dispatcher = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            _stateMachine =
                TestableMonobehaviourFunctions<MockActionStateMachineComponent>.AddTestableMonobehaviourComponent
                (
                    _dispatcher.gameObject
                );

            _healthComponent =
                TestableMonobehaviourFunctions<MockHealthComponent>.AddTestableMonobehaviourComponent
                (
                    _dispatcher.gameObject
                );

            _state = new AwaitingSpawnActionState(new ActionStateInfo(_dispatcher.gameObject));

        }

        [TearDown]
        public void AfterTest()
        {
            _state = null;

            _healthComponent = null;
            _stateMachine = null;
            _dispatcher = null;
        }

        [Test]
        public void GetId_ReturnsAwaitingSpawn()
        {
            Assert.AreEqual(EActionStateId.AwaitingSpawn, _state.ActionStateId);
        }

        [Test]
        public void Start_DisablesHealthChanges()
        {
            _state.Start();

            Assert.IsTrue(_healthComponent.SetHealthChangeEnabledResult.HasValue);
            Assert.IsFalse(_healthComponent.SetHealthChangeEnabledResult.Value);

            _state.End();
        }

        [Test]
        public void End_EnablesHealthChanges()
        {
            _state.Start();
            _state.End();

            Assert.IsTrue(_healthComponent.SetHealthChangeEnabledResult.HasValue);
            Assert.IsTrue(_healthComponent.SetHealthChangeEnabledResult.Value);
        }

        [Test]
        public void Update_FadeTimeNotPassed_DoesNotEnterLocomotion()
        {
            _state.Start();
            _state.Update(AwaitingSpawnActionState.FadeTime - 0.1f);

            Assert.Null((LocomotionActionState)_stateMachine.RequestedState);

            _state.End();
        }

        [Test]
        public void Update_FadeTimePassed_EntersLocomotion()
        {
            _state.Start();

            _state.Update(AwaitingSpawnActionState.FadeTime + 0.1f);

            Assert.NotNull((LocomotionActionState)_stateMachine.RequestedState);

            _state.End();
        }
    }
}

#endif
