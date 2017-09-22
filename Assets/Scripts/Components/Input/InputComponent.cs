// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Input
{
    public class InputComponent 
        : MonoBehaviour
        , IInputInterface
    {
        private void Awake()
        {
            _inputBinderSet = new List<InputBinder>();
            _nextAssignedHandle = 0;
        }

        private void Update()
        {
            foreach (var inputBinder in _inputBinderSet)
            {
                // Update pressed buttons
            }
        }

        // IInputInterface
        public void PushInputBinder(InputBinder inInputBinding)
        {
            inInputBinding.Handle = _nextAssignedHandle;
            _inputBinderSet.Add(inInputBinding);

            _nextAssignedHandle++;
        }

        public void PopInputBinder(InputBinder inInputBinder)
        {
            _inputBinderSet.Remove(inInputBinder);
        }
        // ~IInputInterface

        private List<InputBinder> _inputBinderSet;
        private int _nextAssignedHandle;
    }
}
