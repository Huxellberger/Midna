// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.Controller;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Components.Input;
using Assets.Scripts.Components.Spawn;
using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.Character
{
    public class MidnaCharacterComponent 
        : MonoBehaviour
    {
        public ControllerComponent CurrentControllerComponent { get; set; }
        private UnityMessageEventHandle<TriggerSpawnUpdateMessage> SpawnUpdateHandle { get; set; }
        protected void Start ()
        {
            InitialiseInput();
            LocomotionActionStateHelpers.TransitionIntoLocomotionActionState(gameObject);

            RegisterMessages();
        }

        protected void OnDestroy()
        {
            UnregisterMessages();
        }

        private void InitialiseInput()
        {
            var currentGameMode = MidnaGameMode.CurrentGameMode;
            if (currentGameMode != null)
            {
                var inputInterface = currentGameMode.GetComponent<IInputInterface>();
                if (inputInterface != null)
                {
                    GetComponent<IInputBinderInterface>().SetInputInterface(inputInterface);
                }
            }
        }

        private void RegisterMessages()
        {
            var dispatcherInterface = GetComponent<IUnityMessageEventInterface>();
            if (dispatcherInterface != null)
            {
                SpawnUpdateHandle = dispatcherInterface.GetUnityMessageEventDispatcher()
                    .RegisterForMessageEvent<TriggerSpawnUpdateMessage>(OnTriggerSpawnUpdate);
            }
        }

        private void UnregisterMessages()
        {
            var dispatcherInterface = GetComponent<IUnityMessageEventInterface>();
            if (dispatcherInterface != null)
            {
                dispatcherInterface.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(SpawnUpdateHandle);
            }
        }

        private void OnTriggerSpawnUpdate(TriggerSpawnUpdateMessage inMessage)
        {
            CurrentControllerComponent.PawnInitialTransform = inMessage.SpawnTransform;
        }
    }
}
