// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.Components.HUD;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.HUD
{
    [TestFixture]
    public class HUDElementComponentTests
    {
        [Test]
        public void SetMessageDispatcher_PriorDispatcherWasNull_OnMessageInterfaceRemovedNotCalled()
        {
            var elementComponent = TestableMonobehaviourFunctions<TestHUDElementComponent>
                .PrepareMonobehaviourComponentForTest();

            var dispatcher = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            elementComponent.SetMessageDispatcher(dispatcher);

            Assert.IsFalse(elementComponent.MessageInterfaceRemovedCalled);
        }

        [Test]
        public void SetMessageDispatcher_ExistingDispatcherAndNewIsNullDispatcher_OnMessageInterfaceRemovedCalled()
        {
            var elementComponent = TestableMonobehaviourFunctions<TestHUDElementComponent>
                .PrepareMonobehaviourComponentForTest();

            var dispatcher = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            elementComponent.SetMessageDispatcher(dispatcher);

            elementComponent.SetMessageDispatcher(null);

            Assert.IsTrue(elementComponent.MessageInterfaceRemovedCalled);
        }

        [Test]
        public void SetMessageDispatcher_PriorNotNullNorNew_OnMessageInterfaceRemovedCalled()
        {
            var elementComponent = TestableMonobehaviourFunctions<TestHUDElementComponent>
                .PrepareMonobehaviourComponentForTest();

            var dispatcher = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            elementComponent.SetMessageDispatcher(dispatcher);
            elementComponent.SetMessageDispatcher(dispatcher);

            Assert.IsTrue(elementComponent.MessageInterfaceRemovedCalled);
        }

        [Test]
        public void SetMessageDispatcher_NullDispatcher_OnMessageInterfaceSetNotCalled()
        {
            var elementComponent = TestableMonobehaviourFunctions<TestHUDElementComponent>
                .PrepareMonobehaviourComponentForTest();

            elementComponent.SetMessageDispatcher(null);

            Assert.IsFalse(elementComponent.MessageInterfaceSetCalled);
        }

        [Test]
        public void SetMessageDispatcher_OnMessageInterfaceSetCalled()
        {
            var elementComponent = TestableMonobehaviourFunctions<TestHUDElementComponent>
                .PrepareMonobehaviourComponentForTest();

            var dispatcher = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            elementComponent.SetMessageDispatcher(dispatcher);

            Assert.IsTrue(elementComponent.MessageInterfaceSetCalled);
        }
    }
}
