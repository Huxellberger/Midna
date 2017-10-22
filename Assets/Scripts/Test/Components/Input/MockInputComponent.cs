// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Input;
using Assets.Scripts.Test.TestableMonobehaviour;
using Assets.Scripts.UnityLayer.Input;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Input
{
    public class MockInputComponent 
        : MonoBehaviour
        , IInputInterface
        , ITestableMonobehaviour
    {
        public event OnButtonInputDelegate OnButtonInputEvent;
        public event OnAnalogInputDelegate OnAnalogInputEvent;
        public event OnMouseInputDelegate OnMouseInputEvent;

        public IInputMappingProviderInterface InputMappingProvider { get; private set; }
        public IUnityInputInterface UnityInputInterface { get; private set; }

        public void PrepareForTest(params object[] parameters)
        {
            InputMappingProvider = null;
            UnityInputInterface = null;
        }
 
        public void SetInputMappingProvider(IInputMappingProviderInterface inInputMappingProviderInterface)
        {
            InputMappingProvider = inInputMappingProviderInterface;
        }

        public void SetUnityInputInterface(IUnityInputInterface inUnityInputInterface)
        {
            UnityInputInterface = inUnityInputInterface;
        }
    }
}

#endif
