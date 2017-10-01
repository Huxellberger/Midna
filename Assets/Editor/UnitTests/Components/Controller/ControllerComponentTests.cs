// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Components.Controller;
using Assets.Scripts.Test.Components.TestHelpers;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.Controller
{
    [TestFixture]
    public class ControllerComponentTestFixture
    {
        [Test]
        public void CreatePawnOfType_InstantiatesPawnOfType()
        {
            var gameObject = new GameObject();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.CreatePawnOfType(gameObject);

            Assert.IsNotNull(controllerComponent.GetPawnInstance());
        }

        [Test]
        public void CreatePawnOfType_SetsTransformCorrectly()
        {
            var gameObject = new GameObject();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.CreatePawnOfType(gameObject);

            Assert.AreEqual(controllerComponent.GetPawnInstance().transform, controllerComponent.gameObject.transform.parent);
            Assert.AreEqual(new Vector3(0, 0, controllerComponent.PerspectiveDistance), controllerComponent.gameObject.transform.localPosition);
        }

        [Test]
        public void SetPawn_OverridesCurrentPawn()
        {
            var gameObject = new GameObject();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.CreatePawnOfType(gameObject);
            var otherPawn = new GameObject();

            controllerComponent.SetPawn(otherPawn);

            Assert.AreEqual(otherPawn, controllerComponent.GetPawnInstance());
        }

        [Test]
        public void SetPawn_DoesNotDestroyPriorPawn()
        {
            var destructableTestObject = TestableMonobehaviourFunctions<DestructionDetectionComponent>
                .PrepareMonobehaviourComponentForTest();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.SetPawn(destructableTestObject.gameObject);
            var otherPawn = new GameObject();

            controllerComponent.SetPawn(otherPawn);

            // Note: destruction detection is not currently working in Unit Tests
            Assert.IsFalse(destructableTestObject.OnDestroyCalled);
        }

        [Test]
        public void SetPawn_SetsTransformCorrectly()
        {
            var gameObject = new GameObject();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.SetPawn(gameObject);

            Assert.AreEqual(controllerComponent.GetPawnInstance().transform, controllerComponent.gameObject.transform.parent);
            Assert.AreEqual(new Vector3(0, 0, controllerComponent.PerspectiveDistance), controllerComponent.gameObject.transform.localPosition);
        }
    }
}
