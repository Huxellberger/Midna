// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Components.Spawn;
using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.Components.ActonStateMachine;
using Assets.Scripts.Test.Components.Character;
using Assets.Scripts.Test.Components.Controller;
using Assets.Scripts.Test.Components.Input;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.Character
{
    [TestFixture]
    public class MidnaCharacterComponentTestFixture
    {
        [SetUp]
        public void BeforeTest()
        {
            _mockInputComponent =
                TestableMonobehaviourFunctions<MockInputComponent>.PrepareMonobehaviourComponentForTest();

            MidnaGameMode.CurrentGameMode = _mockInputComponent.gameObject;

            _mockInputBinderComponent = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();

            _mockActionStateMachineComponent =
                TestableMonobehaviourFunctions<MockActionStateMachineComponent>.AddTestableMonobehaviourComponent(
                    _mockInputBinderComponent.gameObject);

            TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .AddTestableMonobehaviourComponent(_mockInputBinderComponent.gameObject);

            _characterComponent = TestableMonobehaviourFunctions<TestMidnaCharacterComponent>.AddTestableMonobehaviourComponent(
                _mockInputBinderComponent.gameObject);

        }

        [TearDown]
        public void AfterTest()
        {
            MidnaGameMode.CurrentGameMode = null;
        }

        [Test]
        public void Start_SetsInputInterfaceUsingGameModeObject()
        {
            Assert.AreEqual(_mockInputBinderComponent.InputInterface, _mockInputComponent);
        }

        [Test]
        public void Start_TransitionsCharacterIntoLocomotionActionState()
        {    
            Assert.NotNull((LocomotionActionState)_mockActionStateMachineComponent.RequestedState);
        }

        [Test]
        public void ReceivesTriggerSpawnMessage_UpdatesControllerInitialTransformToMatch()
        {
            var controller = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            _characterComponent.CurrentControllerComponent = controller;

            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(_characterComponent.gameObject, new TriggerSpawnUpdateMessage(controller.transform));
            Assert.AreEqual(controller.transform, controller.PawnInitialTransform);
        }

        private TestMidnaCharacterComponent _characterComponent;
        private MockInputBinderComponent _mockInputBinderComponent;
        private MockInputComponent _mockInputComponent;
        private MockActionStateMachineComponent _mockActionStateMachineComponent;
    }
}
