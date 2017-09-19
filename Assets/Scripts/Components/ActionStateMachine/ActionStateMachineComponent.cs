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
            activeActionStates = new Dictionary<EActionStateMachineTrack, EActionStateId>();

            foreach (EActionStateMachineTrack track in Enum.GetValues(typeof(EActionStateMachineTrack)))
            {
                activeActionStates.Add(track, EActionStateId.Null);
            }
        }

        // IActionStateMachineInterface
        public virtual void RequestActionState(EActionStateMachineTrack selectedTrack, EActionStateId newId)
        {
            activeActionStates[selectedTrack] = newId;
        }

        public virtual bool IsActionStateActiveOnTrack(EActionStateMachineTrack selectedTrack, EActionStateId expectedId)
        {
            return activeActionStates[selectedTrack] == expectedId;
        }
        // ~IActionStateMachineInterface

        private Dictionary<EActionStateMachineTrack, EActionStateId> activeActionStates;
    }
}
