// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Components.Input;
using Assets.Scripts.Components.MidnaMovement;

namespace Assets.Scripts.Components.ActionStateMachine.States.Locomotion
{
    public class LocomotionInputHandler
        : InputHandler
    {
        private readonly IMidnaMovementInterface _midnaMovementInterface;
        private readonly IEquipmentInterface _equipmentInterface;

        public LocomotionInputHandler(IMidnaMovementInterface inMidnaMovementInterface, IEquipmentInterface inEquipmentInterface)
            : base()
        {
            _midnaMovementInterface = inMidnaMovementInterface;
            _equipmentInterface = inEquipmentInterface;

            AnalogResponses.Add(EInputKey.HorizontalAnalog, OnHorizontalInput);
            AnalogResponses.Add(EInputKey.VerticalAnalog, OnVerticalInput);

            ButtonResponses.Add(EInputKey.SprintButton, OnSprintInput);
            ButtonResponses.Add(EInputKey.UsePrimaryEquipment, OnUsePrimaryEquipmentInput);
            ButtonResponses.Add(EInputKey.UseSecondaryEquipment, OnUseSecondaryEquipmentInput);
        }

        private EInputHandlerResult OnHorizontalInput(float analogValue)
        {
            if (_midnaMovementInterface == null)
            {
                return EInputHandlerResult.Unhandled;
            }

            _midnaMovementInterface.AddHorizontalImpulse(analogValue);
            return EInputHandlerResult.Handled;
        }

        private EInputHandlerResult OnVerticalInput(float analogValue)
        {
            if (_midnaMovementInterface == null)
            {
                return EInputHandlerResult.Unhandled;
            }

            _midnaMovementInterface.AddVerticalImpulse(analogValue);
            return EInputHandlerResult.Handled;
        }

        private EInputHandlerResult OnSprintInput(bool isPressed)
        {
            if (_midnaMovementInterface == null)
            {
                return EInputHandlerResult.Unhandled;
            }

            _midnaMovementInterface.ToggleSprint(isPressed);
            return EInputHandlerResult.Handled;
        }

        private EInputHandlerResult OnUsePrimaryEquipmentInput(bool isPressed)
        {
            return UseEquipmentInSlot(EEquipmentSlot.PrimarySlot, isPressed);
        }

        private EInputHandlerResult OnUseSecondaryEquipmentInput(bool isPressed)
        {
            return UseEquipmentInSlot(EEquipmentSlot.SecondarySlot, isPressed);
        }

        private EInputHandlerResult UseEquipmentInSlot(EEquipmentSlot inSlot, bool isPressed)
        {
            if (_equipmentInterface == null)
            {
                return EInputHandlerResult.Unhandled;
            }

            if (isPressed)
            {
                _equipmentInterface.UseEquipmentInSlot(inSlot);
            }
            else
            {
                _equipmentInterface.StopUsingEquipmentInSlot(inSlot);
            }

            return EInputHandlerResult.Handled;
        }
    }
}
