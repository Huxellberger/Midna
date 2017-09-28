// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Locomotion
{
    [TestFixture]
    public class LocomotionActionStateTestFixture
    {
        [Test]
        public void GetId_ReturnsLocomotionId()
        {
            var locomotionActionState = new LocomotionActionState(new ActionStateInfo());

            Assert.AreEqual(locomotionActionState.ActionStateId, EActionStateId.Locomotion);
        }
    }
}
