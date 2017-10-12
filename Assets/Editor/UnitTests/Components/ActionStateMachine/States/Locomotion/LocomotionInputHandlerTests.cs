// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.Input;
using Assets.Scripts.Components.MidnaMovement;
using NUnit.Framework;
using NSubstitute;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Locomotion
{
    [TestFixture]
    public class LocomotionInputHandlerTestFixture {

        [Test]
        public void OnHorizontalAnalog_MovementInterfaceExists_Handled()
        {
            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleAnalogInput(EInputKey.HorizontalAnalog, 1.0f));
        }

        [Test]
        public void OnHorizontalAnalog_MovementInterfaceExists_AddsHorizontalImpulseOfAnalogValue()
        {
            const float expectedAnalogValue = 0.5f;

            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            locomotionInputHandler.HandleAnalogInput(EInputKey.HorizontalAnalog, expectedAnalogValue);

            mockMidnaMovementInterface.Received().AddHorizontalImpulse(Arg.Is(expectedAnalogValue));
        }

        [Test]
        public void OnHorizontalAnalog_MovementInterfaceNull_Unhandled()
        {
            const IMidnaMovementInterface mockMidnaMovementInterface = null;
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleAnalogInput(EInputKey.HorizontalAnalog, 1.0f));
        }

        [Test]
        public void OnVerticalAnalog_MovementInterfaceExists_Handled()
        {
            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleAnalogInput(EInputKey.VerticalAnalog, 1.0f));
        }

        [Test]
        public void OnVerticalAnalog_MovementInterfaceExists_AddsVeticalImpulseOfAnalogValue()
        {
            const float expectedAnalogValue = 0.5f;

            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            locomotionInputHandler.HandleAnalogInput(EInputKey.VerticalAnalog, expectedAnalogValue);

            mockMidnaMovementInterface.Received().AddVerticalImpulse(Arg.Is(expectedAnalogValue));
        }

        [Test]
        public void OnVerticalAnalog_MovementInterfaceNull_Unhandled()
        {
            const IMidnaMovementInterface mockMidnaMovementInterface = null;
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleAnalogInput(EInputKey.VerticalAnalog, 1.0f));
        }

        [Test]
        public void OnSprintButton_MovementInterfaceNull_Unhandled()
        {
            const IMidnaMovementInterface mockMidnaMovementInterface = null;
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleButtonInput(EInputKey.SprintButton, true));
        }

        [Test]
        public void OnSprintButton_MovementInterfaceExists_Handled()
        {
            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleButtonInput(EInputKey.SprintButton, true));
        }

        [Test]
        public void OnSprintButton_MovementInterfaceExists_CallsToggleSprintWithInputValue()
        {
            const bool expectedSprint = true;

            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface);

            locomotionInputHandler.HandleButtonInput(EInputKey.SprintButton, expectedSprint);

            mockMidnaMovementInterface.Received().ToggleSprint(Arg.Is(expectedSprint));
        }
    }
}
