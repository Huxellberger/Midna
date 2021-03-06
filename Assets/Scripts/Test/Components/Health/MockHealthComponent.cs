﻿// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Health;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Health
{
    public class MockHealthComponent 
        : MonoBehaviour
        , ITestableMonobehaviour
        , IHealthInterface
    {
        public int ? AdjustHealthResult { get; private set; }
        public bool ? SetHealthChangeEnabledResult { get; private set; }
        
        // ITestableMonobehaviour
        public void PrepareForTest(params object[] parameters)
        {
        }
        // ~ITestableMonobehaviour

        // IHealthInterface
        public void AdjustHealth(int inChange)
        {
            AdjustHealthResult = inChange;
        }

        public void SetHealthChangedEnabled(bool isEnabled)
        {
            SetHealthChangeEnabledResult = isEnabled;
        }

        public void ReplenishHealth()
        {
        }

        public int GetCurrentHealth()
        {
            return 1;
        }

        public int GetMaxHealth()
        {
            return 1;
        }
        // ~IHealthInterface
    }
}

#endif
