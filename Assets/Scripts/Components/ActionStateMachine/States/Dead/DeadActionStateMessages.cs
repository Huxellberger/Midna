// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.ActionStateMachine.States.Dead
{
    public class EnteredDeadActionStateMessage
        : UnityMessagePayload
    {
    }

    public class LeftDeadActionStateMessage
        : UnityMessagePayload
    {
    }

    public class RequestRespawnMessage
        : UnityMessagePayload
    {
        public RequestRespawnMessage(GameObject inRespawningCharacter)
            : base()
        {
            RespawningCharacter = inRespawningCharacter;
        }

        public GameObject RespawningCharacter { get; private set; }
    }
}
