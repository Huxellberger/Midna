// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.Spawn
{
    public abstract class SpawnComponent 
        : MonoBehaviour
    {
        protected void TriggerSpawnUpdate(GameObject spawnableGameObject)
        {
            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(spawnableGameObject, new TriggerSpawnUpdateMessage(gameObject.transform));
        }
    }
}
