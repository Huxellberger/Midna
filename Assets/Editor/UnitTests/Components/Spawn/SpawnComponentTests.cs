// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Components.UnityEvent;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.Spawn;
using Assets.Scripts.Test.Components.Spawn;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.Spawn
{
    [TestFixture]
    public class SpawnComponentTests
    {
        [Test]
        public void Trigger_SendEventToTriggeringGameObjectWithTransform()
        {
            var spawnComponent =
                TestableMonobehaviourFunctions<TestSpawnComponent>.PrepareMonobehaviourComponentForTest();
            var dispatcherComponent = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            var eventCapture = new UnityTestMessageHandleResponseObject<TriggerSpawnUpdateMessage>();
            var handle = dispatcherComponent.GetUnityMessageEventDispatcher().RegisterForMessageEvent<TriggerSpawnUpdateMessage>(eventCapture.OnResponse);

            spawnComponent.TestTriggerSpawnUpdate(dispatcherComponent.gameObject);

            Assert.IsTrue(eventCapture.ActionCalled);
            Assert.AreSame(eventCapture.MessagePayload.SpawnTransform, spawnComponent.gameObject.transform);

            dispatcherComponent.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(handle);
        }
    }
}

#endif
