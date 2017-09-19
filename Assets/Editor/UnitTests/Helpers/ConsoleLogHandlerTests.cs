// Copyright (C) Threetee Gang 2017

using NUnit.Framework;
using UnityEngine;

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
            Debug.LogError("TestError");

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
        }

        [Test]
        public void GivenConsoleLogHandler_WhenActivated_RemembersIfErrorOccurred()
        {
            testHandler.Activate();

            Debug.LogError("TestError");

            Assert.IsTrue(testHandler.HasReceivedAnyNewErrors());

            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_WhenActivated_CatchesCorrectError()
        {
            testHandler.Activate();

            const string errorMessage = "TestError";

            Debug.LogError(errorMessage);

            Assert.IsTrue(testHandler.HasReceivedNewErrorString(errorMessage));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_WhenActivated_CatchesMultipleErrors()
        {
            testHandler.Activate();

            Debug.LogError("TestError");
            Debug.LogError("OtherTestError");

            Assert.IsTrue(testHandler.HasReceivedExactlyNNewErrors(2));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_WhenDeactivated_StopsCatchingErrors()
        {
            testHandler.Activate();
            testHandler.Deactivate();

            Debug.LogError("TestError");

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedAnyNewErrors_NoErrors_False()
        {
            testHandler.Activate();

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedAnyNewErrors_NewError_True()
        {
            testHandler.Activate();

            Debug.LogError("TestError");

            Assert.IsTrue(testHandler.HasReceivedAnyNewErrors());
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedAnyNewErrors_OldError_False()
        {
            testHandler.Activate();

            Debug.LogError("TestError");

            testHandler.HasReceivedAnyNewErrors();

            Assert.IsFalse(testHandler.HasReceivedAnyNewErrors());
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedExactlyNNewErrors_WrongN_False()
        {
            testHandler.Activate();

            Debug.LogError("TestError");

            Assert.IsFalse(testHandler.HasReceivedExactlyNNewErrors(2));

            testHandler.HasReceivedExactlyNNewErrors(1);
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedExactlyNNewErrors_CorrectN_True()
        {
            testHandler.Activate();

            Debug.LogError("TestError");

            Assert.IsTrue(testHandler.HasReceivedExactlyNNewErrors(1));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedExactlyNNewErrors_OldErrors_False()
        {
            testHandler.Activate();

            Debug.LogError("TestError");

            testHandler.HasReceivedExactlyNNewErrors(1);

            Assert.IsFalse(testHandler.HasReceivedExactlyNNewErrors(1));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedNewErrorOfString_WrongString_False()
        {
            testHandler.Activate();

            const string errorMessage = "TestError";
            const string wrongErrorMessage = "NotTestError";

            Debug.LogError(errorMessage);

            Assert.IsFalse(testHandler.HasReceivedNewErrorString(wrongErrorMessage));

            testHandler.HasReceivedNewErrorString(errorMessage);
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedNewErrorOfString_CorrectString_True()
        {
            testHandler.Activate();

            const string errorMessage = "TestError";

            Debug.LogError(errorMessage);

            Assert.IsTrue(testHandler.HasReceivedNewErrorString(errorMessage));
            testHandler.Deactivate();
        }

        [Test]
        public void GivenConsoleLogHandler_HasReceivedNewErrorOfString_OldCorrectString_False()
        {
            testHandler.Activate();

            const string errorMessage = "TestError";

            Debug.LogError(errorMessage);

            testHandler.HasReceivedNewErrorString(errorMessage);
            Assert.IsFalse(testHandler.HasReceivedNewErrorString(errorMessage));
            testHandler.Deactivate();
        }

        private ConsoleLogHandler testHandler;
    }
}
