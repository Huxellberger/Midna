// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Input;

namespace Assets.Editor.UnitTests.Components.Input
{
    public class TestInputHandler
        : InputHandler
    {
        public void AddButtonResponse(EInputKey inInputKey, OnButtonInputHandledDelegate func)
        {
            ButtonResponses.Add(inInputKey, func);
        }

        public void AddAnalogResponse(EInputKey inInputKey, OnAnalogInputHandledDelegate func)
        {
            AnalogResponses.Add(inInputKey, func);
        }

        public void AddMouseResponse(EInputKey inInputKey, OnMouseInputHandledDelegate func)
        {
            MouseResponses.Add(inInputKey, func);
        }

        public void ClearResponses()
        {
            ButtonResponses.Clear();
            AnalogResponses.Clear();
            MouseResponses.Clear();
        }
    }
}

#endif
