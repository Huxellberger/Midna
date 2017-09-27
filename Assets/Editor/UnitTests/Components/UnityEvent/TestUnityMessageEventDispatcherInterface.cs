// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;

namespace Assets.Editor.UnitTests.Components.UnityEvent
{
    public class TestUnityMessageEventDispatcherInterface
        : IUnityMessageEventInterface
    {
        public TestUnityMessageEventDispatcherInterface()
        {
            Dispatcher = new UnityMessageEventDispatcher();
        }

        // IUnityMessageEventInterface
        public UnityMessageEventDispatcher GetUnityMessageEventDispatcher()
        {
            return Dispatcher;
        }
        // ~IUnityMessageEventInterface

        public UnityMessageEventDispatcher Dispatcher { get; set; }
    }
}
