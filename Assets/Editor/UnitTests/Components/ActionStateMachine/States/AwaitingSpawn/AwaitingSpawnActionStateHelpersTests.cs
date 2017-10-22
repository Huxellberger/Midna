// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.AwaitingSpawn;
using Assets.Scripts.Test.Components.ActonStateMachine;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.AwaitingSpawn
{
    [TestFixture]
    public class AwaitingSpawnActionStateHelpersTestFixture
    {
        [Test]
        public void TransitionIntoAwaitingSpawnActionState_SetsAwaitingSpawnActionStateActive()
        {
            var actionStateMachineComponent = TestableMonobehaviourFunctions<MockActionStateMachineComponent>
                .PrepareMonobehaviourComponentForTest();

            AwaitingSpawnActionStateHelpers.TransitionIntoAwaitingSpawnActionState(actionStateMachineComponent.gameObject);

            Assert.AreEqual(EActionStateMachineTrack.Locomotion, actionStateMachineComponent.RequestedTrack);
            Assert.AreEqual(EActionStateId.AwaitingSpawn, actionStateMachineComponent.RequestedState.ActionStateId);
            Assert.NotNull((AwaitingSpawnActionState)actionStateMachineComponent.RequestedState);
        }
    }
}

#endif
