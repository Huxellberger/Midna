// Copyright Threetee Gang (C) 2017

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Input
{
    public class InputBinderComponent 
        : MonoBehaviour
        , IInputBinderInterface
    {
        protected void Awake ()
        {
		    _registeredInputHandlers = new List<InputHandler>();
            _inputInterface = null;
        }

        // IInputBinderInterface
        public void SetInputInterface(IInputInterface inInputInterface)
        {
            UnregisterForInputEvents();
            _inputInterface = inInputInterface;
            RegisterForInputEvents();
        }

        public void RegisterInputHandler(InputHandler inInputHandler)
        {
            if (_registeredInputHandlers.Contains(inInputHandler) || inInputHandler == null)
            {
                throw new InvalidInputHandlerException(inInputHandler);
            }

            _registeredInputHandlers.Add(inInputHandler);
        }

        public void UnregisterInputHandler(InputHandler inInputHandler)
        {
            if (!_registeredInputHandlers.Remove(inInputHandler))
            {
                throw new InvalidInputHandlerException(inInputHandler);
            }
        }
        // ~IInputBinderInterface

        private void RegisterForInputEvents()
        {
            if (_inputInterface == null)
            {
                throw new ArgumentNullException("Input interface was null on registration!");
            }

            _inputInterface.OnAnalogInputEvent += OnAnalogInput;
            _inputInterface.OnButtonInputEvent += OnButtonInput;
            _inputInterface.OnMouseInputEvent += OnMouseInput;
        }

        private void UnregisterForInputEvents()
        {
            if (_inputInterface != null)
            {
                _inputInterface.OnAnalogInputEvent -= OnAnalogInput;
                _inputInterface.OnButtonInputEvent -= OnButtonInput;
                _inputInterface.OnMouseInputEvent -= OnMouseInput;
            }
        }

        private void OnAnalogInput(EInputKey inInputKey, float analogValue)
        {
            foreach (var inputHandler in _registeredInputHandlers)
            {
                if (inputHandler.HandleAnalogInput(inInputKey, analogValue) == EInputHandlerResult.Handled)
                {
                    return;
                }
            }
        }

        private void OnButtonInput(EInputKey inInputKey, bool pressed)
        {
            foreach (var inputHandler in _registeredInputHandlers)
            {
                if (inputHandler.HandleButtonInput(inInputKey, pressed) == EInputHandlerResult.Handled)
                {
                    return;
                }
            }
        }

        private void OnMouseInput(EInputKey inInputKey, Vector3 mousePosition)
        {
            foreach (var inputHandler in _registeredInputHandlers)
            {
                if (inputHandler.HandleMouseInput(inInputKey, mousePosition) == EInputHandlerResult.Handled)
                {
                    return;
                }
            }
        }

        private IList<InputHandler> _registeredInputHandlers;
        private IInputInterface _inputInterface;
    }
}
