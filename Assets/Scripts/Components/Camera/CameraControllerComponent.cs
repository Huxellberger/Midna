// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Components.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera)), RequireComponent(typeof(UnityMessageEventDispatcherComponent))]
    public class CameraControllerComponent 
        : MonoBehaviour
    {
        public Texture2D FadeTexture;

        private UnityEngine.Camera CameraComponent { get; set; }
        private IUnityMessageEventInterface UnityMessageEventInterface { get; set; }
        private UnityMessageEventHandle<FadeCameraMessage> FadeCameraHandle { get; set; }
        private Optional<FadeInformation> CurrentFade { get; set; }
        private float StartingAlpha { get; set; }

        private static int DrawDepth = -1000;

        private class FadeInformation
        {
            public float FadeTimePassed { get; set; }
            public Color FadeColour { get; set; }

            public readonly float AlphaDiff;
            public readonly float TargetAlpha;
            public readonly float TimeDelay;

            public FadeInformation(FadeCameraMessage inCurrentFade, float startingAlpha)
            {
                FadeTimePassed = 0.0f;
                FadeColour = inCurrentFade.FadeColour;

                AlphaDiff = inCurrentFade.FadeAlpha - startingAlpha;
                TargetAlpha = inCurrentFade.FadeAlpha;
                TimeDelay = inCurrentFade.FadeDelay;
            }
        }

        protected void Start ()
        {
            CurrentFade = new Optional<FadeInformation>();
            StartingAlpha = 0.0f;
            CameraComponent = GetComponent<UnityEngine.Camera>();
            UnityMessageEventInterface = GetComponent<IUnityMessageEventInterface>();

            RegisterForMessages();
        }

        protected void OnGUI()
        {
            var deltaTime = GetDeltaTime();
            if (CurrentFade.IsSet())
            {
                var currentFadeValue = CurrentFade.Get();
                currentFadeValue.FadeTimePassed += deltaTime;

                // Current alpha = Our previous alpha + How far along our new alpha change has come
                var currentAlpha = Mathf.Clamp
                (
                    StartingAlpha + 
                    (currentFadeValue.AlphaDiff * Mathf.Clamp((currentFadeValue.FadeTimePassed / currentFadeValue.TimeDelay), 0.0f, 1.0f)),
                    0.0f, 1.0f
                );

                GUI.backgroundColor = new Color(currentFadeValue.FadeColour.r, currentFadeValue.FadeColour.g, currentFadeValue.FadeColour.b, currentAlpha);
                GUI.depth = DrawDepth;
                GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), FadeTexture);
            }
        }

        protected virtual float GetDeltaTime()
        {
            return Time.deltaTime;
        }

        protected void OnDestroy()
        {
            UnregisterForMessages();
        }

        private void RegisterForMessages()
        {
            if (UnityMessageEventInterface != null)
            {
                FadeCameraHandle = UnityMessageEventInterface.GetUnityMessageEventDispatcher()
                    .RegisterForMessageEvent<FadeCameraMessage>(OnFadeCameraMessage);
            }
        }

        private void UnregisterForMessages()
        {
            if (UnityMessageEventInterface != null)
            {
                UnityMessageEventInterface.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(FadeCameraHandle);
            }
        }

        private void OnFadeCameraMessage(FadeCameraMessage inMessage)
        {
            CurrentFade = new Optional<FadeInformation>(new FadeInformation(inMessage, StartingAlpha));
        }
    }
}
