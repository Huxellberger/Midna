// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Test.Components.Input;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Locomotion
{
    [TestFixture]
    public class LocomotionActionStateTestFixture
    {
        [Test]
        public void GetId_ReturnsLocomotionId()
        {
            var locomotionActionState = new LocomotionActionState(new ActionStateInfo(new GameObject()));

            Assert.AreEqual(locomotionActionState.ActionStateId, EActionStateId.Locomotion);
        }

        [Test]
        public void Start_RegistersInputHandler()
        {
            var mockInputBinderComponent = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();
            var locomotionActionState = new LocomotionActionState(new ActionStateInfo(mockInputBinderComponent.gameObject));

            locomotionActionState.Start();

            Assert.IsNotNull((LocomotionInputHandler)mockInputBinderComponent.RegisteredHandler);
        }

        [Test]
        public void End_UnregistersInputHandler()
        {
            var mockInputBinderComponent = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();
            var locomotionActionState = new LocomotionActionState(new ActionStateInfo(mockInputBinderComponent.gameObject));

            locomotionActionState.Start();
            locomotionActionState.End();

            Assert.IsNotNull((LocomotionInputHandler)mockInputBinderComponent.UnregisteredHandler);
        }
    }
}

#endif
