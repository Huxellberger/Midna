// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using UnityEngine;

namespace Assets.Scripts.Components.ActionStateMachine.States.Locomotion
{
    public class LocomotionInputHandler
        : InputHandler
    {
        private GameObject _characterGameObject;

        public LocomotionInputHandler(GameObject inCharacter)
            : base()
        {
            _characterGameObject = inCharacter;

            AnalogResponses.Add(EInputKey.HorizontalAnalog, OnHorizontalInput);
            AnalogResponses.Add(EInputKey.VerticalAnalog, OnVerticalInput);
        }

        private EInputHandlerResult OnHorizontalInput(float analogValue)
        {
            return EInputHandlerResult.Handled;
        }

        private EInputHandlerResult OnVerticalInput(float analogValue)
        {
            return EInputHandlerResult.Handled;
        }
    }
}
