// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Spawn;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Spawn
{
    public class TestProximitySpawnComponent 
        : ProximitySpawnComponent
        , ITestableMonobehaviour
    {
        public bool TriggeredSpawnUpdate { get; private set; }

        public void TestCollision(GameObject inCollidingObject)
        {
            OnGameObjectCollides(inCollidingObject);
        }

        protected override void TriggerSpawnUpdate(GameObject inGameObject)
        {
            TriggeredSpawnUpdate = true;
        }

        public void PrepareForTest(params object[] parameters)
        {
            TriggeredSpawnUpdate = false;
        }
    }
}
