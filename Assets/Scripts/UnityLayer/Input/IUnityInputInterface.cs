// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.UnityLayer.Input
{
    public interface IUnityInputInterface
    {
        float GetAxis(string axisName);
        bool GetButton(string buttonName);
        Vector3 GetMousePosition();
    }
}
