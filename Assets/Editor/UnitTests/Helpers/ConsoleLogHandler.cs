// Copyright (C) Threetee Gang 2017

using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

// Fails cloud build at the moment so should only be used for locally checking errors
#if UNITY_EDITOR

namespace Midna.Editor.UnitTests.TestHelpers
{
    public class ConsoleLogHandler
    {
        public class ConsoleLogEntry
        {
            public ConsoleLogEntry(string inErrorMessage)
            {
                errorMessage = inErrorMessage;
                active = true;
            }

            public string errorMessage { get; set; }
            public bool active { get; set; }
        }

        public ConsoleLogHandler()
        {
            receivedErrors = new List<ConsoleLogEntry>();
        }

        public void Activate()
        {
            Application.logMessageReceived += HandleLog;
        }

        public void Deactivate()
        {
            if (GetNumberOfActiveErrors() > 0)
            {
                Assert.Fail( "Still had active errors on test run completion!" );
            }
            Application.logMessageReceived -= HandleLog;
        }

        public bool HasReceivedNewErrorString(string desiredError)
        {
            foreach (var receivedError in receivedErrors)
            {
                if (receivedError.errorMessage.Equals(desiredError) && receivedError.active)
                {
                    receivedError.active = false;
                    return true;
                }
            }

            return false;
        }

        public bool HasReceivedAnyNewErrors()
        {
            if (GetNumberOfActiveErrors() > 0)
            {
                DeactivateAllActiveErrors();
                return true;
            }

            return false;
        }

        public bool HasReceivedExactlyNNewErrors(int errorCount)
        {
            if (GetNumberOfActiveErrors() == errorCount)
            {
                DeactivateAllActiveErrors();
                return true;
            }

            return false;
        }

        private int GetNumberOfActiveErrors()
        {
            int totalActiveErrors = 0;
            foreach (var receivedError in receivedErrors)
            {
                if (receivedError.active)
                {
                    totalActiveErrors++;
                }
            }
            return totalActiveErrors;
        }

        private void DeactivateAllActiveErrors()
        {
            foreach (var receivedError in receivedErrors)
            {
                receivedError.active = false;
            }
        }

        private void HandleLog(string logString, string stackTrace, LogType givenLogType)
        {
            if (givenLogType == LogType.Error || givenLogType == LogType.Exception)
            {
                receivedErrors.Add(new ConsoleLogEntry(logString));
            }
        }

        private List<ConsoleLogEntry> receivedErrors;
    }
}

#endif // UNITY_EDITOR
