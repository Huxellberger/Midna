// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Test.Components.ActonStateMachine;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Dead
{
    [TestFixture]
    public class DeadActionStateHelpersTestFixture
    {
        [Test]
        public void TransitionIntoDeadActionState_SetsDeadActionStateActive()
        {
            var actionStateMachineComponent = TestableMonobehaviourFunctions<MockActionStateMachineComponent>
                .PrepareMonobehaviourComponentForTest();

            DeadActionStateHelpers.TransitionIntoDeadActionState(actionStateMachineComponent.gameObject);

            Assert.AreEqual(EActionStateMachineTrack.Locomotion, actionStateMachineComponent.RequestedTrack);
            Assert.AreEqual(EActionStateId.Dead, actionStateMachineComponent.RequestedState.ActionStateId);
            Assert.NotNull((DeadActionState)actionStateMachineComponent.RequestedState);
        }
    }
}
