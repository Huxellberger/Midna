// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input.Handlers
{
    public class CustomInputHandler 
        : InputHandler
    {
        public CustomInputHandler(IEnumerable<EInputKey> inInputs, OnButtonInputHandledDelegate inDelegate)
            : base()
        {
            foreach (var inputKey in inInputs)
            {
                ButtonResponses.Add(inputKey, inDelegate);
            }
        }

        public CustomInputHandler(IEnumerable<EInputKey> inInputs, OnAnalogInputHandledDelegate inDelegate)
            : base()
        {
            foreach (var inputKey in inInputs)
            {
                AnalogResponses.Add(inputKey, inDelegate);
            }
        }

        public CustomInputHandler(IEnumerable<EInputKey> inInputs, OnMouseInputHandledDelegate inDelegate)
            : base()
        {
            foreach (var inputKey in inInputs)
            {
                MouseResponses.Add(inputKey, inDelegate);
            }
        }
    }
}
