// Copyright Threetee Gang (C) 2017

using UnityEngine;
using Midna.Test.TestHelpers;

namespace Midna.Editor.UnitTests.TestHelpers
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
