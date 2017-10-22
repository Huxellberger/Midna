// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.Equipment;
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
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleAnalogInput(EInputKey.HorizontalAnalog, 1.0f));
        }

        [Test]
        public void OnHorizontalAnalog_MovementInterfaceExists_AddsHorizontalImpulseOfAnalogValue()
        {
            const float expectedAnalogValue = 0.5f;

            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            locomotionInputHandler.HandleAnalogInput(EInputKey.HorizontalAnalog, expectedAnalogValue);

            mockMidnaMovementInterface.Received().AddHorizontalImpulse(Arg.Is(expectedAnalogValue));
        }

        [Test]
        public void OnHorizontalAnalog_MovementInterfaceNull_Unhandled()
        {
            const IMidnaMovementInterface mockMidnaMovementInterface = null;
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleAnalogInput(EInputKey.HorizontalAnalog, 1.0f));
        }

        [Test]
        public void OnVerticalAnalog_MovementInterfaceExists_Handled()
        {
            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleAnalogInput(EInputKey.VerticalAnalog, 1.0f));
        }

        [Test]
        public void OnVerticalAnalog_MovementInterfaceExists_AddsVeticalImpulseOfAnalogValue()
        {
            const float expectedAnalogValue = 0.5f;

            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            locomotionInputHandler.HandleAnalogInput(EInputKey.VerticalAnalog, expectedAnalogValue);

            mockMidnaMovementInterface.Received().AddVerticalImpulse(Arg.Is(expectedAnalogValue));
        }

        [Test]
        public void OnVerticalAnalog_MovementInterfaceNull_Unhandled()
        {
            const IMidnaMovementInterface mockMidnaMovementInterface = null;
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleAnalogInput(EInputKey.VerticalAnalog, 1.0f));
        }

        [Test]
        public void OnSprintButton_MovementInterfaceNull_Unhandled()
        {
            const IMidnaMovementInterface mockMidnaMovementInterface = null;
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleButtonInput(EInputKey.SprintButton, true));
        }

        [Test]
        public void OnSprintButton_MovementInterfaceExists_Handled()
        {
            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleButtonInput(EInputKey.SprintButton, true));
        }

        [Test]
        public void OnSprintButton_MovementInterfaceExists_CallsToggleSprintWithInputValue()
        {
            const bool expectedSprint = true;

            var mockMidnaMovementInterface = Substitute.For<IMidnaMovementInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(mockMidnaMovementInterface, null);

            locomotionInputHandler.HandleButtonInput(EInputKey.SprintButton, expectedSprint);

            mockMidnaMovementInterface.Received().ToggleSprint(Arg.Is(expectedSprint));
        }

        [Test]
        public void OnUsePrimaryEquipmentButton_EquipmentInterfaceNull_Unhandled()
        {
            var locomotionInputHandler = new LocomotionInputHandler(null, null);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleButtonInput(EInputKey.UsePrimaryEquipment, true));
        }

        [Test]
        public void OnUsePrimaryEquipmentButton_EquipmentInterfaceExists_Handled()
        {
            var mockEquipmentInterface = Substitute.For<IEquipmentInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(null, mockEquipmentInterface);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleButtonInput(EInputKey.UsePrimaryEquipment, true));
        }

        [Test]
        public void OnUsePrimaryEquipmentButton_EquipmentInterface_PressesButton_UseEquipmentInSlotWithPrimarySlot()
        {
            var mockEquipmentInterface = Substitute.For<IEquipmentInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(null, mockEquipmentInterface);

            locomotionInputHandler.HandleButtonInput(EInputKey.UsePrimaryEquipment, true);


            mockEquipmentInterface.Received().UseEquipmentInSlot(Arg.Is(EEquipmentSlot.PrimarySlot));
        }

        [Test]
        public void OnUsePrimaryEquipmentButton_EquipmentInterface_ReleasesButton_StopUsingEquipmentInSlotWithPrimarySlot()
        {
            var mockEquipmentInterface = Substitute.For<IEquipmentInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(null, mockEquipmentInterface);

            locomotionInputHandler.HandleButtonInput(EInputKey.UsePrimaryEquipment, false);


            mockEquipmentInterface.Received().StopUsingEquipmentInSlot(Arg.Is(EEquipmentSlot.PrimarySlot));
        }

        [Test]
        public void OnUseSecondaryEquipmentButton_EquipmentInterfaceNull_Unhandled()
        {
            var locomotionInputHandler = new LocomotionInputHandler(null, null);

            Assert.AreEqual(EInputHandlerResult.Unhandled, locomotionInputHandler.HandleButtonInput(EInputKey.UseSecondaryEquipment, true));
        }

        [Test]
        public void OnUseSecondaryEquipmentButton_EquipmentInterfaceExists_Handled()
        {
            var mockEquipmentInterface = Substitute.For<IEquipmentInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(null, mockEquipmentInterface);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleButtonInput(EInputKey.UseSecondaryEquipment, true));
        }

        [Test]
        public void OnUseSecondaryEquipmentButton_EquipmentInterface_PressesButtton_UseEquipmentInSlotWithSecondarySlot()
        {
            var mockEquipmentInterface = Substitute.For<IEquipmentInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(null, mockEquipmentInterface);

            locomotionInputHandler.HandleButtonInput(EInputKey.UseSecondaryEquipment, true);


            mockEquipmentInterface.Received().UseEquipmentInSlot(Arg.Is(EEquipmentSlot.SecondarySlot));
        }

        [Test]
        public void OnUseSecondaryEquipmentButton_EquipmentInterface_ReleasesButton_StopUsingEquipmentInSlotWithSecondarySlot()
        {
            var mockEquipmentInterface = Substitute.For<IEquipmentInterface>();
            var locomotionInputHandler = new LocomotionInputHandler(null, mockEquipmentInterface);

            locomotionInputHandler.HandleButtonInput(EInputKey.UseSecondaryEquipment, false);


            mockEquipmentInterface.Received().StopUsingEquipmentInSlot(Arg.Is(EEquipmentSlot.SecondarySlot));
        }
    }
}

#endif
