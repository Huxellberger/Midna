// Copyright Threetee Gang (C) 2017

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

        public void PrepareForTest(params object[] parameters)
        {
        }
 
        public void SetInputMappingProvider(IInputMappingProviderInterface inInputMappingProviderInterface)
        {
            throw new System.NotImplementedException();
        }

        public void SetUnityInputInterface(IUnityInputInterface inUnityInputInterface)
        {
            throw new System.NotImplementedException();
        }
    }
}
