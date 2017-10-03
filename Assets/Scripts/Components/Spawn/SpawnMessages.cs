// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.Spawn
{
    public class TriggerSpawnUpdateMessage 
        : UnityMessagePayload
    {
        public readonly Transform SpawnTransform;

        public TriggerSpawnUpdateMessage(Transform inSpawnTransform)
            : base()
        {
            SpawnTransform = inSpawnTransform;
        }
    }
}
