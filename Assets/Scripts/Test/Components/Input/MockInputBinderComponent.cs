// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Input
{
    public class MockInputBinderComponent 
        : MonoBehaviour
        , IInputBinderInterface
        , ITestableMonobehaviour
    {
        public IInputInterface InputInterface { get; private set; }
        public InputHandler RegisteredHandler { get; private set; }
        public InputHandler UnregisteredHandler { get; private set; }

        public void SetInputInterface(IInputInterface inInputInterface)
        {
            InputInterface = inInputInterface;
        }

        public void RegisterInputHandler(InputHandler inInputHandler)
        {
            RegisteredHandler = inInputHandler;
        }

        public void UnregisterInputHandler(InputHandler inInputHandler)
        {
            UnregisteredHandler = inInputHandler;
        }

        public void PrepareForTest(params object[] parameters)
        {
            
        }
    }
}
