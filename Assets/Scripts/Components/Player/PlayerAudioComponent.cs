// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Components.Health;
using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.Player
{
    [RequireComponent(typeof(AudioSource)), RequireComponent(typeof(UnityMessageEventDispatcherComponent))]
    public class PlayerAudioComponent 
        : MonoBehaviour
    {
        public AudioClip DamageAudioClip;
        public AudioClip HealAudioClip;
        public AudioClip DeadAudioClip;

        private IUnityMessageEventInterface UnityMessageEventInterface { get; set; }
        private AudioSource AudioComponent { get; set; }

        private UnityMessageEventHandle<HealthChangedMessage> HealthChangedHandle { get; set; }
        private UnityMessageEventHandle<EnteredDeadActionStateMessage> EnteredDeadActionStateHandle { get; set; }

        protected void Start()
        {
            UnityMessageEventInterface = GetComponent<IUnityMessageEventInterface>();
            AudioComponent = GetComponent<AudioSource>();
            RegisterForMessages();
        }

        protected void OnDestroy()
        {
            UnregisterForMessages();
        }

        private void RegisterForMessages()
        {
            if (UnityMessageEventInterface != null)
            {
                HealthChangedHandle = UnityMessageEventInterface.GetUnityMessageEventDispatcher()
                    .RegisterForMessageEvent<HealthChangedMessage>(OnHealthChanged);

                EnteredDeadActionStateHandle = UnityMessageEventInterface.GetUnityMessageEventDispatcher()
                    .RegisterForMessageEvent<EnteredDeadActionStateMessage>(OnEnteredDeadActionState);
            }
        }

        private void UnregisterForMessages()
        {
            if (UnityMessageEventInterface != null)
            {
                UnityMessageEventInterface.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(EnteredDeadActionStateHandle);
                UnityMessageEventInterface.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(HealthChangedHandle);
            }
        }

        private void OnHealthChanged(HealthChangedMessage inMessage)
        {
            if (inMessage.HealthChange > 0)
            {
                PlayAudioClip(HealAudioClip);
            }
            else
            {
                PlayAudioClip(DamageAudioClip);
            }
        }

        private void OnEnteredDeadActionState(EnteredDeadActionStateMessage inMessage)
        {
            PlayAudioClip(DeadAudioClip);
        }

        protected virtual void PlayAudioClip(AudioClip inAudioClip)
        {
            if (AudioComponent != null)
            {
                AudioComponent.PlayOneShot(inAudioClip);
            }
        }
    }
}
