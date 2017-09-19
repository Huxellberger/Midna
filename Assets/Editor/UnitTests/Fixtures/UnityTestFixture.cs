// Copyright Threetee Gang (C) 2017

using NUnit.Framework;
using Midna.Editor.UnitTests.TestHelpers;

#if UNITY_EDITOR

namespace Midna.Editor.UnitTests.TestFixtures
{
    [TestFixture]
    public abstract class UnityTestFixture
    {
        public UnityTestFixture()
        {
            consoleLogHandler = null;
        }

        [SetUp]
        public void BeforeTest()
        {
            consoleLogHandler = new ConsoleLogHandler();
            consoleLogHandler.Activate();

            OnBeforeTest();
        }

        [TearDown]
        public void AfterTest()
        {
            OnAfterTest();

            consoleLogHandler.Deactivate();
            consoleLogHandler = null;
        }

        protected abstract void OnBeforeTest();
        protected abstract void OnAfterTest();

        protected ConsoleLogHandler consoleLogHandler;
    }
}

#endif // UNITY_EDITOR
