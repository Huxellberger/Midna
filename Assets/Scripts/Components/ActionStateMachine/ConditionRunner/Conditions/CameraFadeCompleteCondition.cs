// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Camera;
using Assets.Scripts.Components.UnityEvent;
using UnityEngine;

namespace Assets.Scripts.Components.ActionStateMachine.ConditionRunner.Conditions
{
    public class CameraFadeCompleteCondition 
        : ActionStateCondition
    {
        private readonly float _fadeAlpha;
        private float FadeTime { get; set; }
        private IUnityMessageEventInterface UnityMessageEventInterface { get; set; }

        public CameraFadeCompleteCondition(float inFadeAlpha, float inFadeTime, IUnityMessageEventInterface inUnityMessageEventInterface)
            :base()
        {
            _fadeAlpha = inFadeAlpha;
            FadeTime = inFadeTime;
            UnityMessageEventInterface = inUnityMessageEventInterface;
        }

        public override void Start ()
        {
            if (UnityMessageEventInterface != null)
            {
                UnityMessageEventInterface.GetUnityMessageEventDispatcher().InvokeMessageEvent(new FadeCameraMessage(new Color(0.0f, 0.0f, 0.0f, 0.0f), _fadeAlpha, FadeTime ));
            }
        }

        public override void Update(float deltaTime)
        {
            FadeTime -= deltaTime;
            if (FadeTime <= 0.0f)
            {
                Complete = true;
            }
        }

        public override void End()
        {
        }
    }
}
