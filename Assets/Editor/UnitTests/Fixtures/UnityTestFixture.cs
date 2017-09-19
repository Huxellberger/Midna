// Copyright Threetee Gang (C) 2017

using NUnit.Framework;
using Midna.Editor.UnitTests.TestHelpers;

namespace Midna.Editor.UnitTests.TestFixtures
{
    [TestFixture]
    public abstract class UnityTestFixture
    {
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
        }

        protected abstract void OnBeforeTest();
        protected abstract void OnAfterTest();

        protected ConsoleLogHandler consoleLogHandler;
    }
}
