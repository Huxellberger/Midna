// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Camera;
using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Test.Integration.Visual.Tests
{
    public class CameraController_FadesCorrectly 
        : MonoBehaviour
    {
        private static float CameraDelay = 3.0f;
        private float PassedDelay { get; set; }
        private bool Asserted { get; set; }

        void Start ()
        {
            Asserted = false;
            PassedDelay = 0.0f;
		    UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(gameObject, new FadeCameraMessage(Color.black, 1.0f, CameraDelay));
        }
	
        void Update ()
        {
            PassedDelay += Time.deltaTime;
            if (PassedDelay >= CameraDelay && !Asserted)
            {
                UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(gameObject, new VisualTestAssertMessage());
                Asserted = true;
            }
        }
    }
}

#endif 
