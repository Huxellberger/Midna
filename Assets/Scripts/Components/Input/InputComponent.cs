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
                var inputCoordinate = new Vector3();

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
                        inputCoordinate = UnityEngine.Input.mousePosition;
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
                        OnButtonInput(actualInput, inputPressed);
                        break;
                    case EInputType.Mouse:
                        OnMouseInput(actualInput, inputCoordinate);
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
                if (OnAnalogInputEvent != null)
                {
                    OnAnalogInputEvent(translatedInput.InputKey, translatedInput.AxisValue);
                }
            }
        }

        private void OnButtonInput(TranslatedInput translatedInput, bool newPressed)
        {
            if (translatedInput.Pressed != newPressed)
            {
                translatedInput.Pressed = newPressed;
                if (OnButtonInputEvent != null)
                {
                    OnButtonInputEvent(translatedInput.InputKey, translatedInput.Pressed);
                }
            }
        }
        private void OnMouseInput(TranslatedInput translatedInput, Vector3 newSpace)
        {
            if (!Mathf.Approximately(translatedInput.Coordinate.sqrMagnitude, translatedInput.Coordinate.sqrMagnitude))
            {
                translatedInput.Coordinate = newSpace;
                if (OnMouseInputEvent != null)
                {
                    OnMouseInputEvent(translatedInput.InputKey, translatedInput.Coordinate);
                }
            }
        }

        public event OnButtonInputDelegate OnButtonInputEvent;
        public event OnAnalogInputDelegate OnAnalogInputEvent;
        public event OnMouseInputDelegate OnMouseInputEvent;

        public void SetInputMappingProvider(IInputMappingProviderInterface inInputMappingProviderInterface)
        {
            _inputMappingProviderInterface = inInputMappingProviderInterface;
        }
    }
}
