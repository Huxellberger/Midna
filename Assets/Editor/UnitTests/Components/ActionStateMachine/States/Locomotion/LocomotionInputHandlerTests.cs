// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.Input;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Locomotion
{
    [TestFixture]
    public class LocomotionInputHandlerTestFixture {

        [Test]
        public void OnHorizontalAnalog_Handled()
        {
            var gameObject = new GameObject();
            var locomotionInputHandler = new LocomotionInputHandler(gameObject);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleAnalogInput(EInputKey.HorizontalAnalog, 1.0f));
        }

        [Test]
        public void OnVerticalAnalog_Handled()
        {
            var gameObject = new GameObject();
            var locomotionInputHandler = new LocomotionInputHandler(gameObject);

            Assert.AreEqual(EInputHandlerResult.Handled, locomotionInputHandler.HandleAnalogInput(EInputKey.VerticalAnalog, 1.0f));
        }
    }
}
