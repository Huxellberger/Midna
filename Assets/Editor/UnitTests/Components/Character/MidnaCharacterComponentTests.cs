// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Test.Components.ActonStateMachine;
using Assets.Scripts.Test.Components.Character;
using Assets.Scripts.Test.Components.Input;
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

            TestableMonobehaviourFunctions<TestMidnaCharacterComponent>.AddTestableMonobehaviourComponent(
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

        private MockInputBinderComponent _mockInputBinderComponent;
        private MockInputComponent _mockInputComponent;
        private MockActionStateMachineComponent _mockActionStateMachineComponent;
    }
}
