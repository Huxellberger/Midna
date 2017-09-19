// Copyright Threetee Gang (C) 2017

using UnityEngine;
using NUnit.Framework;

#if LOCAL_EDITOR

namespace Midna.Editor.UnitTests.TestFixtures
{
    [TestFixture]
    public class UnityTestFixtureTests
        : UnityTestFixture
    {
        public UnityTestFixtureTests()
            : base()
        {
            onBeforeTestCalled = false;
        }

        protected override void OnBeforeTest()
        {
            onBeforeTestCalled = true;
        }

        protected override void OnAfterTest()
        {
            // Reset
            onBeforeTestCalled = false;
        }

        [Test]
        public void WhenFixtureStartsTest_ConsoleLogHandlerIsActive()
        {
            Debug.LogError("Test!");

            Assert.IsTrue(consoleLogHandler.HasReceivedExactlyNNewErrors(1));
        }

        [Test]
        public void WhenFixtureStartsTest_OnBeforeTestCalled()
        {
            Assert.IsTrue(onBeforeTestCalled);
        }

        private bool onBeforeTestCalled;
    }
}

#endif // LOCAL_EDITOR
