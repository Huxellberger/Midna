// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Character;
using UnityEngine;

namespace Assets.Scripts.Components.Spawn
{
    public class ProximitySpawnComponent 
        : SpawnComponent
    {
        void OnTriggerEnter2D(Collider2D inCollider)
        {
            if (inCollider != null && inCollider.gameObject != null)
            {
                OnGameObjectCollides(inCollider.gameObject);
            }
        }

        protected void OnGameObjectCollides(GameObject inCollidingObject)
        {
            if (inCollidingObject.GetComponent<MidnaCharacterComponent>() != null)
            {
                TriggerSpawnUpdate(inCollidingObject.gameObject);
            }
        }
       
    }
}
