// Copyright Threetee Gang (C) 2017

using NUnit.Framework;
using Midna.Components.ActionStateMachine;

namespace Midna.Editor.UnitTests.Components.ActionStateMachine
{
    [TestFixture]
    public class NullActionStateTestFixture
    {
        [Test]
        public void NullActionState_Initialised_HasNullId()
        {
            Assert.AreEqual(new NullActionState().actionStateId, EActionStateId.Null);
        }
    }
}
