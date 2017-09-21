// Copyright Threetee Gang (C) 2017

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Midna.Components.ActionStateMachine
{
    public class ActionStateMachineComponent : MonoBehaviour
      , IActionStateMachineInterface
    {
        protected virtual void Awake()
        {
            // Initialise all tracks to null
            activeActionStates = new Dictionary<EActionStateMachineTrack, ActionState>();

            foreach (EActionStateMachineTrack track in Enum.GetValues(typeof(EActionStateMachineTrack)))
            {
                activeActionStates.Add(track, new NullActionState());
            }
        }

        // IActionStateMachineInterface
        public virtual void RequestActionState(EActionStateMachineTrack selectedTrack, ActionState newId)
        {
            activeActionStates[selectedTrack] = newId;
        }

        public virtual bool IsActionStateActiveOnTrack(EActionStateMachineTrack selectedTrack, EActionStateId expectedId)
        {
            return activeActionStates[selectedTrack].actionStateId == expectedId;
        }
        // ~IActionStateMachineInterface

        private Dictionary<EActionStateMachineTrack, ActionState> activeActionStates;
    }
}
