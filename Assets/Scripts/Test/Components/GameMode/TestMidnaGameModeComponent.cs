// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using System.Collections.Generic;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.GameMode
{
    public class TestMidnaGameModeComponent 
        : MidnaGameModeComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Awake();
        }

        public List<GameObject> GetPlayerControllers()
        {
            return PlayerControllers;
        }
    }
}

#endif
