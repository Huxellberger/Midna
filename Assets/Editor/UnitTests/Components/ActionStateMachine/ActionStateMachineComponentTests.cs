// Copyright Threetee Gang (C) 2017

using System;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Test.Components.ActonStateMachine;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine
{
    [TestFixture]
    public class ActionStateMachineComponentTestFixture
    {
        [SetUp]
        public void BeforeTest()
        {
            actionStateMachineComponent = TestableMonobehaviourFunctions<TestActionStateMachineComponent>.PrepareMonobehaviourComponentForTest(null);
        }

        [TearDown]
        public void AfterTest()
        {
            actionStateMachineComponent = null;
        }

        [Test]
        public void WhenCreated_AllTracksHaveNullActionStateId()
        {
            var tracks = Enum.GetValues(typeof(EActionStateMachineTrack));

            foreach(EActionStateMachineTrack track in tracks)
            {
                Assert.IsTrue(actionStateMachineComponent.IsActionStateActiveOnTrack(track, EActionStateId.Null));
            }
        }

        [Test]
        public void IsActionStateActiveOnTrack_WrongTrackCorrectId_False()
        {
            const EActionStateId expectedStateId = EActionStateId.Locomotion;
            const EActionStateMachineTrack wrongTrack = EActionStateMachineTrack.None;
            const EActionStateMachineTrack changedTrack = EActionStateMachineTrack.Locomotion;

            var actionState = new TestActionState(expectedStateId);

            actionStateMachineComponent.RequestActionState(changedTrack, actionState);

            Assert.IsFalse(actionStateMachineComponent.IsActionStateActiveOnTrack(wrongTrack, expectedStateId));
        }

        [Test]
        public void IsActionStateActiveOnTrack_CorrectTrackWrongId_False()
        {
            const EActionStateId wrongId = EActionStateId.Null;
            const EActionStateId expectedStateId = EActionStateId.Locomotion;
            const EActionStateMachineTrack changedTrack = EActionStateMachineTrack.Locomotion;

            var actionState = new TestActionState(expectedStateId);

            actionStateMachineComponent.RequestActionState(changedTrack, actionState);

            Assert.IsFalse(actionStateMachineComponent.IsActionStateActiveOnTrack(changedTrack, wrongId));
        }

        [Test]
        public void RequestActionState_SetsTrackToNewIdAndIsActionStateActiveReturnsTrue()
        {
            const EActionStateId expectedStateId = EActionStateId.Locomotion;
            const EActionStateMachineTrack changedTrack = EActionStateMachineTrack.Locomotion;

            var actionState = new TestActionState(expectedStateId);

            actionStateMachineComponent.RequestActionState(changedTrack, actionState);

            Assert.IsTrue(actionStateMachineComponent.IsActionStateActiveOnTrack(changedTrack, expectedStateId));
        }

        TestActionStateMachineComponent actionStateMachineComponent;
    }
}
