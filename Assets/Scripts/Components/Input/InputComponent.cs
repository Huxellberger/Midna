// Copyright Threetee Gang (C) 2017

using System;
using UnityEngine;

namespace Assets.Scripts.Components.Input
{
    public class InputComponent 
        : MonoBehaviour
        , IInputInterface
    {

        private IInputMappingProviderInterface _inputMappingProviderInterface;
        private const float AxisPrecision = 0.01f;

        private void Awake()
        {
            _inputMappingProviderInterface = null;
        }
	    
        // When input flags are updated
        private void Update ()
        {
            foreach (var input in _inputMappingProviderInterface.GetRawInputs())
            {
                var inputPressed = false;
                var inputValue = 0.0f;

                // Get state of button
                switch (input.InputType)
                {
                    case EInputType.Analog:
                        inputValue = UnityEngine.Input.GetAxis(input.InputName);
                        inputPressed = Math.Abs(inputValue) < AxisPrecision;
                        break;
                    case EInputType.Button:
                        inputPressed = UnityEngine.Input.GetButton(input.InputName); // Make everything a button
                        break;
                    case EInputType.Mouse:
                        // ToDo: Handle mouse locations. Buttons and analog will do for now
                        break;
                    default:
                        break;
                }

                var actualInput = _inputMappingProviderInterface.GetTranslatedInput(input);

                // respond to state
                switch (actualInput.InputType)
                {
                    case EInputType.Analog:
                        OnAnalogInput(actualInput, inputValue);
                        break;
                    case EInputType.Button:
                        OnButtonPressed(actualInput, inputPressed);
                        break;
                    case EInputType.Mouse:
                        // ToDo: Handle mouse locations. Buttons and analog will do for now
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnAnalogInput(TranslatedInput translatedInput, float newInputValue)
        {
            if (Math.Abs(translatedInput.AxisValue - newInputValue) > AxisPrecision)
            {
                translatedInput.AxisValue = newInputValue;
            }
        }

        private void OnButtonPressed(TranslatedInput translatedInput, bool newPressed)
        {
            if (translatedInput.Pressed != newPressed)
            {
                translatedInput.Pressed = newPressed;
            }
        }

        public void SetInputMappingProvider(IInputMappingProviderInterface inInputMappingProviderInterface)
        {
            _inputMappingProviderInterface = inInputMappingProviderInterface;
        }
    }
}
