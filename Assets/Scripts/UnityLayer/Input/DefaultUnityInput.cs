// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.UnityLayer.Input
{
    public class DefaultUnityInput
        : IUnityInputInterface
    {
        // IUnityInputInterface
        public float GetAxis(string axisName)
        {
            return UnityEngine.Input.GetAxis(axisName);
        }

        public bool GetButton(string buttonName)
        {
            return UnityEngine.Input.GetButton(buttonName);
        }

        public Vector3 GetMousePosition()
        {
            return UnityEngine.Input.mousePosition;
        }
        // ~IUnityInputInterface
    }
}
