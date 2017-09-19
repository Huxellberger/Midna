// Copyright Threetee Gang (C) 2017

using Midna.Components.ActionStateMachine;
using Midna.Test.TestHelpers;

namespace Midna.Test.Components.ActionStateMachine
{
    public class TestActionStateMachineComponent 
        : ActionStateMachineComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(object [] parameters)
        {
            Awake();
        }
    }
}
