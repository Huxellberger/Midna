// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Input
{
    public class InputComponent : MonoBehaviour
    {
        // Load from PlayerPrefs/abstraction of it
        private InputMapper _inputMapper;
        // Update from some master list
        private IEnumerable<RawInput> _inputs;
	
        // Update is called once per frame
        private void Update ()
        {
            foreach (var input in _inputs)
            {
                var inputPressed = false;
                var inputValue = 0.0f;

                // Get state of button
                switch (input.InputType)
                {
                    case EInputType.Analog:
                        inputValue = UnityEngine.Input.GetAxis(input.InputName);
                        inputPressed = inputValue == 0.0f;
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

                var actualInput = _inputMapper.MapInput(input);

                // respond to state
                switch (actualInput.InputType)
                {
                    case EInputType.Analog:
                        OnAnalogInput(actualInput.InputKey, inputValue);
                        break;
                    case EInputType.Button:
                        OnButtonPressed(actualInput.InputKey, inputPressed);
                        break;
                    case EInputType.Mouse:
                        // ToDo: Handle mouse locations. Buttons and analog will do for now
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnAnalogInput(EInputKey inputKey, float inputValue)
        {
            
        }

        private void OnButtonPressed(EInputKey inputKey, bool pressed)
        {
            
        }
    }
}
