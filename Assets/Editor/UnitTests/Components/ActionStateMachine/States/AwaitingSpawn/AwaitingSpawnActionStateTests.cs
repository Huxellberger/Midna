// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.AwaitingSpawn;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Test.Components.ActonStateMachine;
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

            _state = new AwaitingSpawnActionState(new ActionStateInfo(_dispatcher.gameObject));
            _state.Start();
        }

        [TearDown]
        public void AfterTest()
        {
            _state.End();
            _dispatcher = null;
        }

        [Test]
        public void GetId_ReturnsAwaitingSpawn()
        {
            Assert.AreEqual(EActionStateId.AwaitingSpawn, _state.ActionStateId);
        }

        [Test]
        public void Update_FadeTimeNotPassed_DoesNotEnterLocomotion()
        {
            _state.Update(AwaitingSpawnActionState.FadeTime - 0.1f);

            Assert.Null((LocomotionActionState)_stateMachine.RequestedState);
        }

        [Test]
        public void Update_FadeTimePassed_EntersLocomotion()
        {
            _state.Update(AwaitingSpawnActionState.FadeTime + 0.1f);

            Assert.NotNull((LocomotionActionState)_stateMachine.RequestedState);
        }
    }
}
