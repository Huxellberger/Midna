// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Health;
using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.Equipment.EquipmentItem
{
    [RequireComponent(typeof(Collider2D)), RequireComponent(typeof(UnityMessageEventDispatcherComponent)), RequireComponent(typeof(SpriteRenderer))]
    public class Cane 
        : EquipmentItemComponent
    {
        public int PokeHealthChange = -5;
        public float PokeDuration = 3.0f;

        private bool UsingItem { get; set; }
        private float CurrentPokeTime { get; set; }
        private SpriteRenderer SpriteComponent { get; set; }

        protected void Start()
        {
            SpriteComponent = gameObject.GetComponent<SpriteRenderer>();
            SpriteComponent.enabled = false;

            UsingItem = false;
            CurrentPokeTime = 0.0f;
        }

        protected void Update()
        {
            var deltaTime = GetDeltaTime();

            CurrentPokeTime += deltaTime;
            if (CurrentPokeTime >= PokeDuration)
            {
                SpriteComponent.enabled = false;
                CurrentPokeTime = 0.0f;
                UsingItem = false;
            }
        }

        protected virtual float GetDeltaTime()
        {
            return Time.deltaTime;
        }

        // EquipmentItemComponent
        protected override void OnUseItem()
        {
            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(gameObject, new CaneActivatedMessage());

            UsingItem = true;
            SpriteComponent.enabled = true;
        }

        protected override void OnStopUsingItem()
        {
        }
        // ~EquipmentItemComponent

        // Collider
        void OnTriggerEnter2D(Collider2D inCollider)
        {
            if (inCollider != null && inCollider.gameObject != null)
            {
                OnGameObjectCollides(inCollider.gameObject);
            }
        }

        protected void OnGameObjectCollides(GameObject inCollidingObject)
        {
            if (!UsingItem)
            {
                return;
            }

            if (inCollidingObject == Owner)
            {
                return;
            }

            var healthInterface = inCollidingObject.GetComponent<IHealthInterface>();
            if (healthInterface != null)
            {
                healthInterface.AdjustHealth(PokeHealthChange);
            }
        }
        // ~Collider
    }
}
