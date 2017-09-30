// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using Assets.Scripts.Components.MidnaMovement;

namespace Assets.Scripts.Components.ActionStateMachine.States.Locomotion
{
    public class LocomotionInputHandler
        : InputHandler
    {
        private readonly IMidnaMovementInterface _midnaMovementInterface;

        public LocomotionInputHandler(IMidnaMovementInterface inMidnaMovementInterface)
            : base()
        {
            _midnaMovementInterface = inMidnaMovementInterface;

            AnalogResponses.Add(EInputKey.HorizontalAnalog, OnHorizontalInput);
            AnalogResponses.Add(EInputKey.VerticalAnalog, OnVerticalInput);
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
    }
}
