// Copyright (C) Threetee Gang 2017

using NUnit.Framework;
using UnityEngine;

// NB: Using "Bad log" instead of error as the word error upsets the cloud build for some reason when it shows up in a log

#if LOCAL_EDITOR

namespace Midna.Editor.UnitTests.TestHelpers
{
    [TestFixture]
    public class ConsoleLogHandlerTestFixture
    {
        [SetUp]
        public void BeforeTest()
        {
            testHandler = new ConsoleLogHandler();
        }

        [TearDown]
        public void AfterTest()
        {
            testHandler = null;
        }

        [Test]
        public void GivenConsoleLogHandler_WhenCreated_NotListeningForEvents()
        {
            Debug.LogError("Test");

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
        }

        [Test]
        public void GivenConsoleLogHandler_WhenActivated_RemembersIfBadLogOccurred()
        {
            testHandler.Activate();

            Debug.LogError("Test");

            Assert.IsTrue(testHandler.HasReceivedAnyNewErrors());

            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_WhenActivated_CatchesCorrectBadLog()
        {
            testHandler.Activate();

            const string errorMessage = "Test";

            Debug.LogError(errorMessage);

            Assert.IsTrue(testHandler.HasReceivedNewErrorString(errorMessage));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_WhenActivated_CatchesMultipleBadLogs()
        {
            testHandler.Activate();

            Debug.LogError("Test");
            Debug.LogError("OtherTest");

            Assert.IsTrue(testHandler.HasReceivedExactlyNNewErrors(2));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_WhenDeactivated_StopsCatchingBadLogs()
        {
            testHandler.Activate();
            testHandler.Deactivate();

            Debug.LogError("Test");

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedAnyNewBadLogs_NoBadLogs_False()
        {
            testHandler.Activate();

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedAnyNewBadLogs_NewBadLog_True()
        {
            testHandler.Activate();

            Debug.LogError("Test");

            Assert.IsTrue(testHandler.HasReceivedAnyNewErrors());
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedAnyNewBadLogs_OldBadLog_False()
        {
            testHandler.Activate();

            Debug.LogError("Test");

            testHandler.HasReceivedAnyNewErrors();

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedExactlyNNewBadLogs_WrongN_False()
        {
            testHandler.Activate();

            Debug.LogError("Test");

            Assert.IsFalse(testHandler.HasReceivedExactlyNNewErrors(2));

            testHandler.HasReceivedExactlyNNewErrors(1);
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedExactlyNNewBadLogs_CorrectN_True()
        {
            testHandler.Activate();

            Debug.LogError("Test");

            Assert.IsTrue(testHandler.HasReceivedExactlyNNewErrors(1));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedExactlyNNewBadLogs_OldBadLog_False()
        {
            testHandler.Activate();

            Debug.LogError("Test");

            testHandler.HasReceivedExactlyNNewErrors(1);

            Assert.IsFalse(testHandler.HasReceivedExactlyNNewErrors(1));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedNewBadLogOfString_WrongString_False()
        {
            testHandler.Activate();

            const string errorMessage = "Test";
            const string wrongErrorMessage = "NotTest";

            Debug.LogError(errorMessage);

            Assert.IsFalse(testHandler.HasReceivedNewErrorString(wrongErrorMessage));

            testHandler.HasReceivedNewErrorString(errorMessage);
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedNewBadLogOfString_CorrectString_True()
        {
            testHandler.Activate();

            const string errorMessage = "Test";

            Debug.LogError(errorMessage);

            Assert.IsTrue(testHandler.HasReceivedNewErrorString(errorMessage));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedNewBadLogOfString_OldCorrectString_False()
        {
            testHandler.Activate();

            const string errorMessage = "Test";

            Debug.LogError(errorMessage);

            testHandler.HasReceivedNewErrorString(errorMessage);
            Assert.IsFalse(testHandler.HasReceivedNewErrorString(errorMessage));
            testHandler.Deactivate();
        }

        private ConsoleLogHandler testHandler;
    }
}

#endif // LOCAL_EDITOR
