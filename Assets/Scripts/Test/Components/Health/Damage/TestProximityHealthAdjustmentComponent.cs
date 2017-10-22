// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Health.Damage;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Health.Damage
{
    public class TestProximityHealthAdjustmentComponent 
        : ProximityHealthAdjustmentComponent
        , ITestableMonobehaviour
    {
        public void TestCollide(GameObject inGameObject)
        {
            OnGameObjectCollides(inGameObject);
        }

        public void PrepareForTest(params object[] parameters)
        {
        }
    }
}

#endif
