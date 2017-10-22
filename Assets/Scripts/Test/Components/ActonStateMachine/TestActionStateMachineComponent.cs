// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.ActonStateMachine
{
    public class TestActionStateMachineComponent 
        : ActionStateMachineComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(object [] parameters)
        {
            Awake();
        }

        public void TestUpdate()
        {
            Update();
        }

        public void TestDestroy()
        {
            OnDestroy();
        }
    }
}

#endif
