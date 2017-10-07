// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.HUD
{
    public class HUDComponent 
        : MonoBehaviour
    {
        public void SetPawn(GameObject inPawn)
        {
            IUnityMessageEventInterface messageEventInterface = null;

            if (inPawn != null)
            {
                messageEventInterface = inPawn.GetComponent<IUnityMessageEventInterface>();
            }

            var hudElements = GetComponents<HUDElementComponent>();

            foreach (var hudElement in hudElements)
            {
                hudElement.SetMessageDispatcher(messageEventInterface);
            }
        }
    }
}
