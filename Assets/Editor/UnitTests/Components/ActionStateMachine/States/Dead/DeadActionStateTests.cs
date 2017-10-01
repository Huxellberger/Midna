// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Dead
{
    [TestFixture]
    public class DeadActionStateTestFixture {

        [Test]
        public void GetActionStateId_Dead()
        {
            var deadActionState = new DeadActionState(new ActionStateInfo());

            Assert.AreEqual(EActionStateId.Dead, deadActionState.ActionStateId);
        }
    }
}
