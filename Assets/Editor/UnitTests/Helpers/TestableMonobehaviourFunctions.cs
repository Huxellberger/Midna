// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Editor.UnitTests.Helpers
{
    public static class TestableMonobehaviourFunctions<MonoBehaviourType>
        where MonoBehaviourType : MonoBehaviour, ITestableMonobehaviour
    {
        public static MonoBehaviourType PrepareMonobehaviourComponentForTest(object[] parameters)
        {
            var gameObject = new GameObject();
            var createdComponent = gameObject.AddComponent<MonoBehaviourType>();
            createdComponent.PrepareForTest(parameters);

            return createdComponent;
        }
    }
}
