// Copyright (C) Threetee Gang 2017

using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Helpers
{
    public class ConsoleLogHandler
    {
        public class ConsoleLogEntry
        {
            public ConsoleLogEntry(string inErrorMessage)
            {
                ErrorMessage = inErrorMessage;
                Active = true;
            }

            public string ErrorMessage { get; set; }
            public bool Active { get; set; }
        }

        public ConsoleLogHandler()
        {
            _receivedErrors = new List<ConsoleLogEntry>();
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
            foreach (var receivedError in _receivedErrors)
            {
                if (receivedError.ErrorMessage.Equals(desiredError) && receivedError.Active)
                {
                    receivedError.Active = false;
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
            foreach (var receivedError in _receivedErrors)
            {
                if (receivedError.Active)
                {
                    totalActiveErrors++;
                }
            }
            return totalActiveErrors;
        }

        private void DeactivateAllActiveErrors()
        {
            foreach (var receivedError in _receivedErrors)
            {
                receivedError.Active = false;
            }
        }

        private void HandleLog(string logString, string stackTrace, LogType givenLogType)
        {
            if (givenLogType == LogType.Error || givenLogType == LogType.Exception)
            {
                _receivedErrors.Add(new ConsoleLogEntry(logString));
            }
        }

        private readonly List<ConsoleLogEntry> _receivedErrors;
    }
}
