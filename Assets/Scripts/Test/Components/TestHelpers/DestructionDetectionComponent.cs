// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.TestHelpers
{
    public class DestructionDetectionComponent 
        : MonoBehaviour
        , ITestableMonobehaviour
    {
        public bool OnDestroyCalled { get; private set; }

        void Awake()
        {
            enabled = true;
        }

        void OnDestroy()
        {
            OnDestroyCalled = true;
        }

        public void PrepareForTest(params object[] parameters)
        {
            Awake();

            OnDestroyCalled = false;
        }
    }
}

#endif
