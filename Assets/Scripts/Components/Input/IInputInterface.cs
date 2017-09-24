// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.Input
{
    public delegate void OnButtonInputDelegate(EInputKey inputKey, bool pressed);
    public delegate void OnAnalogInputDelegate(EInputKey inputKey, float analogValue);
    public delegate void OnMouseInputDelegate(EInputKey inputKey, Vector3 newMousePos);

    public interface IInputInterface
    {
        event OnButtonInputDelegate OnButtonInputEvent;
        event OnAnalogInputDelegate OnAnalogInputEvent;
        event OnMouseInputDelegate OnMouseInputEvent;

        void SetInputMappingProvider(IInputMappingProviderInterface inInputMappingProviderInterface);
    }
}
