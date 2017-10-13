// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Player;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

namespace Assets.Scripts.Test.Components.Player
{
    public class TestPlayerAudioComponent 
        : PlayerAudioComponent
        , ITestableMonobehaviour
    {
        public AudioClip LastPlayedAudioClip { get; set; }

        protected override void PlayAudioClip(AudioClip inAudioClip)
        {
            LastPlayedAudioClip = inAudioClip;
        }

        public void TestDestroy()
        {
            OnDestroy();
        }

        public void PrepareForTest(params object[] parameters)
        {
            Start();
        }
    }
}
