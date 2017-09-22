// Copyright Threetee Gang (C) 2017

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.ActionStateMachine
{
    public class ActionStateMachineComponent : MonoBehaviour
      , IActionStateMachineInterface
    {
        protected virtual void Awake()
        {
            // Initialise all tracks to null
            _activeActionStates = new Dictionary<EActionStateMachineTrack, ActionState>();

            foreach (EActionStateMachineTrack track in Enum.GetValues(typeof(EActionStateMachineTrack)))
            {
                _activeActionStates.Add(track, new NullActionState());
            }
        }

        // IActionStateMachineInterface
        public virtual void RequestActionState(EActionStateMachineTrack selectedTrack, ActionState newId)
        {
            _activeActionStates[selectedTrack] = newId;
        }

        public virtual bool IsActionStateActiveOnTrack(EActionStateMachineTrack selectedTrack, EActionStateId expectedId)
        {
            return _activeActionStates[selectedTrack].ActionStateId == expectedId;
        }
        // ~IActionStateMachineInterface

        private Dictionary<EActionStateMachineTrack, ActionState> _activeActionStates;
    }
}
