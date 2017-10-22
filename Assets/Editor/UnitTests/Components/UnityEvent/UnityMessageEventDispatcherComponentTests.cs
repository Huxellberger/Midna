// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.UnityEvent
{
    [TestFixture]
    public class UnityMessageEventDispatcherComponentTestFixture {

        [Test]
        public void GetMessageEventDispatcher_ReturnsValidDispatcher()
        {
            var unityMessageEventDispatcherComponent = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            Assert.NotNull(unityMessageEventDispatcherComponent.GetUnityMessageEventDispatcher());
        }
    }
}

#endif
