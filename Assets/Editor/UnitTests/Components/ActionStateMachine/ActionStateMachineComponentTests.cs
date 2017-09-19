// Copyright Threetee Gang (C) 2017

using UnityEngine;
using NUnit.Framework;
using Midna.Components.ActionStateMachine;
using Midna.Test.Components.ActionStateMachine;
using System;

namespace Midna.Editor.UnitTests.Components.ActionStateMachine
{
    [TestFixture]
    public class ActionStateMachineComponentTests
    {
        [Test]
        public void WhenCreated_AllTracksHaveNullActionStateId()
        {
            var gameObject = new GameObject();
            var actionStateMachineComponent = gameObject.AddComponent<TestActionStateMachineComponent>();
            actionStateMachineComponent.TestAwake();

            actionStateMachineComponent.Invoke("Awake", 0.0f);
            gameObject.SendMessage("Update", 10.0f);

            var tracks = Enum.GetValues(typeof(EActionStateMachineTrack));

            foreach(EActionStateMachineTrack track in tracks)
            {
                Assert.IsTrue(actionStateMachineComponent.IsActionStateActiveOnTrack(track, EActionStateId.Null));
            }
        }

        [Test]
        public void IsActionStateActiveOnTrack_WrongTrackCorrectId_False()
        {
            var gameObject = new GameObject();
            var actionStateMachineComponent = gameObject.AddComponent<TestActionStateMachineComponent>();
            actionStateMachineComponent.TestAwake();

            const EActionStateId expectedStateId = EActionStateId.Locomotion;
            const EActionStateMachineTrack wrongTrack = EActionStateMachineTrack.None;
            const EActionStateMachineTrack changedTrack = EActionStateMachineTrack.Locomotion;

            actionStateMachineComponent.RequestActionState(changedTrack, expectedStateId);

            Assert.IsFalse(actionStateMachineComponent.IsActionStateActiveOnTrack(wrongTrack, expectedStateId));
        }

        [Test]
        public void IsActionStateActiveOnTrack_CorrectTrackWrongId_False()
        {
            var gameObject = new GameObject();
            var actionStateMachineComponent = gameObject.AddComponent<TestActionStateMachineComponent>();
            actionStateMachineComponent.TestAwake();

            const EActionStateId wrongId = EActionStateId.Null;
            const EActionStateId expectedStateId = EActionStateId.Locomotion;
            const EActionStateMachineTrack changedTrack = EActionStateMachineTrack.Locomotion;

            actionStateMachineComponent.RequestActionState(changedTrack, expectedStateId);

            Assert.IsFalse(actionStateMachineComponent.IsActionStateActiveOnTrack(changedTrack, wrongId));
        }

        [Test]
        public void RequestActionState_SetsTrackToNewIdAndIsActionStateActiveReturnsTrue()
        {
            var gameObject = new GameObject();
            var actionStateMachineComponent = gameObject.AddComponent<TestActionStateMachineComponent>();
            actionStateMachineComponent.TestAwake();

            const EActionStateId expectedStateId = EActionStateId.Locomotion;
            const EActionStateMachineTrack changedTrack = EActionStateMachineTrack.Locomotion;

            actionStateMachineComponent.RequestActionState(changedTrack, expectedStateId);

            Assert.IsTrue(actionStateMachineComponent.IsActionStateActiveOnTrack(changedTrack, expectedStateId));
        }
    }
}
