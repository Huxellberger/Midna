// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.Camera
{
    public class FadeCameraMessage
        : UnityMessagePayload
    {
        public FadeCameraMessage(Color inFadeColour, float inFadeAlpha, float inFadeDelay)
        {
            FadeColour = inFadeColour;
            FadeAlpha = inFadeAlpha;
            FadeDelay = inFadeDelay;
        }

        public readonly Color FadeColour;
        public readonly float FadeAlpha;
        public readonly float FadeDelay;
    }
}
