// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Test.Components.ActonStateMachine;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Locomotion
{
    [TestFixture]
    public class LocomotionActionStateHelpersTestFixture {

        [Test]
        public void TransitionIntoLocomotionActionState_SetsLocomotionActionStateActive()
        {
            var actionStateMachineComponent = TestableMonobehaviourFunctions<MockActionStateMachineComponent>
                .PrepareMonobehaviourComponentForTest();

            LocomotionActionStateHelpers.TransitionIntoLocomotionActionState(actionStateMachineComponent.gameObject);

            Assert.AreEqual(EActionStateMachineTrack.Locomotion, actionStateMachineComponent.RequestedTrack);
            Assert.AreEqual(EActionStateId.Locomotion, actionStateMachineComponent.RequestedState.ActionStateId);
            Assert.NotNull((LocomotionActionState)actionStateMachineComponent.RequestedState);
        }
    }
}
