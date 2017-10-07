// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.HUD
{
    public abstract class HUDElementComponent 
        : MonoBehaviour
    {
        protected IUnityMessageEventInterface MessageEventInterface { get; private set; }

        public void SetMessageDispatcher(IUnityMessageEventInterface inMessageEventInterface)
        {
            if (MessageEventInterface != null)
            {
                OnMessageInterfaceRemoved();
            }
            
            MessageEventInterface = inMessageEventInterface;

            if (MessageEventInterface != null)
            {
                OnMessageInterfaceSet();
            }
        }

        protected abstract void OnMessageInterfaceRemoved();
        protected abstract void OnMessageInterfaceSet();
    }
}
