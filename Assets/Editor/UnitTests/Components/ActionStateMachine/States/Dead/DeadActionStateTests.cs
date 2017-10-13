// Copyright Threetee Gang (C) 2017

using System.Linq;
using Assets.Editor.UnitTests.Components.UnityEvent;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.Components.ActonStateMachine;
using Assets.Scripts.Test.Components.Character;
using Assets.Scripts.Test.Components.Controller;
using Assets.Scripts.Test.Components.Input;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Dead
{
    [TestFixture]
    public class DeadActionStateTestFixture
    {
        private GameObject _gameMode;
        private GameObject _owner;
        private GameObject _controller;
        private MockActionStateMachineComponent _stateMachine;

        [SetUp]
        public void BeforeTest()
        {
            _gameMode = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;
            MidnaGameMode.CurrentGameMode = _gameMode;

            _owner = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            _controller = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;
            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>.AddTestableMonobehaviourComponent(_controller);

            TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>.AddTestableMonobehaviourComponent(_owner);
            _stateMachine = TestableMonobehaviourFunctions<MockActionStateMachineComponent>.AddTestableMonobehaviourComponent(_owner);

            var characterComponent =
                TestableMonobehaviourFunctions<TestMidnaCharacterComponent>.AddTestableMonobehaviourComponent(_owner);
            characterComponent.CurrentControllerComponent = controllerComponent;
        }

        [TearDown]
        public void AfterTest()
        {
            _stateMachine = null;
            _controller = null;
            _owner = null;

            MidnaGameMode.CurrentGameMode = null;
            _gameMode = null;
        }

        private void CompleteActionStateConditions(DeadActionState inDeadActionState)
        {
            inDeadActionState.Update(inDeadActionState.DeathDelay + 0.1f);
            _owner.GetComponent<MockInputBinderComponent>().RegisteredHandler
                .HandleButtonInput(inDeadActionState.AcceptableInputs.First(), true);
            inDeadActionState.Update(0.1f);
            inDeadActionState.Update(inDeadActionState.FadeDelay + 0.1f);
        }

        [Test]
        public void GetActionStateId_Dead()
        {
            var deadActionState = new DeadActionState(new ActionStateInfo());

            Assert.AreEqual(EActionStateId.Dead, deadActionState.ActionStateId);
        }

        [Test]
        public void Start_EnterDeadActionStateMessageFired()
        {
            var messageCapture = new UnityTestMessageHandleResponseObject<EnteredDeadActionStateMessage>();
            var handle = UnityMessageEventFunctions.
                RegisterActionWithDispatcher<EnteredDeadActionStateMessage>(_owner, messageCapture.OnResponse);
            var deadActionState = new DeadActionState(new ActionStateInfo(_owner));

            deadActionState.Start();

            Assert.IsTrue(messageCapture.ActionCalled);

            UnityMessageEventFunctions.UnregisterActionWithDispatcher(_owner, handle);
        }

        [Test]
        public void Update_NoButtonPressedAfterDelayComplete_NoRespawnRequestSubmitted()
        {
            var messageCapture = new UnityTestMessageHandleResponseObject<RequestRespawnMessage>();
            var handle = UnityMessageEventFunctions.
                RegisterActionWithDispatcher<RequestRespawnMessage>(_gameMode, messageCapture.OnResponse);
            var deadActionState = new DeadActionState(new ActionStateInfo(_owner));

            deadActionState.Start();
            deadActionState.Update(deadActionState.DeathDelay + 0.1f);

            Assert.IsFalse(messageCapture.ActionCalled);

            UnityMessageEventFunctions.UnregisterActionWithDispatcher(_gameMode, handle);
        }

        [Test]
        public void Update_DoesNotWaitFullCameraDelay_NoRespawnRequestSubmitted()
        {
            var messageCapture = new UnityTestMessageHandleResponseObject<RequestRespawnMessage>();
            var handle = UnityMessageEventFunctions.
                RegisterActionWithDispatcher<RequestRespawnMessage>(_gameMode, messageCapture.OnResponse);
            var deadActionState = new DeadActionState(new ActionStateInfo(_owner));

            deadActionState.Start();
            deadActionState.Update(deadActionState.DeathDelay + 0.1f);
            _owner.GetComponent<MockInputBinderComponent>().RegisteredHandler
                .HandleButtonInput(deadActionState.AcceptableInputs.First(), true);
            deadActionState.Update(deadActionState.FadeDelay - 0.1f);

            Assert.IsFalse(messageCapture.ActionCalled);

            UnityMessageEventFunctions.UnregisterActionWithDispatcher(_gameMode, handle);
        }

        [Test]
        public void Update_ConditionsComplete_RespawnRequestSubmitted()
        {
            var messageCapture = new UnityTestMessageHandleResponseObject<RequestRespawnMessage>();
            var handle = UnityMessageEventFunctions.
                RegisterActionWithDispatcher<RequestRespawnMessage>(_gameMode, messageCapture.OnResponse);
            var deadActionState = new DeadActionState(new ActionStateInfo(_owner));

            deadActionState.Start();
            CompleteActionStateConditions(deadActionState);

            Assert.IsTrue(messageCapture.ActionCalled);

            UnityMessageEventFunctions.UnregisterActionWithDispatcher(_gameMode, handle);
        }

        [Test]
        public void Update_ConditionsComplete_TransitionsIntoNullActionState()
        {
            var deadActionState = new DeadActionState(new ActionStateInfo(_owner));

            deadActionState.Start();
            CompleteActionStateConditions(deadActionState);

            Assert.AreEqual(_stateMachine.RequestedState.ActionStateId, EActionStateId.Null);
        }

        [Test]
        public void End_LeftDeadActionStateMessageFired()
        {
            var messageCapture = new UnityTestMessageHandleResponseObject<LeftDeadActionStateMessage>();
            var handle = UnityMessageEventFunctions.
                RegisterActionWithDispatcher<LeftDeadActionStateMessage>(_owner, messageCapture.OnResponse);
            var deadActionState = new DeadActionState(new ActionStateInfo(_owner));

            deadActionState.Start();
            Assert.IsFalse(messageCapture.ActionCalled);

            deadActionState.End();
            Assert.IsTrue(messageCapture.ActionCalled);

            UnityMessageEventFunctions.UnregisterActionWithDispatcher(_owner, handle);
        }
    }
}
