// Copyright Threetee Gang (C) 2017

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
        public int AdjustHealthResult { get; private set; }
        
        // ITestableMonobehaviour
        public void PrepareForTest(params object[] parameters)
        {
            AdjustHealthResult = 0;
        }
        // ~ITestableMonobehaviour

        // IHealthInterface
        public void AdjustHealth(int inChange)
        {
            AdjustHealthResult = inChange;
        }

        public void SetHealthChangedEnabled(bool isEnabled)
        {
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
