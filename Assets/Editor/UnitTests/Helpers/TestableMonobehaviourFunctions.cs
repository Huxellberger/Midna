// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Editor.UnitTests.Helpers
{
    public static class TestableMonobehaviourFunctions<MonoBehaviourType>
        where MonoBehaviourType : MonoBehaviour, ITestableMonobehaviour
    {
        public static MonoBehaviourType PrepareMonobehaviourComponentForTest(params object[] parameters)
        {
            var gameObject = new GameObject();
            var createdComponent = gameObject.AddComponent<MonoBehaviourType>();
            createdComponent.PrepareForTest(parameters);

            return createdComponent;
        }

        public static MonoBehaviourType AddTestableMonobehaviourComponent(GameObject inGameObject, params object[] parameters)
        {
            var createdComponent = inGameObject.AddComponent<MonoBehaviourType>();
            createdComponent.PrepareForTest();

            return createdComponent;
        }
    }
}

#endif
