// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Components.Health;
using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.Components.Player;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.Player
{
    [TestFixture]
    public class PlayerAudioComponentTestFixture
    {
        private TestUnityMessageEventDispatcherComponent _dispatcherComponent;
        private TestPlayerAudioComponent _audioComponent;

        [SetUp]
        public void BeforeTest()
        {
            _dispatcherComponent = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            _audioComponent = TestableMonobehaviourFunctions<TestPlayerAudioComponent>
                .AddTestableMonobehaviourComponent(_dispatcherComponent.gameObject);

            _audioComponent.DamageAudioClip = new AudioClip();
            _audioComponent.HealAudioClip = new AudioClip();
            _audioComponent.DeadAudioClip = new AudioClip();
        }

        [TearDown]
        public void AfterTest()
        {
            _audioComponent.TestDestroy();
            _audioComponent = null;

            _dispatcherComponent = null;
        }

        [Test]
        public void ReceivesHealthChangeMessage_Positive_HealClipPlayed()
        {
            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(_dispatcherComponent, new HealthChangedMessage(1, 100));
            Assert.AreEqual(_audioComponent.HealAudioClip, _audioComponent.LastPlayedAudioClip);
        }

        [Test]
        public void ReceivesHealthChangeMessage_Negative_DamageClipPlayed()
        {
            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(_dispatcherComponent, new HealthChangedMessage(-1, 100));
            Assert.AreEqual(_audioComponent.DamageAudioClip, _audioComponent.LastPlayedAudioClip);
        }

        [Test]
        public void ReceivesDeadMessage_DeadClipPlayed()
        {
            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(_dispatcherComponent, new EnteredDeadActionStateMessage());
            Assert.AreEqual(_audioComponent.DeadAudioClip, _audioComponent.LastPlayedAudioClip);
        }
    }
}
