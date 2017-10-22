// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Controller;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Controller
{
    public class TestControllerComponent
        : ControllerComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
        }

        public GameObject GetHudInstance()
        {
            return HudInstance;
        }

        public void TestAwake()
        {
            Awake();
        }
    }
}

#endif
