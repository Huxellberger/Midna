// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Fixtures
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

#endif
