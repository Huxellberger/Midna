// Copyright Threetee Gang (C) 2017

using NUnit.Framework;

namespace Midna.Editor.UnitTests.Components.ActionStateMachine
{
    [TestFixture]
    public class ActionStateTestFixture
    {
        [Test]
        public void ActionState_Start_OnStartCalled()
        {
            var actionState = new TestActionState();

            actionState.Start();

            Assert.IsTrue(actionState.onStartCalled);
        }

        [Test]
        public void ActionState_Update_OnUpdateCalledWithDeltaTime()
        {
            var actionState = new TestActionState();
            const float expectedDelta = 12.1f;

            actionState.Update(expectedDelta);

            Assert.IsTrue(actionState.onUpdateCalled);
            Assert.AreEqual(actionState.onUpdateValue, expectedDelta);
        }

        [Test]
        public void ActionState_End_OnEndCalled()
        {
            var actionState = new TestActionState();

            actionState.End();

            Assert.IsTrue(actionState.onEndCalled);
        }
    }
}
