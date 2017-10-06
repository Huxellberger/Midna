// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Components.Character;
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

            Assert.IsNotNull(controllerComponent.PawnInstance);
        }

        [Test]
        public void CreatePawnOfType_SetsTransformCorrectly()
        {
            var gameObject = new GameObject();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.CreatePawnOfType(gameObject);

            Assert.AreEqual(controllerComponent.PawnInstance.transform, controllerComponent.gameObject.transform.parent);
            Assert.AreEqual(new Vector3(0, 0, controllerComponent.PerspectiveDistance), controllerComponent.gameObject.transform.localPosition);
        }

        [Test]
        public void CreatePawnOfType_PawnIsCharacter_UpdatesControllerReference()
        {
            var characterComponent = TestableMonobehaviourFunctions<TestMidnaCharacterComponent>
                .PrepareMonobehaviourComponentForTest();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.CreatePawnOfType(characterComponent.gameObject);

            Assert.AreEqual
            (
                controllerComponent, 
                controllerComponent.PawnInstance.GetComponent<TestMidnaCharacterComponent>().GetControllerComponent()
            );
        }

        [Test]
        public void CreatePawnOfType_SetInitialTransform_UsedOnCreation()
        {
            var gameObject = new GameObject();
            var expectedTransform = new GameObject().transform;
            expectedTransform.localPosition = Vector3.forward;

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.PawnInitialTransform = expectedTransform;

            controllerComponent.CreatePawnOfType(gameObject);

            Assert.AreEqual(expectedTransform.localPosition, controllerComponent.PawnInstance.transform.localPosition);
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

            Assert.AreEqual(otherPawn, controllerComponent.PawnInstance);
        }

        [Test]
        public void SetPawn_PawnIsCharacter_UpdatesControllerReference()
        {
            var characterComponent = TestableMonobehaviourFunctions<TestMidnaCharacterComponent>
                .PrepareMonobehaviourComponentForTest();

            var controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            controllerComponent.SetPawn(characterComponent.gameObject);

            Assert.AreEqual(controllerComponent, characterComponent.GetControllerComponent());
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

            Assert.AreEqual(controllerComponent.PawnInstance.transform, controllerComponent.gameObject.transform.parent);
            Assert.AreEqual(new Vector3(0, 0, controllerComponent.PerspectiveDistance), controllerComponent.gameObject.transform.localPosition);
        }
    }
}
