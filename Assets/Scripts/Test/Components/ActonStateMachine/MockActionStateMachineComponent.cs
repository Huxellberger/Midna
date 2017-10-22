// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.ActonStateMachine
{
    public class MockActionStateMachineComponent 
        : MonoBehaviour
        , IActionStateMachineInterface
        , ITestableMonobehaviour
    {
        public EActionStateMachineTrack RequestedTrack { get; private set; }
        public ActionState RequestedState { get; private set; }
        public bool IsActionStateActiveResult { get; set; }

        protected void Awake()
        {
            RequestedTrack = EActionStateMachineTrack.None;
            RequestedState = null;
            IsActionStateActiveResult = false;
        }

        public void RequestActionState(EActionStateMachineTrack selectedTrack, ActionState newState)
        {
            RequestedTrack = selectedTrack;
            RequestedState = newState;
        }

        public bool IsActionStateActiveOnTrack(EActionStateMachineTrack selectedTrack, EActionStateId expectedId)
        {
            return IsActionStateActiveResult;
        }

        public void PrepareForTest(params object[] parameters)
        {
            Awake();
        }
    }
}

#endif
