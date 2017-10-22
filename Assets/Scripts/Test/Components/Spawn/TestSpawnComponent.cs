// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Spawn;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Spawn
{
    public class TestSpawnComponent 
        : SpawnComponent
            , ITestableMonobehaviour
    {
        public void TestTriggerSpawnUpdate(GameObject inSpawnableGameObject)
        {
            TriggerSpawnUpdate(inSpawnableGameObject);
        }

        public void PrepareForTest(params object[] parameters)
        {
        }
    }
}

#endif
