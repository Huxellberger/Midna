// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Test.Components.ActonStateMachine;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine
{
    [TestFixture]
    public class NullActionStateHelpersTestFixture
    {
        [Test]
        public void TransitionIntoNullActionState_SetsNullActionStateActive()
        {
            var actionStateMachineComponent = TestableMonobehaviourFunctions<MockActionStateMachineComponent>
                .PrepareMonobehaviourComponentForTest();

            NullActionStateHelpers.TransitionIntoNullActionState(actionStateMachineComponent.gameObject);

            Assert.AreEqual(EActionStateMachineTrack.Locomotion, actionStateMachineComponent.RequestedTrack);
            Assert.AreEqual(EActionStateId.Null, actionStateMachineComponent.RequestedState.ActionStateId);
            Assert.NotNull((NullActionState)actionStateMachineComponent.RequestedState);
        }
    }
}
